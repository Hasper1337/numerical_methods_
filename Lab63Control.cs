using System.Text;

namespace GraphPlotter;

/// <summary>
/// Лаб. 6.3, вариант 5: наилучшее среднеквадратичное приближение многочленами 4-й и 5-й степени,
/// показательной и логарифмической функциями; данные — f(x) со случайной погрешностью 30–300 %.
/// </summary>
public partial class Lab63Control : UserControl
{
    readonly Random rnd = new();
    List<(double X, double Y)> data = new();

    public Lab63Control()
    {
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!Util.InDesigner) Util.Try(Run);
    }

    void btnRun_Click(object sender, EventArgs e) => Util.Try(Run);

    void btnReset_Click(object sender, EventArgs e)
    {
        if (data.Count > 0) graph.FitTo(data); else graph.ResetView();
    }

    static string Coefs(double[] c) =>
        string.Join(", ", c.Select((v, i) => $"c{i}={Util.F(v, "0.####e+0")}"));

    void Run()
    {
        var f = Util.Compile(txtFormula.Text);
        double a = Util.Num(txtA, "a"), b = Util.Num(txtB, "b");
        double errMin = Util.Num(txtErrMin, "погрешность от"), errMax = Util.Num(txtErrMax, "погрешность до");
        int n = (int)nudN.Value;
        if (a <= 0 || a >= b) throw new ArgumentException("Нужно 0 < a < b (для логарифмической модели x должен быть положительным).");
        if (errMin < 0 || errMax < errMin) throw new ArgumentException("Погрешность: 0 ≤ «от» ≤ «до».");

        // Данные: f(x) · (1 ± случайная погрешность из [errMin; errMax] %).
        var xs = new double[n];
        var ys = new double[n];
        data = new List<(double X, double Y)>();
        for (int i = 0; i < n; i++)
        {
            xs[i] = a + (b - a) * i / (n - 1);
            double err = (errMin + rnd.NextDouble() * (errMax - errMin)) / 100 * (rnd.Next(2) == 0 ? -1 : 1);
            ys[i] = f(xs[i]) * (1 + err);
            data.Add((xs[i], ys[i]));
        }

        // Все варианты приближения.
        var models = new List<(string Name, Color Color, Func<double, double> F, string Params)>();
        var notes = new StringBuilder();

        var c4 = Methods.PolyFit(xs, ys, 4);
        models.Add(("Многочлен 4-й степени (синий)", Color.RoyalBlue, x => Methods.Poly(c4, x), Coefs(c4)));
        var c5 = Methods.PolyFit(xs, ys, 5);
        models.Add(("Многочлен 5-й степени (оранжевый)", Color.DarkOrange, x => Methods.Poly(c5, x), Coefs(c5)));
        try
        {
            var (ea, eb) = Methods.FitExp(xs, ys);
            models.Add(("Показательная a·e^(bx) (зелёный)", Color.ForestGreen, x => ea * Math.Exp(eb * x),
                        $"a={Util.F(ea, "0.####e+0")}, b={Util.F(eb, "0.####e+0")}"));
            int skipped = ys.Count(y => y <= 0);
            if (skipped > 0) notes.AppendLine($"Показательная: {skipped} точек с y ≤ 0 не участвовали в подборе (ln y не определён).");
        }
        catch (InvalidOperationException ex)
        {
            notes.AppendLine("Показательная модель не построена: " + ex.Message);
        }
        var (la, lb) = Methods.FitLog(xs, ys);
        models.Add(("Логарифмическая a·ln(x)+b (фиолетовый)", Color.DarkMagenta, x => la * Math.Log(x) + lb,
                    $"a={Util.F(la, "0.####e+0")}, b={Util.F(lb, "0.####e+0")}"));

        // График: серый — f(x), чёрные точки — данные, цветные кривые — приближения.
        graph.ClearAll();
        graph.Curves.Add(new Curve(f, Color.Gray));
        graph.PointSets.Add(new PointSet(data, Color.Black, 3));

        var report = new StringBuilder();
        report.AppendLine($"Точек: {n}, погрешность {Util.F(errMin, "0.#")}–{Util.F(errMax, "0.#")} % (знак случайный).");
        report.AppendLine("Серый — f(x), чёрные точки — данные.");
        report.AppendLine();

        string best = "", closest = "";
        double bestSse = double.MaxValue, closestRmse = double.MaxValue;
        foreach (var m in models)
        {
            graph.Curves.Add(new Curve(m.F, m.Color));
            double sse = 0, dev = 0;
            for (int i = 0; i < n; i++)
            {
                sse += Math.Pow(m.F(xs[i]) - ys[i], 2);            // отклонение от данных (минимизируется МНК)
                dev += Math.Pow(m.F(xs[i]) - f(xs[i]), 2);          // отклонение от «чистой» f(x)
            }
            double rmse = Math.Sqrt(sse / n), devRmse = Math.Sqrt(dev / n);
            report.AppendLine(m.Name);
            report.AppendLine("  " + m.Params);
            report.AppendLine($"  Σ(ошибок)² = {Util.F(sse, "0.####e+0")},  среднекв. ошибка = {Util.F(rmse, "0.###")}");
            report.AppendLine($"  среднекв. отклонение от чистой f(x) = {Util.F(devRmse, "0.###")}");
            report.AppendLine();
            if (sse < bestSse) { bestSse = sse; best = m.Name; }
            if (devRmse < closestRmse) { closestRmse = devRmse; closest = m.Name; }
        }
        report.Append(notes);
        report.AppendLine("=== Вывод ===");
        report.AppendLine($"Наименьшее среднеквадратичное приближение к данным: {best}.");
        report.AppendLine($"Ближе всего к исходной f(x): {closest}.");
        report.AppendLine("При такой погрешности данные сильно искажены, поэтому форма модели важнее числа параметров.");
        txtOutput.Text = report.ToString();

        graph.FitTo(data);
    }
}

namespace GraphPlotter;

/// <summary>Лаб. 6.2: кусочно-линейная интерполяция (допустимо и ~10^5 точек), просмотр прямой на выбранном отрезке.</summary>
public partial class Lab62Control : UserControl
{
    const int MaxMarkers = 500;          // больше узлов по отдельности не рисуем — достаточно линии

    double[] xs = Array.Empty<double>(), ys = Array.Empty<double>(), k = Array.Empty<double>(), bb = Array.Empty<double>();
    string mainText = "";

    public Lab62Control()
    {
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!Util.InDesigner) Build();
    }

    void btnBuild_Click(object sender, EventArgs e) => Build();

    void btnReset_Click(object sender, EventArgs e) => graph.ResetView();

    void Build() => Util.Try(() =>
    {
        var f = Util.Compile(txtFormula.Text);
        double a = Util.Num(txtA, "a"), b = Util.Num(txtB, "b"), x0 = Util.Num(txtX0, "x0");
        if (a >= b) throw new ArgumentException("Нужно a < b.");
        int n = (int)nudN.Value;

        var px = new double[n];
        var py = new double[n];
        for (int i = 0; i < n; i++)
        {
            px[i] = a + (b - a) * i / (n - 1);
            py[i] = f(px[i]);
        }
        var (kk, bk) = Methods.Lines(px, py);         // коэффициенты прямых на всех отрезках
        xs = px; ys = py; k = kk; bb = bk;
        Func<double, double> s = x => Methods.EvalLines(xs, k, bb, x);
        double sx0 = s(x0);

        graph.ClearAll();
        graph.Curves.Add(new Curve(f, Color.RoyalBlue));
        graph.Curves.Add(new Curve(s, Color.DarkOrange));
        if (n <= MaxMarkers)
            graph.PointSets.Add(new PointSet(px.Zip(py).Select(p => (p.First, p.Second)).ToList(), Color.ForestGreen, 3));
        graph.Markers.Add(new Marker(x0, sx0, Color.Purple, Star: true));
        graph.ResetView();

        nudSegment.Maximum = n - 2;
        nudSegment.Value = 0;
        mainText = $"Узлов {n}{(n > MaxMarkers ? " (по отдельности не рисуются)" : "")}.   S({Util.F(x0, "0.####")}) = {Util.F(sx0)}   (f = {Util.F(f(x0))}).";
        ShowSegment();
    });

    // Уравнение прямой на выбранном отрезке.
    void ShowSegment()
    {
        if (xs.Length < 2) return;
        int i = Math.Min((int)nudSegment.Value, xs.Length - 2);
        lblResult.Text = mainText + Environment.NewLine +
            $"Отрезок {i}: x ∈ [{Util.F(xs[i])}; {Util.F(xs[i + 1])}],   y = {Util.F(k[i])}·x {(bb[i] < 0 ? "−" : "+")} {Util.F(Math.Abs(bb[i]))}";
    }

    void nudSegment_ValueChanged(object sender, EventArgs e) => ShowSegment();

    // Приближение к выбранному отрезку.
    void btnShowSegment_Click(object sender, EventArgs e) => Util.Try(() =>
    {
        if (xs.Length < 2) throw new InvalidOperationException("Сначала постройте функцию.");
        int i = Math.Min((int)nudSegment.Value, xs.Length - 2);
        graph.CenterAndZoom((xs[i] + xs[i + 1]) / 2, (ys[i] + ys[i + 1]) / 2,
                            graph.Width * 0.4 / Math.Max(xs[i + 1] - xs[i], 1e-9));
    });
}

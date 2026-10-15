using System.Text;

namespace GraphPlotter;

/// <summary>Лаб. 3: экстремум (минимум или максимум) методом парабол на отрезке унимодальности [a, b].</summary>
public partial class Lab3Control : UserControl
{
    double lastX, lastY, lastEps = 1e-4;

    public Lab3Control()
    {
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!Util.InDesigner) Plot();
    }

    void btnPlot_Click(object sender, EventArgs e) => Plot();

    void btnReset_Click(object sender, EventArgs e) => graph.ResetView();

    void ShowFunction(Func<double, double> f)
    {
        graph.ClearAll();
        graph.Curves.Add(new Curve(f, Color.RoyalBlue));
    }

    void Plot() => Util.Try(() =>
    {
        ShowFunction(Util.Compile(txtFormula.Text));
        graph.ResetView();
    });

    void btnSolve_Click(object sender, EventArgs e) => Util.Try(() =>
    {
        var f = Util.Compile(txtFormula.Text);
        double a = Util.Num(txtA, "a"), b = Util.Num(txtB, "b"), eps = Util.Num(txtEps, "ε");
        if (eps <= 0) throw new ArgumentException("ε должно быть положительным.");

        var log = new StringBuilder();
        double x = Methods.ParabolaExtremum(f, a, b, eps, radioMax.Checked, log, out int iterations);
        double fx = f(x);

        // Производные в найденной точке — центральными разностями.
        const double h = 1e-4;
        double d1 = (f(x + h) - f(x - h)) / (2 * h);
        double d2 = (f(x + h) - 2 * fx + f(x - h)) / (h * h);
        string type = d2 > 0 ? "минимум" : d2 < 0 ? "максимум" : "не определён (f'' = 0)";

        lastX = x;
        lastY = fx;
        lastEps = eps;
        log.AppendLine();
        log.AppendLine($"x* = {Util.F(x)}");
        log.AppendLine($"f(x*) = {Util.F(fx)}");
        log.AppendLine($"f'(x*) ≈ {Util.F(d1, "0.00e+0")}");
        log.AppendLine($"f''(x*) ≈ {Util.F(d2, "0.0000")}");
        log.AppendLine($"Тип экстремума: {type}");
        log.AppendLine($"Число итераций: {iterations}");
        txtOutput.Text = log.ToString();

        ShowFunction(f);
        graph.Markers.Add(new Marker(x, fx, Color.LimeGreen));
        graph.Invalidate();
    });

    void btnZoom_Click(object sender, EventArgs e) => Util.Try(() =>
    {
        if (graph.Markers.Count == 0) throw new InvalidOperationException("Сначала найдите экстремум.");
        graph.CenterAndZoom(lastX, lastY, Math.Max(200, graph.Width * 0.3) / lastEps);
    });
}

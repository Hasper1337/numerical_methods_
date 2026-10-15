using System.Text;

namespace GraphPlotter;

/// <summary>Лаб. 2: корень уравнения f(x) = 0 методом парабол; отрезок [a, b] подбирается по графику.</summary>
public partial class Lab2Control : UserControl
{
    double lastX, lastY, lastEps = 1e-4;

    public Lab2Control()
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
        double root = Methods.ParabolaRoot(f, a, b, eps, log, out int iterations);

        lastX = root;
        lastY = f(root);
        lastEps = eps;
        log.AppendLine();
        log.AppendLine($"Корень x* = {Util.F(root)}");
        log.AppendLine($"f(x*) = {Util.F(lastY, "0.00e+0")}");
        log.AppendLine($"Число итераций: {iterations}");
        txtOutput.Text = log.ToString();

        ShowFunction(f);                                        // вид (масштаб, сдвиг) не сбрасываем
        graph.Markers.Add(new Marker(root, lastY, Color.LimeGreen));
        graph.Invalidate();
    });

    // Приближение к корню до масштаба порядка ε — видна достигнутая точность.
    void btnZoom_Click(object sender, EventArgs e) => Util.Try(() =>
    {
        if (graph.Markers.Count == 0) throw new InvalidOperationException("Сначала найдите корень.");
        graph.CenterAndZoom(lastX, lastY, Math.Max(200, graph.Width * 0.3) / lastEps);
    });
}

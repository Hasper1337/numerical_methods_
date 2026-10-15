namespace GraphPlotter;

/// <summary>Лаб. 6.1: интерполяционный многочлен степени 1…50 по равномерным узлам (форма Лагранжа).</summary>
public partial class Lab61Control : UserControl
{
    public Lab61Control()
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
        int degree = (int)nudDegree.Value;

        // Число узлов = степень + 1 (по числу параметров многочлена).
        var xs = new double[degree + 1];
        var ys = new double[degree + 1];
        var nodes = new List<(double X, double Y)>();
        for (int i = 0; i <= degree; i++)
        {
            xs[i] = a + (b - a) * i / degree;
            ys[i] = f(xs[i]);
            nodes.Add((xs[i], ys[i]));
        }
        var p = Methods.Lagrange(xs, ys);
        double px0 = p(x0);

        graph.ClearAll();
        graph.Curves.Add(new Curve(f, Color.RoyalBlue));            // исходная функция — синий
        graph.Curves.Add(new Curve(p, Color.DarkOrange));           // многочлен — оранжевый
        graph.PointSets.Add(new PointSet(nodes, Color.ForestGreen)); // узлы — зелёный
        graph.Markers.Add(new Marker(x0, px0, Color.Purple, Star: true));
        graph.ResetView();

        lblResult.Text = $"Степень {degree}, узлов {degree + 1}.   P({Util.F(x0, "0.####")}) = {Util.F(px0)}   " +
                         $"(f({Util.F(x0, "0.####")}) = {Util.F(f(x0))}).   Синий — f(x), оранжевый — многочлен, зелёные — узлы, звёздочка — P(x0).";
    });
}

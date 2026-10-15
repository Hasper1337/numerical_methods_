namespace GraphPlotter;

/// <summary>Лаб. 1: график функции, заданной формулой или таблицей из текстового файла.</summary>
public partial class Lab1Control : UserControl
{
    public Lab1Control()
    {
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!Util.InDesigner) Plot();
    }

    // Режим «аналитическая» / «табличная»: включаем только нужные элементы.
    void radioAnalytical_CheckedChanged(object sender, EventArgs e)
    {
        bool analytical = radioAnalytical.Checked;
        txtFormula.Enabled = btnPlot.Enabled = analytical;
        btnLoad.Enabled = !analytical;
    }

    void btnPlot_Click(object sender, EventArgs e) => Plot();

    void btnReset_Click(object sender, EventArgs e) => graph.ResetView();

    void Plot() => Util.Try(() =>
    {
        var f = Util.Compile(txtFormula.Text);
        graph.ClearAll();
        graph.Curves.Add(new Curve(f, Color.RoyalBlue));
        graph.ResetView();      // начало координат — в центре
    });

    void btnLoad_Click(object sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog { Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*" };
        if (dialog.ShowDialog() != DialogResult.OK) return;

        Util.Try(() =>
        {
            // Две колонки чисел; разделитель — пробел, табуляция, «;» (или запятая, если она одна в строке).
            var points = new List<(double X, double Y)>();
            foreach (var line in File.ReadLines(dialog.FileName))
            {
                var t = line.Split(new[] { ' ', '\t', ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (t.Length == 1 && t[0].Count(c => c == ',') == 1) t = t[0].Split(',');
                if (t.Length >= 2 && Util.TryNum(t[0], out double x) && Util.TryNum(t[1], out double y))
                    points.Add((x, y));
            }
            if (points.Count == 0) throw new FormatException("В файле нет строк с двумя числами (x и y).");

            points.Sort((p, q) => p.X.CompareTo(q.X));
            graph.ClearAll();
            graph.PointSets.Add(new PointSet(points, Color.Crimson, 3.5f, Line: true));
            graph.FitTo(points);
            lblFile.Text = $"{Path.GetFileName(dialog.FileName)} ({points.Count} точек)";
        });
    }
}

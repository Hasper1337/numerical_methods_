using System;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace GraphPlotter;

public sealed class Lab78Control : UserControl
{
    // Вариант 21 из таблицы 1:
    // f(x) = x^2 - 3 - 2*cos(2*pi*x)
    private static double F(double x) => x * x - 3.0 - 2.0 * Math.Cos(2.0 * Math.PI * x);
    private static double ExactSecond(double x) => 2.0 + 8.0 * Math.PI * Math.PI * Math.Cos(2.0 * Math.PI * x);
    private const double Eps = 1e-4;

    private readonly TextBox a7 = Box("0");
    private readonly TextBox b7 = Box("1");
    private readonly TextBox n7 = Box("4");
    private readonly TextBox xPoint = Box("0.25");
    private readonly TextBox h1 = Box("0.1");
    private readonly TextBox h2 = Box("0.05");
    private readonly TextBox h3 = Box("0.025");
    private readonly TextBox odeStep = Box("0.01");
    private readonly DataGridView derivativeGrid = Grid();
    private readonly DataGridView odeGrid = Grid();
    private readonly PlotPanel integralPlot = new();
    private readonly PlotPanel derivativePlot = new();
    private readonly PlotPanel odePlot = new();
    private readonly TextBox integralOutput = Output();
    private readonly TextBox derivativeOutput = Output();
    private readonly TextBox odeOutput = Output();

    public Lab78Control()
    {
        Font = new Font("Segoe UI", 9.5f);

        var tabs = new TabControl { Dock = DockStyle.Fill };
        tabs.TabPages.Add(BuildIntegralTab());
        tabs.TabPages.Add(BuildDerivativeTab());
        tabs.TabPages.Add(BuildOdeTab());
        Controls.Add(tabs);
    }

    private TabPage BuildIntegralTab()
    {
        var page = new TabPage("Лабораторная №7 — интеграл");
        var root = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1, Padding = new Padding(8) };
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 350));
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        page.Controls.Add(root);

        var left = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, WrapContents = false, AutoScroll = true };
        left.Controls.Add(Header("Метод левых прямоугольников"));
        left.Controls.Add(new Label { Text = "Функция: f(x) = x² − 3 − 2·cos(2πx)", AutoSize = true, MaximumSize = new Size(320, 0) });
        left.Controls.Add(Field("Нижний предел a", a7));
        left.Controls.Add(Field("Верхний предел b", b7));
        left.Controls.Add(Field("Начальное число разбиений N", n7));
        var run = new Button { Text = "Вычислить интеграл", Width = 300, Height = 38 };
        run.Click += (_, _) => CalculateIntegral();
        left.Controls.Add(run);
        left.Controls.Add(integralOutput);
        left.Controls.Add(new Label { Text = "Точность: ε = 10⁻⁴. Сетка удваивается до выполнения |I₂N − Iₙ| < ε.", AutoSize = true, MaximumSize = new Size(320, 0) });
        root.Controls.Add(left, 0, 0);
        var right = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2 };
        right.RowStyles.Add(new RowStyle(SizeType.Percent, 65));
        right.RowStyles.Add(new RowStyle(SizeType.Percent, 35));
        right.Controls.Add(integralPlot, 0, 0);
        right.Controls.Add(new Label { Text = "График подынтегральной функции f(x)", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter }, 0, 1);
        root.Controls.Add(right, 1, 0);
        return page;
    }

    private TabPage BuildDerivativeTab()
    {
        var page = new TabPage("Лабораторная №8 — вторая производная");
        var root = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, Padding = new Padding(8) };
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 365));
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        page.Controls.Add(root);

        var left = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, WrapContents = false, AutoScroll = true };
        left.Controls.Add(Header("Вариант задания №2 — вторая производная"));
        left.Controls.Add(new Label { Text = "f(x) = x² − 3 − 2·cos(2πx)\nf″(x) = 2 + 8π²·cos(2πx)", AutoSize = true });
        left.Controls.Add(Field("Точка вычисления x", xPoint));
        left.Controls.Add(Field("Шаг h₁", h1));
        left.Controls.Add(Field("Шаг h₂", h2));
        left.Controls.Add(Field("Шаг h₃", h3));
        var run = new Button { Text = "Вычислить вторую производную", Width = 330, Height = 38 };
        run.Click += (_, _) => CalculateDerivative();
        left.Controls.Add(run);
        left.Controls.Add(derivativeOutput);
        derivativeGrid.Height = 210;
        derivativeGrid.Width = 335;
        left.Controls.Add(derivativeGrid);
        root.Controls.Add(left, 0, 0);
        root.Controls.Add(derivativePlot, 1, 0);
        return page;
    }

    private TabPage BuildOdeTab()
    {
        var page = new TabPage("Лабораторная №8 — ОДУ вариант 1");
        var root = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, Padding = new Padding(8) };
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 420));
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        page.Controls.Add(root);

        var left = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, WrapContents = false, AutoScroll = true };
        left.Controls.Add(Header("ОДУ, таблица 3, вариант 1"));
        left.Controls.Add(new Label { Text = "y′ = sin(x + e^(x + y²));   y(0) = 1;   x ∈ [0; 1]", AutoSize = true });
        left.Controls.Add(Field("Шаг интегрирования h", odeStep));
        var run = new Button { Text = "Решить методом Эйлера", Width = 360, Height = 38 };
        run.Click += (_, _) => CalculateOde();
        left.Controls.Add(run);
        left.Controls.Add(new Label { Text = "Используется явная схема Эйлера. Все вычисления реализованы вручную, без библиотек численных методов.", AutoSize = true, MaximumSize = new Size(380, 0) });
        left.Controls.Add(odeOutput);
        odeGrid.Height = 330;
        odeGrid.Width = 390;
        left.Controls.Add(odeGrid);
        root.Controls.Add(left, 0, 0);
        root.Controls.Add(odePlot, 1, 0);
        return page;
    }

    private void CalculateIntegral()
    {
        if (!Read(a7, out double a) || !Read(b7, out double b) || !Read(n7, out double nd) ||
            b <= a || nd < 1 || nd > 10000000 || nd != Math.Truncate(nd))
        { MessageBox.Show("Проверьте a, b и N: требуется b > a, N — положительное целое число."); return; }

        int n = (int)nd, iterations = 0;
        double previous = LeftRectangles(a, b, n), current = previous, error;
        do
        {
            n *= 2;
            if (n > 20_000_000) { MessageBox.Show("Достигнут предел числа разбиений."); return; }
            current = LeftRectangles(a, b, n);
            error = Math.Abs(current - previous);
            previous = current;
            iterations++;
        } while (error >= Eps && iterations < 30);

        integralOutput.Text = $"Интеграл ≈ {current:G15}\r\nОценка |I₂N − Iₙ| = {error:E6}\r\nУзлов: {n}\r\nИтераций: {iterations}";
        integralPlot.SetSeries(new[] { Sample(F, a, b, 500) }, new[] { "f(x)" }, a, b);
    }

    private static double LeftRectangles(double a, double b, int n)
    {
        double h = (b - a) / n, sum = 0;
        for (int i = 0; i < n; i++) sum += F(a + i * h);
        return sum * h;
    }

    private void CalculateDerivative()
    {
        if (!Read(xPoint, out double x) || !Read(h1, out double s1) || !Read(h2, out double s2) || !Read(h3, out double s3) ||
            s1 <= 0 || s2 <= 0 || s3 <= 0)
        { MessageBox.Show("Введите x и три положительных шага h."); return; }

        double[] hs = { s1, s2, s3 };
        var numericalPoints = new System.Collections.Generic.List<PointF[]>();
        var numericalNames = new System.Collections.Generic.List<string>();
        derivativeGrid.Columns.Clear();
        derivativeGrid.Rows.Clear();
        derivativeGrid.Columns.Add("h", "Шаг h");
        derivativeGrid.Columns.Add("d2", "Формула 2-го порядка");
        derivativeGrid.Columns.Add("d4", "Формула 4-го порядка");
        derivativeGrid.Columns.Add("exact", "Точное f″(x)");
        var sb = new StringBuilder($"x = {x:G10}\r\n");
        foreach (double h in hs)
        {
            double d2 = (F(x + h) - 2 * F(x) + F(x - h)) / (h * h);
            double d4 = (-F(x + 2 * h) + 16 * F(x + h) - 30 * F(x) + 16 * F(x - h) - F(x - 2 * h)) / (12 * h * h);
            double exact = ExactSecond(x);
            derivativeGrid.Rows.Add(h.ToString("G6"), d2.ToString("G12"), d4.ToString("G12"), exact.ToString("G12"));
            numericalPoints.Add(new[] { new PointF((float)x, (float)d2) });
            numericalNames.Add($"O(h²), h={h:G4}");
            numericalPoints.Add(new[] { new PointF((float)x, (float)d4) });
            numericalNames.Add($"O(h⁴), h={h:G4}");
            sb.AppendLine($"h={h:G6}: O(h²)={d2:G12}; O(h⁴)={d4:G12}; f″={exact:G12}");
        }
        derivativeOutput.Text = sb.ToString();
        var allSeries = new System.Collections.Generic.List<PointF[]> { Sample(ExactSecond, 0, 1, 500) };
        allSeries.AddRange(numericalPoints);
        var allNames = new System.Collections.Generic.List<string> { "Аналитическая f″(x)" };
        allNames.AddRange(numericalNames);
        derivativePlot.SetSeries(allSeries.ToArray(), allNames.ToArray(), 0, 1);
    }

    private void CalculateOde()
    {
        if (!Read(odeStep, out double h) || h <= 0 || h > 1)
        { MessageBox.Show("Шаг должен быть больше 0 и не больше 1."); return; }

        int n = (int)Math.Ceiling(1.0 / h);
        h = 1.0 / n;
        double x = 0, y = 1;
        var xs = new double[n + 1];
        var ys = new double[n + 1];
        odeGrid.Columns.Clear();
        odeGrid.Rows.Clear();
        odeGrid.Columns.Add("i", "i");
        odeGrid.Columns.Add("x", "x");
        odeGrid.Columns.Add("y", "y Эйлера");
        odeGrid.Columns.Add("rhs", "Правая часть y′");
        xs[0] = x; ys[0] = y;
        for (int i = 0; i <= n; i++)
        {
            double rhs = OdeRight(x, y);
            odeGrid.Rows.Add(i, x.ToString("G8"), y.ToString("G12"), rhs.ToString("G12"));
            if (i == n) break;
            y = y + h * rhs;
            x = (i + 1) * h;
            xs[i + 1] = x; ys[i + 1] = y;
        }
        odeOutput.Text = $"Метод Эйлера\r\nШаг: {h:G8}\r\nКоличество шагов: {n}\r\ny(1) ≈ {y:G15}";
        odePlot.SetSeries(new[] { xs.Zip(ys, (xx, yy) => new PointF((float)xx, (float)yy)).ToArray() }, new[] { "Численное решение" }, 0, 1);
    }

    private static double OdeRight(double x, double y) => Math.Sin(x + Math.Exp(x + y * y));

    private static PointF[] Sample(Func<double, double> f, double a, double b, int count)
    {
        var points = new PointF[count + 1];
        for (int i = 0; i <= count; i++)
        {
            double x = a + (b - a) * i / count;
            points[i] = new PointF((float)x, (float)f(x));
        }
        return points;
    }

    private static TextBox Box(string value) => new() { Text = value, Width = 300 };
    private static TextBox Output() => new() { Multiline = true, ReadOnly = true, Width = 330, Height = 115, ScrollBars = ScrollBars.Vertical };
    private static DataGridView Grid() => new() { ReadOnly = true, AllowUserToAddRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
    private static Label Header(string text) => new() { Text = text, AutoSize = true, Font = new Font("Segoe UI", 12, FontStyle.Bold), Margin = new Padding(3, 8, 3, 12) };
    private static Control Field(string label, TextBox box)
    {
        var p = new Panel { Width = 320, Height = 52 };
        p.Controls.Add(new Label { Text = label, AutoSize = true, Location = new Point(0, 0) });
        box.Location = new Point(0, 22);
        p.Controls.Add(box);
        return p;
    }
    private static bool Read(TextBox box, out double value) =>
        double.TryParse(box.Text.Trim().Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out value)
        && double.IsFinite(value);
}

internal sealed class PlotPanel : Panel
{
    private PointF[][] _series = Array.Empty<PointF[]>();
    private string[] _names = Array.Empty<string>();
    private double _xmin, _xmax;
    public PlotPanel()
    {
        Dock = DockStyle.Fill;
        BackColor = Color.White;
        BorderStyle = BorderStyle.FixedSingle;
        DoubleBuffered = true;
        ResizeRedraw = true;
    }
    public void SetSeries(PointF[][] series, string[] names, double xmin, double xmax)
    {
        _series = series; _names = names; _xmin = xmin; _xmax = xmax;
        Invalidate();
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        int left = 55, right = Width - 20, top = 25, bottom = Height - 45;
        if (right <= left || bottom <= top) return;
        g.DrawLine(Pens.Black, left, bottom, right, bottom);
        g.DrawLine(Pens.Black, left, top, left, bottom);
        g.DrawString("x", Font, Brushes.Black, right - 12, bottom + 8);
        g.DrawString("y", Font, Brushes.Black, left - 25, top - 8);
        if (_series.Length == 0) return;

        double ymin = double.PositiveInfinity, ymax = double.NegativeInfinity;
        foreach (var s in _series) foreach (var p in s) { ymin = Math.Min(ymin, p.Y); ymax = Math.Max(ymax, p.Y); }
        if (!double.IsFinite(ymin) || !double.IsFinite(ymax)) return;
        if (Math.Abs(ymax - ymin) < 1e-12) { ymin -= 1; ymax += 1; }
        double pad = (ymax - ymin) * 0.08; ymin -= pad; ymax += pad;
        for (int k = 0; k <= 5; k++)
        {
            float px = left + (right - left) * k / 5f;
            float py = top + (bottom - top) * k / 5f;
            g.DrawLine(Pens.Gainsboro, px, top, px, bottom);
            g.DrawLine(Pens.Gainsboro, left, py, right, py);
            double xv = _xmin + (_xmax - _xmin) * k / 5.0;
            double yv = ymax - (ymax - ymin) * k / 5.0;
            g.DrawString(xv.ToString("G4"), Font, Brushes.Black, px - 14, bottom + 5);
            g.DrawString(yv.ToString("G4"), Font, Brushes.Black, 2, py - 8);
        }
        Color[] colors = { Color.RoyalBlue, Color.Firebrick, Color.ForestGreen, Color.DarkOrange };
        for (int j = 0; j < _series.Length; j++)
        {
            var pts = new PointF[_series[j].Length];
            for (int i = 0; i < pts.Length; i++)
            {
                double xx = ( _series[j][i].X - _xmin) / (_xmax - _xmin);
                double yy = (_series[j][i].Y - ymin) / (ymax - ymin);
                pts[i] = new PointF((float)(left + xx * (right - left)), (float)(bottom - yy * (bottom - top)));
            }
            using var pen = new Pen(colors[j % colors.Length], 2);
            if (pts.Length > 1) g.DrawLines(pen, pts);
            else if (pts.Length == 1) g.FillEllipse(new SolidBrush(colors[j % colors.Length]), pts[0].X - 4, pts[0].Y - 4, 8, 8);
            if (j < _names.Length) g.DrawString(_names[j], Font, new SolidBrush(colors[j % colors.Length]), left + 8, top + 5 + j * 18);
        }
    }
}

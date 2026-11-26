using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace GraphPlotter;

/// <summary>Кривая y = F(x).</summary>
public record Curve(Func<double, double> F, Color Color);

/// <summary>Набор точек (при Line = true соединяются линией).</summary>
public record PointSet(List<(double X, double Y)> Points, Color Color, float Radius = 3.5f, bool Line = false);

/// <summary>Отдельная отмеченная точка: кружок или звёздочка.</summary>
public record Marker(double X, double Y, Color Color, bool Star = false);

/// <summary>
/// Область построения графиков: сетка, оси, кривые, наборы точек, маркеры.
/// Колесо мыши — масштаб (к точке под курсором), перетаскивание левой кнопкой — сдвиг.
/// Начало координат по умолчанию — в центре. Шаг сетки и число знаков подбираются
/// автоматически, поэтому масштабировать можно до десятитысячных и мельче.
/// </summary>
public class GraphControl : Control
{
    double cx, cy;            // мировые координаты центра области
    double scale = 40;        // пикселей на единицу
    bool panning;
    Point panStart;
    double panCx, panCy;

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public List<Curve> Curves { get; } = new();

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public List<PointSet> PointSets { get; } = new();

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public List<Marker> Markers { get; } = new();

    public GraphControl()
    {
        DoubleBuffered = true;
        ResizeRedraw = true;
    }

    public void ClearAll()
    {
        Curves.Clear();
        PointSets.Clear();
        Markers.Clear();
        Invalidate();
    }

    public void ResetView() => CenterAndZoom(0, 0, 40);

    public void CenterAndZoom(double x, double y, double pixelsPerUnit)
    {
        cx = x;
        cy = y;
        scale = Math.Clamp(pixelsPerUnit, 1e-6, 1e12);
        Invalidate();
    }

    /// <summary>Подбирает центр и масштаб так, чтобы все точки поместились в окно.</summary>
    public void FitTo(IEnumerable<(double X, double Y)> points)
    {
        var list = points.ToList();
        if (list.Count == 0) { ResetView(); return; }
        double minX = list.Min(p => p.X), maxX = list.Max(p => p.X);
        double minY = list.Min(p => p.Y), maxY = list.Max(p => p.Y);
        double w = Math.Max(Width, 300), h = Math.Max(Height, 200);
        double sx = w * 0.8 / Math.Max(maxX - minX, 1e-9);
        double sy = h * 0.8 / Math.Max(maxY - minY, 1e-9);
        CenterAndZoom((minX + maxX) / 2, (minY + maxY) / 2, Math.Min(sx, sy));
    }

    // ---------- координаты ----------
    float SX(double x) => (float)(Width / 2.0 + (x - cx) * scale);
    float SY(double y) => (float)(Height / 2.0 - (y - cy) * scale);
    double WX(double px) => cx + (px - Width / 2.0) / scale;
    double WY(double py) => cy - (py - Height / 2.0) / scale;
    static bool Ok(float v) => Math.Abs(v) < 1e7;   // false для NaN, бесконечностей и огромных значений

    // ---------- мышь ----------
    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        Focus();   // чтобы колесо мыши работало без предварительного щелчка
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
        base.OnMouseWheel(e);
        double wx = WX(e.X), wy = WY(e.Y);
        scale = Math.Clamp(scale * (e.Delta > 0 ? 1.2 : 1 / 1.2), 1e-6, 1e12);
        cx = wx - (e.X - Width / 2.0) / scale;      // точка под курсором остаётся на месте
        cy = wy + (e.Y - Height / 2.0) / scale;
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button != MouseButtons.Left) return;
        panning = true;
        panStart = e.Location;
        panCx = cx;
        panCy = cy;
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (!panning) return;
        cx = panCx - (e.X - panStart.X) / scale;
        cy = panCy + (e.Y - panStart.Y) / scale;
        Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        panning = false;
    }

    // ---------- рисование ----------
    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(Color.White);
        DrawAxes(g);
        foreach (var c in Curves) DrawCurve(g, c);
        foreach (var s in PointSets) DrawPoints(g, s);
        foreach (var m in Markers) DrawMarker(g, m);
    }

    /// <summary>«Красивый» шаг сетки 1, 2 или 5 · 10^n, ближайший к желаемому.</summary>
    static double NiceStep(double raw)
    {
        double p = Math.Pow(10, Math.Floor(Math.Log10(raw)));
        double f = raw / p;
        return (f < 1.5 ? 1 : f < 3.5 ? 2 : f < 7.5 ? 5 : 10) * p;
    }

    void DrawAxes(Graphics g)
    {
        double step = NiceStep(80 / scale);
        string fmt = "F" + Math.Max(0, (int)Math.Ceiling(-Math.Log10(step) - 1e-9));   // знаков после запятой
        float ax = Math.Clamp(SX(0), 0, Math.Max(0, Width - 45));    // оси прижимаются к краю,
        float ay = Math.Clamp(SY(0), 0, Math.Max(0, Height - 18));   // если начало координат ушло за экран

        using var grid = new Pen(Color.Gainsboro);
        using var axis = new Pen(Color.Black, 1.5f);
        using var font = new Font(Font.FontFamily, 8f);

        for (long i = (long)Math.Ceiling(WX(0) / step); i <= (long)Math.Floor(WX(Width) / step); i++)
        {
            float sx = SX(i * step);
            g.DrawLine(grid, sx, 0, sx, Height);
            g.DrawString((i * step).ToString(fmt, CultureInfo.InvariantCulture), font, Brushes.Black, sx + 2, ay + 2);
        }
        for (long i = (long)Math.Ceiling(WY(Height) / step); i <= (long)Math.Floor(WY(0) / step); i++)
        {
            float sy = SY(i * step);
            g.DrawLine(grid, 0, sy, Width, sy);
            g.DrawString((i * step).ToString(fmt, CultureInfo.InvariantCulture), font, Brushes.Black, ax + 3, sy - 12);
        }
        g.DrawLine(axis, 0, ay, Width, ay);
        g.DrawLine(axis, ax, 0, ax, Height);
        g.DrawString("x", font, Brushes.Black, Width - 12, ay - 14);
        g.DrawString("y", font, Brushes.Black, ax + 5, 2);
    }

    void DrawCurve(Graphics g, Curve curve)
    {
        using var pen = new Pen(curve.Color, 2);
        var seg = new List<PointF>();
        for (int px = 0; px <= Width; px++)
        {
            double y;
            try { y = curve.F(WX(px)); } catch { y = double.NaN; }
            float sy = (float)Math.Clamp(SY(y), -1e8, 1e8);   // NaN остаётся NaN
            bool ok = Ok(sy);
            // разрыв функции: пропуск или слишком резкий скачок — начинаем новый отрезок
            if (!ok || (seg.Count > 0 && Math.Abs(sy - seg[^1].Y) > Height * 4))
            {
                if (seg.Count > 1) g.DrawLines(pen, seg.ToArray());
                seg.Clear();
            }
            if (ok) seg.Add(new PointF(px, sy));
        }
        if (seg.Count > 1) g.DrawLines(pen, seg.ToArray());
    }

    void DrawPoints(Graphics g, PointSet set)
    {
        using var brush = new SolidBrush(set.Color);
        using var pen = new Pen(set.Color, 2);
        var pts = set.Points.Select(p => new PointF(SX(p.X), SY(p.Y))).Where(p => Ok(p.X) && Ok(p.Y)).ToArray();
        if (set.Line && pts.Length > 1) g.DrawLines(pen, pts);
        foreach (var p in pts)
            g.FillEllipse(brush, p.X - set.Radius, p.Y - set.Radius, 2 * set.Radius, 2 * set.Radius);
    }

    void DrawMarker(Graphics g, Marker m)
    {
        float x = SX(m.X), y = SY(m.Y);
        if (!Ok(x) || !Ok(y)) return;
        if (m.Star)
        {
            using var pen = new Pen(m.Color, 3);
            for (int k = 0; k < 3; k++)    // три пересекающиеся линии = звёздочка
            {
                double t = k * Math.PI / 3;
                float dx = (float)(9 * Math.Cos(t)), dy = (float)(9 * Math.Sin(t));
                g.DrawLine(pen, x - dx, y - dy, x + dx, y + dy);
            }
        }
        else
        {
            using var brush = new SolidBrush(m.Color);
            g.FillEllipse(brush, x - 6, y - 6, 12, 12);
            g.DrawEllipse(Pens.Black, x - 6, y - 6, 12, 12);
        }
    }
}

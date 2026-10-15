using System.Text;

namespace GraphPlotter;

/// <summary>
/// Численные методы лабораторных работ 2–6. Всё написано вручную, без математических
/// библиотек; из стандартной библиотеки используются только элементарные функции Math.*.
/// </summary>
static class Methods
{
    const int MaxIterations = 200;

    // =====================================================================
    // Лаб. 2. Корень уравнения f(x) = 0 методом парабол.
    // На отрезке [x0, x2] со сменой знака через точки x0, x1 = середина, x2 строится
    // парабола, берётся её корень внутри отрезка, и по знаку f отрезок сужается.
    // =====================================================================
    public static double ParabolaRoot(Func<double, double> f, double a, double b, double eps,
                                      StringBuilder log, out int iterations)
    {
        if (a > b) (a, b) = (b, a);
        double x0 = a, x2 = b, f0 = f(x0), f2 = f(x2);
        if (double.IsNaN(f0) || double.IsNaN(f2))
            throw new ArgumentException("Функция не определена на конце отрезка.");
        if (f0 * f2 > 0)
            throw new ArgumentException("На концах отрезка f(a) и f(b) одного знака — отрезок не локализует корень.\nПодберите [a, b] по графику.");

        log.AppendLine("  №          x0          x1          x2       x_new      f(x_new)");
        for (iterations = 1; iterations <= MaxIterations; iterations++)
        {
            double x1 = (x0 + x2) / 2, f1 = f(x1);
            double xn = ParabolaZero(x0, f0, x1, f1, x2, f2), fn = f(xn);
            if (double.IsNaN(fn)) throw new ArgumentException("Функция не определена в промежуточной точке.");
            log.AppendLine($"{iterations,3}{Util.F(x0),12}{Util.F(x1),12}{Util.F(x2),12}{Util.F(xn),12}{Util.F(fn, "0.00e+0"),13}");

            if (Math.Abs(fn) < eps || x2 - x0 < eps) return xn;
            if (f0 * fn < 0) { x2 = xn; f2 = fn; }
            else { x0 = xn; f0 = fn; }
        }
        throw new InvalidOperationException($"Точность не достигнута за {MaxIterations} итераций.");
    }

    /// <summary>Нуль параболы через три точки (в переменной t = x − x1); при вырождении — секущая.</summary>
    static double ParabolaZero(double x0, double f0, double x1, double f1, double x2, double f2)
    {
        double t0 = x0 - x1, t2 = x2 - x1;                          // парабола f1 + B·t + A·t²
        double A = ((f2 - f1) / t2 - (f0 - f1) / t0) / (t2 - t0);
        double B = (f2 - f1) / t2 - A * t2;
        double secant = x0 - f0 * (x2 - x0) / (f2 - f0);
        double d = B * B - 4 * A * f1;
        if (Math.Abs(A) < 1e-14 || d < 0) return secant;

        double s = Math.Sqrt(d);
        double r1 = x1 + (-B + s) / (2 * A), r2 = x1 + (-B - s) / (2 * A);
        bool in1 = r1 >= x0 && r1 <= x2, in2 = r2 >= x0 && r2 <= x2;
        if (in1 && in2) return Math.Abs(r1 - x1) < Math.Abs(r2 - x1) ? r1 : r2;
        return in1 ? r1 : in2 ? r2 : secant;
    }

    // =====================================================================
    // Лаб. 3. Экстремум методом парабол (последовательная параболическая интерполяция).
    // Максимум ищется как минимум функции −f. Нужен отрезок унимодальности [a, b].
    // =====================================================================
    public static double ParabolaExtremum(Func<double, double> f, double a, double b, double eps, bool max,
                                          StringBuilder log, out int iterations)
    {
        if (a > b) (a, b) = (b, a);
        double sign = max ? -1 : 1;
        double x0 = a, x1 = (a + b) / 2, x2 = b;
        double g0 = sign * f(x0), g1 = sign * f(x1), g2 = sign * f(x2);
        if (double.IsNaN(g0 + g1 + g2))
            throw new ArgumentException("Функция не определена на отрезке.");
        if (!(g1 <= g0 && g1 <= g2))
            throw new ArgumentException($"Условие унимодальности не выполнено: в середине отрезка значение должно быть {(max ? "больше" : "меньше")}, чем на его концах.\nПодберите [a, b] по графику.");

        log.AppendLine("  №          x0          x1          x2       x_new      f(x_new)");
        for (iterations = 1; iterations <= MaxIterations; iterations++)
        {
            // парабола g1 + B·t + A·t², t = x − x1; вершина t = −B / (2A)
            double t0 = x0 - x1, t2 = x2 - x1;
            double A = ((g2 - g1) / t2 - (g0 - g1) / t0) / (t2 - t0);
            double B = (g2 - g1) / t2 - A * t2;
            double xn = Math.Abs(A) < 1e-14 ? (x0 + x2) / 2 : x1 - B / (2 * A);
            if (!(xn > x0 && xn < x2)) xn = (x0 + x2) / 2;          // вершина вне отрезка — берём середину
            double gn = sign * f(xn);
            if (double.IsNaN(gn)) throw new ArgumentException("Функция не определена в промежуточной точке.");
            log.AppendLine($"{iterations,3}{Util.F(x0),12}{Util.F(x1),12}{Util.F(x2),12}{Util.F(xn),12}{Util.F(sign * gn, "0.00e+0"),13}");

            if (Math.Abs(xn - x1) < eps || x2 - x0 < eps) return xn;

            // из четырёх точек оставляем три соседние, содержащие наименьшее g
            var pts = new List<(double X, double G)> { (x0, g0), (x1, g1), (x2, g2), (xn, gn) };
            pts.Sort((u, v) => u.X.CompareTo(v.X));
            int m = 0;
            for (int i = 1; i < 4; i++) if (pts[i].G < pts[m].G) m = i;
            int lo = m <= 1 ? 0 : 1;
            (x0, g0) = pts[lo];
            (x1, g1) = pts[lo + 1];
            (x2, g2) = pts[lo + 2];
        }
        throw new InvalidOperationException($"Точность не достигнута за {MaxIterations} итераций.");
    }

    // =====================================================================
    // Лаб. 4. Определитель методом Гаусса с выбором главного элемента по столбцу.
    // =====================================================================
    public static double GaussDeterminant(double[,] source, StringBuilder log)
    {
        int n = source.GetLength(0);
        var m = (double[,])source.Clone();
        double det = 1;
        for (int k = 0; k < n; k++)
        {
            int p = k;                                               // строка с максимумом |m[i,k]|
            for (int i = k + 1; i < n; i++)
                if (Math.Abs(m[i, k]) > Math.Abs(m[p, k])) p = i;
            if (Math.Abs(m[p, k]) < 1e-12)
            {
                log.AppendLine($"Шаг {k + 1}: столбец нулевой — матрица вырождена.");
                return 0;
            }
            if (p != k)
            {
                for (int j = 0; j < n; j++) (m[k, j], m[p, j]) = (m[p, j], m[k, j]);
                det = -det;                                          // перестановка строк меняет знак
            }
            log.AppendLine($"Шаг {k + 1}: ведущий элемент {Util.F(m[k, k], "0.0000")}" +
                           (p != k ? $" (строки {k + 1} и {p + 1} переставлены)" : ""));
            det *= m[k, k];

            for (int i = k + 1; i < n; i++)
            {
                double factor = m[i, k] / m[k, k];
                for (int j = k + 1; j < n; j++) m[i, j] -= factor * m[k, j];
                m[i, k] = 0;
            }
            log.AppendLine(Util.Matrix(m));
        }
        return det;
    }

    /// <summary>Проверка: определитель разложением по первой строке (алгебраические дополнения).</summary>
    public static double CofactorDeterminant(double[,] a)
    {
        int n = a.GetLength(0);
        if (n == 1) return a[0, 0];
        double det = 0;
        for (int c = 0; c < n; c++)
        {
            var minor = new double[n - 1, n - 1];
            for (int i = 1; i < n; i++)
                for (int j = 0, jj = 0; j < n; j++)
                    if (j != c) minor[i - 1, jj++] = a[i, j];
            det += (c % 2 == 0 ? 1 : -1) * a[0, c] * CofactorDeterminant(minor);
        }
        return det;
    }

    // =====================================================================
    // Лаб. 5. СЛАУ методом релаксаций (SOR): x_i := (1−ω)·x_i + ω·(Зейдель).
    // Точность — по максимальной разнице компонент между соседними итерациями.
    // =====================================================================
    public static double[] Relaxation(double[,] a, double[] b, double omega, double eps,
                                      StringBuilder log, out int iterations)
    {
        int n = b.Length;
        for (int i = 0; i < n; i++)
            if (Math.Abs(a[i, i]) < 1e-14)
                throw new ArgumentException($"Диагональный элемент a[{i + 1},{i + 1}] равен нулю — нужна перестановка строк.");

        var x = new double[n];
        log.AppendLine("  №" + string.Concat(Enumerable.Range(1, n).Select(i => $"x{i}".PadLeft(12))) + "   max|Δx|");
        for (iterations = 1; iterations <= 10000; iterations++)
        {
            double maxDelta = 0;
            for (int i = 0; i < n; i++)
            {
                double sum = b[i];
                for (int j = 0; j < n; j++)
                    if (j != i) sum -= a[i, j] * x[j];              // x[j] при j < i уже обновлены
                double xi = (1 - omega) * x[i] + omega * sum / a[i, i];
                maxDelta = Math.Max(maxDelta, Math.Abs(xi - x[i]));
                x[i] = xi;
            }
            log.AppendLine($"{iterations,3}" + string.Concat(x.Select(v => Util.F(v).PadLeft(12))) + $"  {Util.F(maxDelta, "0.00e+0")}");

            if (double.IsNaN(maxDelta) || maxDelta > 1e12)
                throw new InvalidOperationException("Метод расходится при выбранном ω. Попробуйте ω = 1.");
            if (maxDelta < eps) return x;
        }
        throw new InvalidOperationException("Точность не достигнута за 10000 итераций.");
    }

    // =====================================================================
    // Лаб. 6. Аппроксимация.
    // =====================================================================

    /// <summary>Интерполяционный многочлен Лагранжа в барицентрической (устойчивой) форме.</summary>
    public static Func<double, double> Lagrange(double[] xs, double[] ys)
    {
        int n = xs.Length;
        var w = new double[n];
        for (int j = 0; j < n; j++)
        {
            w[j] = 1;
            for (int k = 0; k < n; k++)
                if (k != j) w[j] *= xs[j] - xs[k];
            w[j] = 1 / w[j];
        }
        return x =>
        {
            double num = 0, den = 0;
            for (int j = 0; j < n; j++)
            {
                double d = x - xs[j];
                if (Math.Abs(d) < 1e-14) return ys[j];
                double t = w[j] / d;
                num += t * ys[j];
                den += t;
            }
            return num / den;
        };
    }

    /// <summary>Коэффициенты прямых y = k·x + b на каждом отрезке [xs[i], xs[i+1]].</summary>
    public static (double[] K, double[] B) Lines(double[] xs, double[] ys)
    {
        int n = xs.Length - 1;
        var k = new double[n];
        var b = new double[n];
        for (int i = 0; i < n; i++)
        {
            k[i] = (ys[i + 1] - ys[i]) / (xs[i + 1] - xs[i]);
            b[i] = ys[i] - k[i] * xs[i];
        }
        return (k, b);
    }

    /// <summary>Значение кусочно-линейной функции: отрезок ищется бинарным поиском (быстро и для 10^5 точек).</summary>
    public static double EvalLines(double[] xs, double[] k, double[] b, double x)
    {
        int lo = 0, hi = xs.Length - 1;
        while (hi - lo > 1)
        {
            int mid = (lo + hi) / 2;
            if (xs[mid] <= x) lo = mid; else hi = mid;
        }
        return k[lo] * x + b[lo];
    }

    /// <summary>МНК-многочлен степени deg (нормальные уравнения); коэффициенты по возрастанию степеней.</summary>
    public static double[] PolyFit(double[] x, double[] y, int deg)
    {
        int m = deg + 1;
        var s = new double[2 * deg + 1];       // s[k] = Σ x^k
        var t = new double[m];                 // t[k] = Σ y·x^k
        for (int i = 0; i < x.Length; i++)
        {
            double pw = 1;
            for (int k = 0; k <= 2 * deg; k++)
            {
                s[k] += pw;
                if (k < m) t[k] += y[i] * pw;
                pw *= x[i];
            }
        }
        var a = new double[m, m];
        for (int i = 0; i < m; i++)
            for (int j = 0; j < m; j++) a[i, j] = s[i + j];
        return Solve(a, t);
    }

    public static double Poly(double[] c, double x)     // схема Горнера
    {
        double r = 0;
        for (int i = c.Length - 1; i >= 0; i--) r = r * x + c[i];
        return r;
    }

    /// <summary>y = a·e^(b·x): линеаризация ln y = ln a + b·x (точки с y ≤ 0 не используются).</summary>
    public static (double A, double B) FitExp(double[] x, double[] y)
    {
        var xs = new List<double>();
        var lny = new List<double>();
        for (int i = 0; i < x.Length; i++)
            if (y[i] > 0) { xs.Add(x[i]); lny.Add(Math.Log(y[i])); }
        if (xs.Count < 2) throw new InvalidOperationException("Для показательной модели нужно минимум 2 точки с y > 0.");
        var c = PolyFit(xs.ToArray(), lny.ToArray(), 1);
        return (Math.Exp(c[0]), c[1]);
    }

    /// <summary>y = a·ln(x) + b: линейная регрессия y от ln x (нужно x &gt; 0).</summary>
    public static (double A, double B) FitLog(double[] x, double[] y)
    {
        var c = PolyFit(Array.ConvertAll(x, v => Math.Log(v)), y, 1);
        return (c[1], c[0]);
    }

    /// <summary>Решение Ax = b методом Гаусса с выбором главного элемента.</summary>
    static double[] Solve(double[,] a, double[] b)
    {
        int n = b.Length;
        for (int k = 0; k < n; k++)
        {
            int p = k;
            for (int i = k + 1; i < n; i++)
                if (Math.Abs(a[i, k]) > Math.Abs(a[p, k])) p = i;
            if (Math.Abs(a[p, k]) < 1e-14) throw new InvalidOperationException("Вырожденная система нормальных уравнений.");
            if (p != k)
            {
                for (int j = 0; j < n; j++) (a[k, j], a[p, j]) = (a[p, j], a[k, j]);
                (b[k], b[p]) = (b[p], b[k]);
            }
            for (int i = k + 1; i < n; i++)
            {
                double f = a[i, k] / a[k, k];
                for (int j = k; j < n; j++) a[i, j] -= f * a[k, j];
                b[i] -= f * b[k];
            }
        }
        var x = new double[n];
        for (int i = n - 1; i >= 0; i--)
        {
            double sum = b[i];
            for (int j = i + 1; j < n; j++) sum -= a[i, j] * x[j];
            x[i] = sum / a[i, i];
        }
        return x;
    }
}

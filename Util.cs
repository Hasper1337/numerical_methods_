using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace GraphPlotter;

/// <summary>Мелкие общие помощники для вкладок.</summary>
static class Util
{
    /// <summary>СЛАУ из задания (лаб. 4 и 5): [A | b], по строке на уравнение.</summary>
    public static readonly string DefaultSystem = string.Join(Environment.NewLine, new[]
    {
        "53.56    0.91   -1.28   -2.74    6.84",
        "-8.02  -35.43    4.15    7.39   -1.67",
        "1.73    -4.22  -39.51   -0.52    3.96",
        "6.47     2.55   -3.88  -45.19   -0.41"
    });

    /// <summary>true, пока форма открыта в конструкторе Visual Studio (там не надо ничего считать).</summary>
    public static bool InDesigner => LicenseManager.UsageMode == LicenseUsageMode.Designtime;

    /// <summary>Число с точкой или запятой в качестве десятичного разделителя.</summary>
    public static bool TryNum(string s, out double v) =>
        double.TryParse(s.Trim().Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out v);

    public static double Num(TextBox box, string name) =>
        TryNum(box.Text, out double v) ? v : throw new FormatException($"Некорректное число в поле «{name}».");

    /// <summary>Разбирает формулу и сразу проверяет её синтаксис.</summary>
    public static Func<double, double> Compile(string formula)
    {
        var parser = new ExpressionEvaluator(formula);
        parser.Evaluate(1.2345);
        return parser.Evaluate;
    }

    public static string F(double v, string format = "0.000000") => v.ToString(format, CultureInfo.InvariantCulture);

    /// <summary>Выполняет действие; ошибки ввода и метода показывает окном сообщения.</summary>
    public static void Try(Action action)
    {
        try { action(); }
        catch (Exception ex) when (ex is FormatException or ArgumentException or InvalidOperationException)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    /// <summary>Строки чисел, разделённых пробелом, табуляцией или «;». В каждой строке — не менее minColumns чисел.</summary>
    public static double[][] ParseRows(string text, int minColumns)
    {
        var rows = new List<double[]>();
        foreach (var line in text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
        {
            var tokens = line.Split(new[] { ' ', '\t', ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 0) continue;
            if (tokens.Length < minColumns)
                throw new FormatException($"В строке {rows.Count + 1} должно быть не менее {minColumns} чисел.");
            var row = new double[tokens.Length];
            for (int j = 0; j < tokens.Length; j++)
                if (!TryNum(tokens[j], out row[j]))
                    throw new FormatException($"Не число: «{tokens[j]}» (строка {rows.Count + 1}).");
            rows.Add(row);
        }
        return rows.ToArray();
    }

    /// <summary>Матрица в виде выровненного текста.</summary>
    public static string Matrix(double[,] m)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
                sb.Append(F(m[i, j], "0.0000").PadLeft(11));
            sb.AppendLine();
        }
        return sb.ToString();
    }
}

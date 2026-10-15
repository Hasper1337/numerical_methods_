using System.Globalization;

namespace GraphPlotter;

/// <summary>
/// Вычисляет формулу f(x): + - * / ^, скобки, неявное умножение (2x, 3(x+1)),
/// функции sin cos tg ctg arcsin arccos arctg sqrt ln lg exp abs, константы pi и e.
/// Ошибки в формуле — FormatException с понятным сообщением.
/// </summary>
public class ExpressionEvaluator
{
    readonly string s;
    int p;
    double x;

    public ExpressionEvaluator(string formula)
    {
        s = formula.Replace(" ", "").Replace(',', '.').ToLowerInvariant();
        if (s.Length == 0) throw new FormatException("Формула пуста.");
    }

    public double Evaluate(double xValue)
    {
        x = xValue;
        p = 0;
        double v = Sum();
        if (p < s.Length) throw new FormatException($"Неожиданный символ «{s[p]}» в позиции {p + 1}.");
        return v;
    }

    char Peek => p < s.Length ? s[p] : '\0';

    // Sum := Product (('+' | '-') Product)*
    double Sum()
    {
        double v = Product();
        while (Peek is '+' or '-')
        {
            char op = s[p++];
            double r = Product();
            v = op == '+' ? v + r : v - r;
        }
        return v;
    }

    // Product := Unary (('*' | '/' | неявное умножение) Unary)*
    double Product()
    {
        double v = Unary();
        while (true)
        {
            if (Peek == '*') { p++; v *= Unary(); }
            else if (Peek == '/') { p++; v /= Unary(); }
            else if (char.IsLetterOrDigit(Peek) || Peek is '(' or '.') v *= Unary();   // 2x, 3(x+1)
            else return v;
        }
    }

    // Unary := ('-' | '+') Unary | Power        (так что -x^2 = -(x^2))
    double Unary()
    {
        if (Peek == '-') { p++; return -Unary(); }
        if (Peek == '+') { p++; return Unary(); }
        return Power();
    }

    // Power := Atom ('^' Unary)?                (правоассоциативно)
    double Power()
    {
        double b = Atom();
        if (Peek != '^') return b;
        p++;
        return Math.Pow(b, Unary());
    }

    double Atom()
    {
        if (Peek == '(')
        {
            p++;
            double v = Sum();
            Expect(')');
            return v;
        }
        if (char.IsDigit(Peek) || Peek == '.')
        {
            int start = p;
            while (char.IsDigit(Peek) || Peek == '.') p++;
            string text = s[start..p];
            return double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out double num)
                ? num
                : throw new FormatException($"Некорректное число «{text}».");
        }
        if (char.IsLetter(Peek))
        {
            int start = p;
            while (char.IsLetter(Peek)) p++;
            string name = s[start..p];
            bool isConstant = name is "x" or "pi" or "e";
            if (Peek == '(' && !isConstant)
            {
                p++;
                double arg = Sum();
                Expect(')');
                return Apply(name, arg);
            }
            return name switch
            {
                "x" => x,
                "pi" => Math.PI,
                "e" => Math.E,
                _ => throw new FormatException($"Неизвестный идентификатор «{name}».")
            };
        }
        throw new FormatException(p < s.Length
            ? $"Неожиданный символ «{s[p]}» в позиции {p + 1}."
            : "Неожиданный конец формулы.");
    }

    static double Apply(string name, double a) => name switch
    {
        "sin" => Math.Sin(a),
        "cos" => Math.Cos(a),
        "tg" or "tan" => Math.Tan(a),
        "ctg" or "cot" => 1 / Math.Tan(a),
        "asin" or "arcsin" => Math.Asin(a),
        "acos" or "arccos" => Math.Acos(a),
        "atan" or "arctan" or "arctg" => Math.Atan(a),
        "sqrt" => Math.Sqrt(a),
        "ln" => Math.Log(a),
        "lg" or "log" => Math.Log10(a),
        "exp" => Math.Exp(a),
        "abs" => Math.Abs(a),
        _ => throw new FormatException($"Неизвестная функция «{name}».")
    };

    void Expect(char c)
    {
        if (Peek != c) throw new FormatException($"Ожидалась «{c}» в позиции {p + 1}.");
        p++;
    }
}

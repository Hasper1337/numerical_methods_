using System.Text;

namespace GraphPlotter;

/// <summary>Лаб. 5: решение той же СЛАУ методом релаксаций (SOR), точность по max|Δx_i| между итерациями.</summary>
public partial class Lab5Control : UserControl
{
    public Lab5Control()
    {
        InitializeComponent();
        txtMatrix.Text = Util.DefaultSystem;
    }

    void btnDefault_Click(object sender, EventArgs e) => txtMatrix.Text = Util.DefaultSystem;

    void btnSolve_Click(object sender, EventArgs e) => Util.Try(() =>
    {
        var rows = Util.ParseRows(txtMatrix.Text, 5);
        if (rows.Length != 4) throw new FormatException("Нужно ровно 4 строки (по 5 чисел: A | b).");
        double omega = Util.Num(txtOmega, "ω"), eps = Util.Num(txtEps, "ε");
        if (omega <= 0 || omega >= 2) throw new ArgumentException("Параметр ω должен лежать в интервале (0, 2).");
        if (eps <= 0) throw new ArgumentException("ε должно быть положительным.");

        var a = new double[4, 4];
        var b = new double[4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++) a[i, j] = rows[i][j];
            b[i] = rows[i][4];
        }

        var log = new StringBuilder();
        double[] x = Methods.Relaxation(a, b, omega, eps, log, out int iterations);

        log.AppendLine();
        log.AppendLine("Решение (столбец x):");
        for (int i = 0; i < 4; i++) log.AppendLine($"  x{i + 1} = {Util.F(x[i])}");
        log.AppendLine();
        log.AppendLine("Невязка r = A·x − b:");
        for (int i = 0; i < 4; i++)
        {
            double r = -b[i];
            for (int j = 0; j < 4; j++) r += a[i, j] * x[j];
            log.AppendLine($"  r{i + 1} = {Util.F(r, "0.00e+0")}");
        }
        log.AppendLine();
        log.AppendLine($"Число итераций: {iterations}");
        txtOutput.Text = log.ToString();
    });
}

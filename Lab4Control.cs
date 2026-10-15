using System.Text;

namespace GraphPlotter;

/// <summary>Лаб. 4, вариант 1: определитель методом Гаусса с выбором главного элемента по столбцу.</summary>
public partial class Lab4Control : UserControl
{
    public Lab4Control()
    {
        InitializeComponent();
        txtMatrix.Text = Util.DefaultSystem;
    }

    void btnDefault_Click(object sender, EventArgs e) => txtMatrix.Text = Util.DefaultSystem;

    void btnCompute_Click(object sender, EventArgs e) => Util.Try(() =>
    {
        var rows = Util.ParseRows(txtMatrix.Text, 4);
        if (rows.Length != 4) throw new FormatException("Нужно ровно 4 строки.");
        var a = new double[4, 4];
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++) a[i, j] = rows[i][j];      // 5-й столбец (b) не используется

        var log = new StringBuilder();
        log.AppendLine("Матрица A:");
        log.AppendLine(Util.Matrix(a));
        log.AppendLine("Метод Гаусса с выбором главного элемента по столбцу:");
        log.AppendLine();
        double det = Methods.GaussDeterminant(a, log);
        double check = Methods.CofactorDeterminant(a);

        log.AppendLine("=== Результат ===");
        log.AppendLine($"Определитель (метод Гаусса):         {Util.F(det, "0.######")}");
        log.AppendLine($"Проверка (разложение по минорам):    {Util.F(check, "0.######")}");
        log.AppendLine($"Расхождение:                         {Util.F(Math.Abs(det - check), "0.0e+0")}");
        txtOutput.Text = log.ToString();
    });
}

namespace WtLab4Korbut.Models;

public class Loan
{
    public int Id { get; set; }
    public string BorrowerName { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public decimal Rate { get; set; }
    public int TermMonths { get; set; }

    public decimal MonthlyPayment()
    {
        var m = Rate / 12m;
        if (m == 0) return Amount / TermMonths;
        var k = (double)m * Math.Pow(1 + (double)m, TermMonths) /
                (Math.Pow(1 + (double)m, TermMonths) - 1);
        return Amount * (decimal)k;
    }
}

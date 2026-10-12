namespace WtLab4Korbut.Models;

public enum TransactionKind { Deposit, Withdraw, Transfer }

public class Transaction
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public decimal Amount { get; set; }
    public TransactionKind Kind { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}

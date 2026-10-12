namespace WtLab4Korbut.Models;

public enum AccountType
{
    Savings,    // сберегательный
    Checking,   // текущий
    Deposit     // срочный вклад
}

public class Account
{
    public int Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
    public AccountType Type { get; set; }
    public decimal Balance { get; set; }
    public decimal InterestRate { get; set; }
    public bool IsActive { get; set; } = true;
}
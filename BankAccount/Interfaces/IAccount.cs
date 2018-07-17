namespace BankAccount
{
    /// <summary>
    /// Represents basic operations for implementation for account classes 
    /// </summary>
    public interface IAccount
    {
        string AccountNumber { get; set; }
        Holder AccountHolder {get;set;}
        AccountStatus Status { get; set; }
        decimal Balance { get; set; }

        void Deposit(decimal amount);

        void Wirthdraw(decimal amount);

        void CloseAccount();
    }
}

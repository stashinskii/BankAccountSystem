using BankAccount.Core.Interfaces;
using System;

namespace BankAccount.Core
{
    /// <summary>
    /// Represents basic operations for implementation for account classes 
    /// </summary>
    public abstract class Account
    {
        protected double BonusPointsCoefficient { get; set; }

        public AccountStatus Status { get; set; }
        public Holder AccountHolder { get; set; }
        public AccountType Type { get; set; }

        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public int BonusPoints { get; set; }

        #region Constructors
        protected Account(IAccountNumberGenerator numberGenerator, Holder customer)
        {
            AccountNumber = numberGenerator.GenerateAccountNumber(Guid.NewGuid().ToString());
            AccountHolder = customer;
            BonusPoints = 30;
            Status = AccountStatus.Opened;
        }

        protected Account(IAccountNumberGenerator numberGenerator, string name, string surname, string email, string passport = null)
        {
            AccountNumber = numberGenerator.GenerateAccountNumber(Guid.NewGuid().ToString());
            AccountHolder = new Holder(name, surname, email, passport);
            BonusPoints = 30;
            Status = AccountStatus.Opened;
        }
        #endregion

        public void Deposit(decimal amount)
        {
            CheckStatus();
            Balance += amount;
            BonusPoints += IncomeExtraPoint(amount);
        }


        public void Wirthdraw(decimal amount)
        {
            CheckStatus();
            if ((Balance - amount) < 0)
            {
                throw new InvalidAccountOperationException("You don't have enough money for that!");
            }
            Balance -= amount;
            BonusPoints -= OutcomeExtraPoint(amount);
        }

        public void CloseAccount()
        {
            CheckStatus();
            Balance = 0;
            BonusPoints = 0;
            Status = AccountStatus.Closed;
        }

        public void CheckStatus()
        {
            if (Status == AccountStatus.Closed)
                throw new InvalidAccountOperationException("Account is closed");
        }

        private int IncomeExtraPoint(decimal amount)
        {
            return (int)(BonusPointsCoefficient * (int)amount);
        }

        private int OutcomeExtraPoint(decimal amount)
        {
            return (int)(BonusPointsCoefficient * (int)amount) / 2;
        }
    }
}

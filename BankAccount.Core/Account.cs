using BankAccount.Core.Interfaces;
using System;

namespace BankAccount.Core
{
    /// <summary>
    /// Represents basic operations for implementation for account classes 
    /// </summary>
    public abstract class Account
    {
        #region Properties
        protected double BonusPointsCoefficient { get; set; }
        protected decimal MinimumBalance { get; set; }

        public AccountStatus Status { get; set; }
        public Holder AccountHolder { get; set; }
        public AccountType Type { get; set; }

        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public int BonusPoints { get; set; }
        #endregion

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

        #region Public methods
        /// <summary>
        /// Income of money
        /// </summary>
        /// <param name="amount">Amount of income money</param>
        public void Deposit(decimal amount)
        {
            CheckStatus();
            Balance += amount;
            BonusPoints += IncomeExtraPoint(amount);
        }

        /// <summary>
        /// Outcome of money
        /// </summary>
        /// <param name="amount">Amount of outcome money</param>
        public void Wirthdraw(decimal amount)
        {
            CheckStatus();
            if ((Balance - amount) < MinimumBalance)
            {
                throw new InvalidAccountOperationException("You don't have enough money for that!");
            }
            Balance -= amount;
            BonusPoints -= OutcomeExtraPoint(amount);
        }

        /// <summary>
        /// Close given account. Propery of Status will get into AccountStatus.Closed state
        /// </summary>
        public void CloseAccount()
        {
            CheckStatus();
            Balance = 0;
            BonusPoints = 0;
            Status = AccountStatus.Closed;
        }
        #endregion

        #region Privtae methods
        /// <summary>
        /// Get amount of bonus points for deposit operation
        /// </summary>
        /// <param name="amount">Amount of money</param>
        /// <returns>Amount of bonus points</returns>
        private int IncomeExtraPoint(decimal amount)
        {
            return (int)(BonusPointsCoefficient * (int)amount);
        }

        /// <summary>
        /// Get amount of bonus points for wirthdraw operation
        /// </summary>
        /// <param name="amount">Amount of money</param>
        /// <returns>Amount of bonus points</returns>
        private int OutcomeExtraPoint(decimal amount)
        {
            return (int)(BonusPointsCoefficient * (int)amount) / 2;
        }

        /// <summary>
        /// Checks if account is closed or frozen
        /// </summary>
        private void CheckStatus()
        {
            if (Status == AccountStatus.Closed || Status == AccountStatus.Frozen)
                throw new InvalidAccountOperationException("Account is closed");
        }
        #endregion
    }
}

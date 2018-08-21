using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Services;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Represents basic operations for implementation for account classes 
    /// </summary>
    public class AccountEntity
    {
        #region Properties
        protected double BonusPointsCoefficient { get; set; }
        protected decimal MinimumBalance { get; set; }

        public HolderEntity AccountHolder { get; set; }

        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public int BonusPoints { get; set; }
        #endregion

        #region Constructors
        public AccountEntity()
        {

        }

        public AccountEntity(HolderEntity customer)
        {
            AccountHolder = customer;
            BonusPoints = 30;
        }

        public AccountEntity(string name, string surname, string email, string passport = null)
        {
            AccountHolder = new HolderEntity(name, email);
            BonusPoints = 30;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Income of money
        /// </summary>
        /// <param name="amount">Amount of income money</param>
        public void Deposit(decimal amount)
        {
            Balance += amount;
            BonusPoints += IncomeExtraPoint(amount);
        }

        /// <summary>
        /// Outcome of money
        /// </summary>
        /// <param name="amount">Amount of outcome money</param>
        public void Wirthdraw(decimal amount)
        {
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
            Balance = 0;
            BonusPoints = 0;
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
        #endregion
    }
}

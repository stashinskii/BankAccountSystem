using System;
using BankAccount.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Core
{
    /// <summary>
    /// Represents acount of Golden type. Implements AbstactAccount class for managing basic actions and
    /// operation with account
    /// </summary>
    public class GoldAccount: Account
    {
        private const double bonusCoefficient = 0.2;

        #region Contructors
        public GoldAccount(IAccountNumberGenerator numberGenerator, Holder customer) : base(numberGenerator, customer)
        {
            Type = AccountType.Gold;
            BonusPointsCoefficient = bonusCoefficient;
        }

        public GoldAccount(IAccountNumberGenerator numberGenerator, string name, string surname, string email, string passport = null) : base(numberGenerator, name, surname, email, passport)
        {
            Type = AccountType.Gold;
            BonusPointsCoefficient = bonusCoefficient;
        }
        #endregion
    }
}

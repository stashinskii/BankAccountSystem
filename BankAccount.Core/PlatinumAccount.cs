using System;
using BankAccount.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Core
{

    /// <summary>
    /// Represents acount of Platinum type. Implements AbstactAccount class for managing basic actions and
    /// operation with account
    /// </summary>
    public class PlatinumAccount : Account
    {
        private const double bonusCoefficient = 0.3;
        private const decimal MINIMUM = -1000;

        #region Constructors
        public PlatinumAccount(IAccountNumberGenerator numberGenerator, Holder customer) : base(numberGenerator, customer)
        {
            Type = AccountType.Platinum;
            BonusPointsCoefficient = bonusCoefficient;
            MinimumBalance = MINIMUM;
        }

        public PlatinumAccount(IAccountNumberGenerator numberGenerator, string name, string surname, string email, string passport = null) : base(numberGenerator, name, surname, email, passport)
        {
            Type = AccountType.Platinum;
            BonusPointsCoefficient = bonusCoefficient;
            MinimumBalance = MINIMUM;
        }
        #endregion
    }
}

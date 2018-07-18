using System;
using BankAccount.Core.Interfaces;
using System.Text.RegularExpressions;

namespace BankAccount.Core
{
    /// <summary>
    /// Represents acount. Implements AbstactAccount class for managing basic actions and
    /// operation with account
    /// </summary>
    public class BaseAccount: Account
    {
        private const double bonusCoefficient = 0.1; 

        public BaseAccount(IAccountNumberGenerator numberGenerator, Holder customer) : base(numberGenerator, customer)
        {
            Type = AccountType.Base;
            BonusPointsCoefficient = bonusCoefficient;
        }

        public BaseAccount(IAccountNumberGenerator numberGenerator, string name, string surname, string email, string passport = null) : base(numberGenerator, name, surname, email, passport)
        {
            Type = AccountType.Base;
            BonusPointsCoefficient = bonusCoefficient;
        }
    }
}

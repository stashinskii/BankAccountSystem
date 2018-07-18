using System;
using BankAccount.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Core
{
    public class PlatinumAccount : Account
    {
        private const double bonusCoefficient = 0.3;

        public PlatinumAccount(IAccountNumberGenerator numberGenerator, Holder customer) : base(numberGenerator, customer)
        {
            Type = AccountType.Platinum;
            BonusPointsCoefficient = bonusCoefficient;
        }

        public PlatinumAccount(IAccountNumberGenerator numberGenerator, string name, string surname, string email, string passport = null) : base(numberGenerator, name, surname, email, passport)
        {
            Type = AccountType.Platinum;
            BonusPointsCoefficient = bonusCoefficient;
        }
    }
}

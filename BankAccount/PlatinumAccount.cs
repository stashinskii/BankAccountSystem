using System;
using BankAccount.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Core
{
    class PlatinumAccount : Account
    {
        public PlatinumAccount(IAccountNumberGenerator numberGenerator, Holder customer) : base(numberGenerator, customer)
        {
            Type = AccountType.Platinum;
        }

        public PlatinumAccount(IAccountNumberGenerator numberGenerator, string name, string surname, string email, string passport = null) : base(numberGenerator, name, surname, email, passport)
        {
            Type = AccountType.Platinum;
        }
    }
}

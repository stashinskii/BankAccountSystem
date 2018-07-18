using System;
using BankAccount.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Core
{
    class GoldAccount: Account
    {
        public GoldAccount(IAccountNumberGenerator numberGenerator, Holder customer) : base(numberGenerator, customer)
        {
            Type = AccountType.Gold;
        }

        public GoldAccount(IAccountNumberGenerator numberGenerator, string name, string surname, string email, string passport = null) : base(numberGenerator, name, surname, email, passport)
        {
            Type = AccountType.Gold;
        }
    }
}

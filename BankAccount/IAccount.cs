using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    interface IAccount
    {
        void Income(int amount);
        void Outcome(int amount);
        void CloseAccount();
    }
}

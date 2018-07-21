using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Core.Interfaces
{
    public interface IAccountNumberGenerator
    {
        int LastAccountNumber { get; set; }
        string GenerateAccountNumber(); 
    }
}

using System;
using BankAccount.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Core
{
    public class AccountNumberGenerator: IAccountNumberGenerator
    {
        //ААААА - BBB - C - DDDD - EEEEEEE 
        const string NONSTATEORGANISATION = "407";
        const string NONCOMMERCIALORGANISATION = "03";
        const string AMERICANDOLLARCODE = "840";
        const string CONTROLKEY = "C";
        const string FILIAL = "0000";

        public string GenerateAccountNumber(string serialNumber)
        {
            return String.Concat(NONSTATEORGANISATION, "-",
                                 NONCOMMERCIALORGANISATION, "-",
                                 AMERICANDOLLARCODE, "-",
                                 CONTROLKEY, "-",
                                 FILIAL, "-",
                                 serialNumber);
        }
    }
}

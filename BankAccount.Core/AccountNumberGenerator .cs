using System;
using BankAccount.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Core
{
    /// <summary>
    /// Creates unique Account Number according to bank's account number rules
    /// </summary>
    public class AccountNumberGenerator: IAccountNumberGenerator
    {
        //ААААА - BBB - C - DDDD - EEEEEEE 
        #region Constants
        const string NON_STATE_ORGANISATION = "407";
        const string NON_COMMERCIAL_ORGANISATION = "03";
        const string AMERICAN_DOLLAR_CODE = "840";
        const string CONTROL_KEY = "C";
        const string FILIAL = "0000";
        #endregion

        #region Public methods
        public string GenerateAccountNumber(string serialNumber)
        {
            return String.Concat(NON_STATE_ORGANISATION, "-",
                                 NON_COMMERCIAL_ORGANISATION, "-",
                                 AMERICAN_DOLLAR_CODE, "-",
                                 CONTROL_KEY, "-",
                                 FILIAL, "-",
                                 serialNumber);
        }
        #endregion
    }
}

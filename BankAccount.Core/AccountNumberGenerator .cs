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

        public int LastAccountNumber { get; set; }

        #region Constants
        const string NON_STATE_ORGANISATION = "407";
        const string NON_COMMERCIAL_ORGANISATION = "03";
        const string AMERICAN_DOLLAR_CODE = "840";
        const string CONTROL_KEY = "C";
        const string FILIAL = "0000";
        #endregion

        #region Public methods
        /// <summary>
        /// Generate custom 
        /// </summary>
        /// <param name="serialNumber">Serial number of account. Provides ability of creating unique number</param>
        /// <returns>Account number</returns>
        public string GenerateAccountNumber()
        {
            return String.Concat(NON_STATE_ORGANISATION, "-",
                                 NON_COMMERCIAL_ORGANISATION, "-",
                                 AMERICAN_DOLLAR_CODE, "-",
                                 CONTROL_KEY, "-",
                                 FILIAL, "-",
                                 LastAccountNumber + 1);
        }
        #endregion
    }
}

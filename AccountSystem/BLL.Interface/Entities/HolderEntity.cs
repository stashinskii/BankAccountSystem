using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Represents owner of Account
    /// </summary>
    public class HolderEntity
    {
        #region Public properties
        public string IdentificationNumber { get; set; }
        public List<string> Accounts { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        #endregion

        #region Constructors 
        public HolderEntity(string name, string email)
        {
            CheckCustomerData(email, name);
            Name = name;
            EMail = email;
            IdentificationNumber = Guid.NewGuid().ToString();
            Accounts = new List<string>();
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Checks given data accoring to rules
        /// </summary>
        /// <param name="email">String representation of emial</param>
        /// <param name="name">Customer's name</param>
        private static void CheckCustomerData(string email, string name)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!emailRegex.IsMatch(email))
            {
                throw new FormatException("Check your e-mail address");
            }

            if (name == null)
            {
                throw new ArgumentNullException("Empty customer data");
            }

            if (name == string.Empty)
            {
                throw new ArgumentException("Empty customer data");
            }
        }
        #endregion
    }
}

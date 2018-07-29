using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string EMail { get; set; }
        string passportNumber { get; set; }
        #endregion

        #region Constructors 
        public HolderEntity(string name, string surname, string email, string passport = null)
        {
            CheckCustomerData(email, name, surname);
            FirstName = name;
            EMail = email;
            SecondName = surname;
            passportNumber = passport;
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
        /// <param name="surname">Customer's surname</param>
        private static void CheckCustomerData(string email, string name, string surname)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!emailRegex.IsMatch(email))
            {
                throw new FormatException("Check your e-mail address");
            }

            if (name == null || surname == null)
            {
                throw new ArgumentNullException("Empty customer data");
            }

            if (name == string.Empty || surname == string.Empty)
            {
                throw new ArgumentException("Empty customer data");
            }
        }
        #endregion
    }
}

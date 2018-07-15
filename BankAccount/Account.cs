using System;
using System.Text.RegularExpressions;

namespace BankAccount
{
    /// <summary>
    /// Represents acount. Implements IAccount interface for managing basic actions and
    /// operation with account
    /// </summary>
    public class Account: IAccount
    {
        #region Public properties
        public string ID { get; set; }
        public int Balance { get; set; }
        public double ExtraPoints { get; set; }

        public AccountStatus Status { get; set; }
        public Customer CustomerInformation { get; set; }
        public AccountType Type { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Construcor which is pass Customer object
        /// </summary>
        /// <param name="type">Type of account</param>
        /// <param name="customer">Customer instance</param>
        public Account(AccountType type, Customer customer)
        {
            ID = Guid.NewGuid().ToString();
            CustomerInformation = customer;
            Type = type;
            ExtraPoints = 30;
            Status = AccountStatus.Opened;
        }

        /// <summary>
        /// Constructor which is pass full information about customer
        /// </summary>
        /// <param name="type">Type of account</param>
        /// <param name="name">Customer's name</param>
        /// <param name="surname">Customer's surname</param>
        /// <param name="email">Customer's email</param>
        /// <param name="passport">Customer's passport (optional)</param>
        public Account(AccountType type, string name, string surname, string email, string passport = null)
        {
            ID = Guid.NewGuid().ToString();
            Type = type;
            CustomerInformation = new Customer(name, surname, email, passport);
            ExtraPoints = 30;
            Status = AccountStatus.Opened;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Close given account. After closing account it is still availible to get
        /// some information, but operations with account are blocked
        /// </summary>
        /// <exception cref="InvalidAccountOperationException">
        /// Raises if given account is closed
        /// </exception>
        public void CloseAccount()
        {
            CheckStatus();
            Balance = 0;
            ExtraPoints = 0;
            Status = AccountStatus.Closed;
        }

        /// <summary>
        /// Income money of bank account
        /// </summary>
        /// <param name="amount">Amount of incoming money</param>
        public void Income(int amount)
        {
            CheckStatus();
            Balance += amount;
            ExtraPoints += IncomeExtraPoint(amount);
        }

        /// <summary>
        /// Outcome money of bank account. If difference from current balance
        /// and given amount is negative value - it raises InvalidAccountOperationException
        /// </summary>
        /// <param name="amount">Amount of outcoming money</param>
        public void Outcome(int amount)
        {
            CheckStatus();
            if ((Balance - amount) < 0)
            {
                throw new InvalidAccountOperationException("You don't have enough money for that!");
            }
            Balance -= amount;
            ExtraPoints -= OutcomeExtraPoint(amount);
        }

        /// <summary>
        /// Give access to basic account's inmformation (Customer info, ID, balance, extra points, 
        /// account status)
        /// </summary>
        /// <returns>Tuple of information</returns>
        public Tuple<Customer, string, int, double, AccountStatus> GetAccountData()
        {
            return new Tuple<Customer, string, int, double, AccountStatus>(CustomerInformation, ID, Balance, ExtraPoints, Status);
        }
        #endregion

        #region Privatemethods
        /// <summary>
        /// Checks if account is closed
        /// </summary>
        /// <exception cref="InvalidAccountOperationException">
        /// Raises if accont is closedd
        /// </exception>
        private void CheckStatus()
        {
            if (Status == AccountStatus.Closed)
                throw new InvalidAccountOperationException("Account is closed");
        }

        /// <summary>
        /// Counting extra points while income operation where called
        /// </summary>
        /// <param name="amount">Amount of money</param>
        /// <returns>Extra points value</returns>
        private double IncomeExtraPoint(int amount)
        {
            return (int)Type * amount * 0.1;
        }

        /// <summary>
        /// Counting extra points while outcome operation where called
        /// </summary>
        /// <param name="amount">Amount of money</param>
        /// <returns>Extra points value</returns>
        private double OutcomeExtraPoint(int amount)
        {
            return (int)Type * amount * 0.05;
        }
        #endregion
    }

    /// <summary>
    /// Represents owner of Account
    /// </summary>
    public class Customer
    {
        #region Public properties
        string ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string EMail { get; set; }
        string passportNumber { get; set; }
        #endregion

        #region Constructors 
        public Customer(string name, string surname, string email, string passport = null)
        {
            CheckCustomerData(email, name, surname);
            FirstName = name;
            EMail = email;
            SecondName = surname;
            passportNumber = passport;
            ID = Guid.NewGuid().ToString();
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

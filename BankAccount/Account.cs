using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BankAccount
{
    /// <summary>
    /// Constantd describing type of account
    /// </summary>
    public enum AccountType
    {
        Base, Silver, Gold, Platinum
    };

    public static class BankManager
    {
        #region Public methods
        public static Account[] accounts = new Account[0];

        public static void CreateNewAccount(Account newAccount)
        {
            Add(newAccount);
        }

        public static void DeleteAccount(string id)
        {
            RemoveAt(id);
        }

        public static void Income(int amount, string id)
        {
            accounts[SearchAccount(id)].Income(amount);
        }

        public static void Outcome(int amount, string id)
        {
            accounts[SearchAccount(id)].Outcome(amount);
        }
        #endregion

        #region Private methods
        private static int SearchAccount(string id)
        {
            for (int i = 0; i < accounts.Length ; i++)
            {
                if (accounts[i].ID == id)
                    return i;
            }

            throw new ArgumentException(nameof(id), "There is not such account with this id");
        }

        public static Tuple<Customer, int, double, AccountType, string> GetAccountData(string id)
        {
            Account account = accounts[SearchAccount(id)];
            return new Tuple<Customer, int, double, AccountType, string>(account.FullName, account.Balance, account.ExtraPoints, account.Type, account.ID);
        }

        private static void Add(Account account)
        {
            Array.Resize(ref accounts, accounts.Length + 1);
            accounts[accounts.Length - 1] = account;
            
        }

        private static void RemoveAt(string id)
        {
            int index = SearchAccount(id);
            if ((index >= 0) && (index < accounts.Length))
            {
                for (int i = index; i < accounts.Length - 1; i++)
                    accounts[i] = accounts[i + 1];
            }
            Array.Resize(ref accounts, accounts.Length - 1);
        }
        #endregion
    }

    public class Account
    {
        #region Public properties
        public string ID { get; set; }
        public bool AccountStatus { get; set; }
        public int Balance { get; set; }
        public Customer FullName { get; set; }
        public AccountType Type { get; set; }
        public double ExtraPoints { get; set; }
        #endregion

        #region Constructors
        public Account(AccountType type, Customer name)
        {
            ID = Guid.NewGuid().ToString();
            FullName = name;
            Type = type;
            ExtraPoints = 30;
            AccountStatus = true;
        }

        public Account(AccountType type, string name, string surname, string email, DateTime? birth = null, string passport = null)
        {
            ID = Guid.NewGuid().ToString();
            Type = type;
            FullName = new Customer(name, surname, email, birth, passport);
            ExtraPoints = 30;
            AccountStatus = true;
        }
        #endregion

        #region Public methods
        public void DeleteAccount()
        {
            AccountStatus = false;
        }
        public void Income(int amount)
        {
            Balance += amount;
            ExtraPoints += IncomeExtraPoint(amount);
        }
        public void Outcome(int amount)
        {
            Balance -= amount;
            ExtraPoints -= OutcomeExtraPoint(amount);
        }
        #endregion

        #region Privatemethods
        private double IncomeExtraPoint(int amount)
        {
            return (int)Type * amount * 0.1;
        }
        private double OutcomeExtraPoint(int amount)
        {
            return (int)Type * amount * 0.05;
        }
        #endregion
    }

    public class Customer
    {
        #region Public properties
        string ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string EMail { get; set; }
        DateTime? birthDate { get; set; }
        string passportNumber { get; set; }
        #endregion

        #region Constructors 
        public Customer(string name, string surname, string email, DateTime? birth = null, string passport = null)
        {
            CheckCustomerData(email, name, surname, passport);
            FirstName = name;
            EMail = email;
            SecondName = surname;
            birthDate = birth;
            passportNumber = passport;
            ID = Guid.NewGuid().ToString();
        }
        #endregion

        #region Private methods
        private static void CheckCustomerData(string email, string name, string surname, string passport)
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
        }
        #endregion
    }
}

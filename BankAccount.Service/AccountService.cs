using System;
using BankAccount.Repository;
using BankAccount.Core;
using BankAccount.Core.Interfaces;
using System.Collections.Generic;

namespace BankAccount.Service
{
    /// <summary>
    /// Represents service for managing bank accounts.
    /// Account's represents by different types: Base, Gold, Platimun and
    /// implements Account abstract class. Repository represents as instance of classes which
    /// implements IRepository interface.
    /// </summary>
    public class AccountService
    {
        #region Private fileds
        private IRepository repository;
        private IAccountNumberGenerator generator;
        #endregion

        #region Constructors
        public AccountService(IRepository givenRepository, IAccountNumberGenerator givenGenerator)
        {
            repository = givenRepository;
            generator = givenGenerator;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Creating new account according to given account type
        /// </summary>
        /// <param name="type">AccountType instance represents account type</param>
        /// <param name="name">Name of customer</param>
        /// <param name="surname">Surname of customer</param>
        /// <param name="email">Email of customer</param>
        /// <param name="passport">Passport number (additional)</param>
        public void OpenAccount(AccountType type, string name, string surname, string email, string passport = null)
        {
            Account newAccount = null;

            switch (type)
            {
                case AccountType.Base:
                    newAccount = new BaseAccount(generator, name, surname, email, passport);
                    break;
                case AccountType.Gold:
                    newAccount = new GoldAccount(generator, name, surname, email, passport);
                    break;
                case AccountType.Platinum:
                    newAccount = new PlatinumAccount(generator, name, surname, email, passport);
                    break;
            }

            repository.Create(newAccount);
        }

        /// <summary>
        /// Close account by its acoount number
        /// </summary>
        /// <param name="accountNumber">String representation of account number</param>
        public void CloseAccount(string accountNumber)
        {
            repository.Accounts[accountNumber].Status = AccountStatus.Closed;
        }

        /// <summary>
        /// Income of money
        /// </summary>
        /// <param name="accountNumber">String representation of account number</param>
        /// <param name="amount">Amount of income money</param>
        public void Deposite(string accountNumber, decimal amount)
        {
            repository.Accounts[accountNumber].Deposit(amount);
        }

        /// <summary>
        /// Outcome of money
        /// </summary>
        /// <param name="accountNumber">String representation of account number</param>
        /// <param name="amount">Amount of outcome money</param>
        public void Wirthdraw(string accountNumber, decimal amount)
        {
            repository.Accounts[accountNumber].Wirthdraw(amount);
        }

        public Dictionary<string, Account> GetAllAccount()
        {
            return repository.Read();
        }
        #endregion
    }
}

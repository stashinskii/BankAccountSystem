using System;
using NLog;
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
        private IRepository<Account> accountsRepository;
        private IRepository<Holder> holdersRepository;
        private IAccountNumberGenerator generator;
        //TODO Make interface for logger
        private Logger logger;
        #endregion

        #region Constructors
        public AccountService(IRepository<Account> accounts, IRepository<Holder> holders, IAccountNumberGenerator givenGenerator)
        {
            accountsRepository = accounts;
            holdersRepository = holders;

            generator = givenGenerator;
            logger = LogManager.GetLogger("BankServiceLogger");
            logger.Info("Service were created!");
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
            accountsRepository.Create(newAccount);
            logger.Info($"New account of {name} holder were created");

            if (CheckIfExist(email))
            {
                //добавляем юзеру AccountNumber
            }
            else
            {
                //создаем юзера и добавляем ему AccountNumber
            }
        }

        /// <summary>
        /// Close account by its acoount number
        /// </summary>
        /// <param name="accountNumber">String representation of account number</param>
        public void CloseAccount(string accountNumber)
        {
            accountsRepository.RepositoryObjects[accountNumber].Status = AccountStatus.Closed;
            logger.Info($"Account with number {accountNumber} were closed!");
        }

        /// <summary>
        /// Income of money
        /// </summary>
        /// <param name="accountNumber">String representation of account number</param>
        /// <param name="amount">Amount of income money</param>
        public void Deposite(string accountNumber, decimal amount)
        {
            accountsRepository.RepositoryObjects[accountNumber].Deposit(amount);
            logger.Info($"Account with number {accountNumber} get {amount} of money!");
        }

        /// <summary>
        /// Outcome of money
        /// </summary>
        /// <param name="accountNumber">String representation of account number</param>
        /// <param name="amount">Amount of outcome money</param>
        public void Wirthdraw(string accountNumber, decimal amount)
        {
            accountsRepository.RepositoryObjects[accountNumber].Wirthdraw(amount);
            logger.Info($"Account with number {accountNumber} loss {amount} of money!");
        }

        public Dictionary<string, Account> GetAllAccount()
        {
            return accountsRepository.Read();
        }
        #endregion

        #region Private methods
        public bool CheckIfExist(string email)
        {
            Dictionary<string, Holder> holders = holdersRepository.Read();
            return holders.ContainsKey(email);
        }
        #endregion
    }
}

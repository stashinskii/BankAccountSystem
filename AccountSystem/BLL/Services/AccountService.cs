using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.Interfaces;

namespace BLL.Services
{
    /// <summary>
    /// Represents service for managing bank accounts.
    /// Account's represents by different types: Base, Gold, Platimun and
    /// implements Account abstract class. Repository represents as instance of classes which
    /// implements IRepository interface.
    /// </summary>
    public class AccountService: IAccountService
    {
        #region Private fileds
        private IRepository<AccountEntity> accountsRepository;
        private IRepository<HolderEntity> holdersRepository;
        private IAccountNumberGenerator generator;
        //TODO Make interface for logger
        //private Logger logger;
        #endregion

        #region Constructors
        public AccountService(IRepository<AccountEntity> accounts, IRepository<HolderEntity> holders, IAccountNumberGenerator givenGenerator)
        {
            accountsRepository = accounts;
            holdersRepository = holders;

            generator = givenGenerator;
            givenGenerator.LastAccountNumber = accountsRepository.Read().Count;

            //logger = LogManager.GetLogger("BankServiceLogger");
            //logger.Info("Service were created!");
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
            AccountEntity newAccount = null;
            HolderEntity holder = new HolderEntity(name, surname, email, passport);

            switch (type)
            {
                case AccountType.Base:
                    newAccount = new BaseAccount(generator, holder);
                    break;
                case AccountType.Gold:
                    newAccount = new GoldAccount(generator, holder);
                    break;
                case AccountType.Platinum:
                    newAccount = new PlatinumAccount(generator, holder);
                    break;
            }
            accountsRepository.Create(newAccount);
            //logger.Info($"New account of {name} holder were created");

            //todo валидация на создание юзера и finally - удлаить аккаунт, если траблы с юзером

            if (CheckIfExist(email))
            {
                holdersRepository.Update(email, newAccount.AccountNumber);
            }
            else
            {
                holdersRepository.Create(holder);
                holdersRepository.Update(email, newAccount.AccountNumber);
            }
            generator.LastAccountNumber = accountsRepository.Read().Count;
        }

        /// <summary>
        /// Close account by its acoount number
        /// </summary>
        /// <param name="accountNumber">String representation of account number</param>
        public void CloseAccount(string accountNumber)
        {
            accountsRepository.RepositoryObjects[accountNumber].Status = AccountStatus.Closed;
            //logger.Info($"Account with number {accountNumber} were closed!");
        }

        /// <summary>
        /// Income of money
        /// </summary>
        /// <param name="accountNumber">String representation of account number</param>
        /// <param name="amount">Amount of income money</param>
        public void Deposite(string accountNumber, decimal amount)
        {
            accountsRepository.RepositoryObjects[accountNumber].Deposit(amount);
            // logger.Info($"Account with number {accountNumber} get {amount} of money!");
        }

        /// <summary>
        /// Outcome of money
        /// </summary>
        /// <param name="accountNumber">String representation of account number</param>
        /// <param name="amount">Amount of outcome money</param>
        public void Wirthdraw(string accountNumber, decimal amount)
        {
            accountsRepository.RepositoryObjects[accountNumber].Wirthdraw(amount);
            // logger.Info($"Account with number {accountNumber} loss {amount} of money!");
        }

        public Dictionary<string, AccountEntity> GetAllAccount()
        {
            return accountsRepository.Read();
        }

        public Dictionary<string, HolderEntity> GetAllHolders()
        {
            return holdersRepository.Read();
        }
        #endregion

        #region Private methods
        public bool CheckIfExist(string email)
        {
            Dictionary<string, HolderEntity> holders = holdersRepository.Read();
            return holders.ContainsKey(email);
        }
        #endregion
    }
}

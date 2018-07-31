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
        //TODO Make interface for logger
        //private Logger logger;
        #endregion

        #region Constructors
        public AccountService(IRepository<AccountEntity> accounts, IRepository<HolderEntity> holders, IAccountNumberCreateService givenGenerator)
        {
            accountsRepository = accounts;
            holdersRepository = holders;
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
        public void OpenAccount(string name, string email, AccountType type, IAccountNumberCreateService numberGenerator)
        {
            AccountEntity newAccount = null;
            HolderEntity holder = new HolderEntity(name, email);

            switch (type)
            {
                case AccountType.Base:
                    newAccount = new BaseAccount(numberGenerator, holder);
                    break;
                case AccountType.Gold:
                    newAccount = new GoldAccount(numberGenerator, holder);
                    break;
                case AccountType.Platinum:
                    newAccount = new PlatinumAccount(numberGenerator, holder);
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
            numberGenerator.LastAccountNumber = accountsRepository.Read().Count;
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
        public void Deposit(string accountNumber, decimal amount)
        {
            accountsRepository.RepositoryObjects[accountNumber].Deposit(amount);
            // logger.Info($"Account with number {accountNumber} get {amount} of money!");
        }

        /// <summary>
        /// Outcome of money
        /// </summary>
        /// <param name="accountNumber">String representation of account number</param>
        /// <param name="amount">Amount of outcome money</param>
        public void Withdraw(string accountNumber, decimal amount)
        {
            accountsRepository.RepositoryObjects[accountNumber].Wirthdraw(amount);
            // logger.Info($"Account with number {accountNumber} loss {amount} of money!");
        }

        public List<AccountEntity> GetAllAccounts()
        {
            return accountsRepository.Read().Select(kvp => kvp.Value).ToList();
        }

        public List<HolderEntity> GetAllHolders()
        {
            return holdersRepository.Read().Select(kvp => kvp.Value).ToList(); ;
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

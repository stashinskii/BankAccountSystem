using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface.DTO;

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
        private IRepository<DalAccount> accountsRepository;
        private IRepository<DalHolder> holdersRepository;
        private IAccountNumberCreateService numberGenerator;
        //TODO Make interface for logger
        //private Logger logger;
        #endregion

        #region Constructors
        public AccountService(IRepository<DalAccount> accounts, IRepository<DalHolder> holders, IAccountNumberCreateService givenGenerator)
        {
            accountsRepository = accounts;
            holdersRepository = holders;
            numberGenerator = givenGenerator;
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
        public void OpenAccount(AccountEntity account)
        {
            CheckIfExist(account);
            HolderEntity holder = holdersRepository.Read().ToHolder().FirstOrDefault(x => x.IdentificationNumber == account.AccountHolder.IdentificationNumber);

            if (holder == null)
            {
                holder = account.AccountHolder;
                holdersRepository.Create(holder.ToDalHolder());
            }
       
            account.AccountNumber = numberGenerator.GenerateAccountNumber();
            accountsRepository.Create(account.ToDalAccount());
            holder.Accounts.Add(account.AccountNumber); //тут заменить для работы с DAL.Fake (был список строк с номерами аккаунтов)
            holdersRepository.Update(holder.ToDalHolder());

        }

        /// <summary>
        /// Close account by its acoount number
        /// </summary>
        /// <param name="accountNumber">String representation of account number</param>
        public void CloseAccount(string accountNumber)
        {
            //accountsRepository.RepositoryObjects[accountNumber].Status = AccountStatus.Closed;
            //logger.Info($"Account with number {accountNumber} were closed!");
        }

        /// <summary>
        /// Income of money
        /// </summary>
        /// <param name="accountNumber">String representation of account number</param>
        /// <param name="amount">Amount of income money</param>
        public void Deposit(string accountNumber, decimal amount)
        {
            AccountEntity account = accountsRepository.GetByNumber(accountNumber).ToAccount();
            account.Deposit(amount);
            accountsRepository.Update(account.ToDalAccount());
            // logger.Info($"Account with number {accountNumber} get {amount} of money!");
        }

        /// <summary>
        /// Outcome of money
        /// </summary>
        /// <param name="accountNumber">String representation of account number</param>
        /// <param name="amount">Amount of outcome money</param>
        public void Withdraw(string accountNumber, decimal amount)
        {
            AccountEntity account = accountsRepository.GetByNumber(accountNumber).ToAccount();
            account.Wirthdraw(amount);
            accountsRepository.Update(account.ToDalAccount());
            // logger.Info($"Account with number {accountNumber} loss {amount} of money!");
        }

        public List<AccountEntity> GetAllAccounts()
        {
            return accountsRepository.Read().ToAccount().ToList();
        }

        public List<HolderEntity> GetAllHolders()
        {
            return holdersRepository.Read().ToHolder().ToList();
        }
        #endregion

        #region Private methods
        public void CheckIfExist(AccountEntity account)
        {
            List<HolderEntity> holders = holdersRepository.Read().ToHolder().ToList();

            List<string> emails = holders.Where(x => x.EMail == account.AccountHolder.EMail).Select(x => x.EMail).ToList();

            if (emails.Contains(account.AccountHolder.EMail))
                throw new InvalidAccountOperationException("This user exist!");
        }
        #endregion
    }
}

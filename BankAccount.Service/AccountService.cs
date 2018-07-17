using System;
using BankAccount.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Service
{
    public class AccountService
    {
        private IRepository repository;

        public AccountService(IRepository givenRepository)
        {
            repository = givenRepository;
        }

        public void OpenAccount(string name, string surname, string email, string passport = null)
        {
            IAccount newAccount = new Account(AccountType.Gold, name, surname, email, passport);
            repository.Create(newAccount);
        }

        public void CloseAccount(string accountNumber)
        {
            repository.Accounts[accountNumber].Status = AccountStatus.Closed;
        }

        public void Deposite(string accountNumber, decimal amount)
        {
            repository.Accounts[accountNumber].Deposit(amount);
        }
        public void Wirthdraw(string accountNumber, decimal amount)
        {
            repository.Accounts[accountNumber].Wirthdraw(amount);
        }

        public Dictionary<string, IAccount> GetAllAccount()
        {
            return repository.Read();
        }
    }
}

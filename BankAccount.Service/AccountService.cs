using System;
using BankAccount.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankAccount.Core;
using BankAccount.Core.Interfaces;


namespace BankAccount.Service
{
    public class AccountService
    {
        private IRepository repository;
        private IAccountNumberGenerator generator;

        public AccountService(IRepository givenRepository, IAccountNumberGenerator givenGenerator)
        {
            repository = givenRepository;
            generator = givenGenerator;
        }

        public void OpenAccount(string name, string surname, string email, string passport = null)
        {
            Account newAccount = new BaseAccount( generator, name, surname, email, passport);
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

        public Dictionary<string, Account> GetAllAccount()
        {
            return repository.Read();
        }
    }
}

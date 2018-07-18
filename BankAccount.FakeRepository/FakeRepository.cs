using System;
using BankAccount.Core.Interfaces;
using BankAccount.Core;
using System.Collections.Generic;

namespace BankAccount.Repository
{
    public class FakeRepository : IRepository
    {
        public Dictionary<string, Account> Accounts { get; set; }

        public FakeRepository()
        {
            Accounts = new Dictionary<string, Account>();
        }

        public void Create(Account account)
        {
            Accounts.Add(account.AccountNumber, account);
        }

        public void Save()
        {
            
        }

        public void Update(string id)
        {

        }

        public Dictionary<string, Account> Read()
        {
            return Accounts;
        }

        public Account GetByNumber(string id)
        {
            return Accounts[id];
        }

        public void Dispose()
        {
        }
    }
}

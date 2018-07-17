using System;
using System.Collections.Generic;

namespace BankAccount.Repository
{
    public class FakeRepository : IRepository
    {
        public Dictionary<string, IAccount> Accounts { get; set; }

        public FakeRepository()
        {
            Accounts = new Dictionary<string, IAccount>();
        }

        public void Create(IAccount account)
        {
            Accounts.Add(account.AccountNumber, account);
        }

        public void Save()
        {
            
        }

        public void Update(string id)
        {

        }

        public Dictionary<string, IAccount> Read()
        {
            return Accounts;
        }

        public IAccount GetByNumber(string id)
        {
            return Accounts[id];
        }
    }
}

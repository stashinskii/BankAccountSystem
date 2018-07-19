using System;
using BankAccount.Core.Interfaces;
using BankAccount.Core;
using System.Collections.Generic;

namespace BankAccount.Repository
{
    /// <summary>
    /// Represents implementation of Fake Repository.
    /// Implemented as a container of Dictionary
    /// </summary>
    public class FakeRepository : IRepository<Account>
    {
        public Dictionary<string, Account> RepositoryObjects { get; set; }

        public FakeRepository()
        {
            RepositoryObjects = new Dictionary<string, Account>();
        }

        public void Create(Account account)
        {
            RepositoryObjects.Add(account.AccountNumber, account);
        }

        public void Save()
        {
            
        }

        public void Update(string id)
        {

        }

        public Dictionary<string, Account> Read()
        {
            return RepositoryObjects;
        }

        public Account GetByNumber(string id)
        {
            return RepositoryObjects[id];
        }

        public void Dispose()
        {
        }
    }
}

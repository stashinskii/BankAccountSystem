using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;

namespace DAL.Fake.Repositories
{
    /// <summary>
    /// Represents implementation of Fake Repository.
    /// Implemented as a container of Dictionary
    /// </summary>
    public class AccountRepository : IRepository<DalAccount>
    {
        public Dictionary<string, DalAccount> RepositoryObjects { get; set; }

        public AccountRepository()
        {
            RepositoryObjects = new Dictionary<string, DalAccount>();
        }

        public void Create(DalAccount account)
        {
            RepositoryObjects.Add(account.AccountNumber, account);
        }

        public void Save()
        {

        }

        public void Update(string key, string id)
        {

        }

        public Dictionary<string, DalAccount> Read()
        {
            return RepositoryObjects;
        }

        public DalAccount GetByNumber(string id)
        {
            return RepositoryObjects[id];
        }

        public void Dispose()
        {
        }
    }
}

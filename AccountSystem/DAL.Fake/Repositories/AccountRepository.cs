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
        public List<DalAccount> RepositoryObjects { get; set; }

        public AccountRepository()
        {
            RepositoryObjects = new List<DalAccount>();
        }

        public void Create(DalAccount account)
        {
            RepositoryObjects.Add(account);
        }

        public void Save()
        {

        }

        public void Update(DalAccount account)
        {
            for (int i = 0; i < RepositoryObjects.Count; ++i)
                if (RepositoryObjects[i].AccountNumber == account.AccountNumber)
                    RepositoryObjects[i] = account;
        }

        public List<DalAccount> Read()
        {
            return RepositoryObjects;
        }

        public DalAccount GetByNumber(string id)
        {
            return RepositoryObjects.Find(x => x.AccountNumber == id);
        }

        public void Dispose()
        {
        }
    }
}

using System;
using BankAccount.Core;
using BankAccount.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Repository
{
    public class FakeHolderRepository: IRepository<Holder>
    {
        public Dictionary<string, Holder> RepositoryObjects { get; set; }

        public FakeHolderRepository()
        {
            RepositoryObjects = new Dictionary<string, Holder>();
        }

        public void Create(Holder holder)
        {
            RepositoryObjects.Add(holder.EMail, holder);
        }

        public void Save()
        {

        }

        public void Update(string id)
        {
            RepositoryObjects[id].Accounts.Add(id);
        }

        public Dictionary<string, Holder> Read()
        {
            return RepositoryObjects;
        }

        public Holder GetByNumber(string id)
        {
            return RepositoryObjects[id];
        }

        public void Dispose()
        {
        }


    }
}

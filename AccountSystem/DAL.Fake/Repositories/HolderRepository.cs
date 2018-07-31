using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;

namespace DAL.Fake.Repositories
{
    public class HolderRepository : IRepository<DalHolder>
    {
        public Dictionary<string, DalHolder> RepositoryObjects { get; set; }

        public HolderRepository()
        {
            RepositoryObjects = new Dictionary<string, DalHolder>();
        }

        public void Create(DalHolder holder)
        {
            RepositoryObjects.Add(holder.EMail, holder);
        }

        public void Save()
        {

        }

        public void Update(string email, string id)
        {
            RepositoryObjects[email].Accounts.Add(id);
        }

        public Dictionary<string, DalHolder> Read()
        {
            return RepositoryObjects;
        }

        public DalHolder GetByNumber(string id)
        {
            return RepositoryObjects[id];
        }

        public void Dispose()
        {
        }


    }
}

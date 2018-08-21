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
        public List<DalHolder> RepositoryObjects { get; set; }

        public HolderRepository()
        {
            RepositoryObjects = new List<DalHolder>();
        }

        public void Create(DalHolder holder)
        {
            RepositoryObjects.Add(holder);
        }

        public void Save()
        {

        }

        public void Update(DalHolder holder)
        {
            for (int i = 0; i < RepositoryObjects.Count; ++i)
                if (RepositoryObjects[i].IdentificationNumber == holder.IdentificationNumber)
                    RepositoryObjects[i] = holder;
        }

        public List<DalHolder> Read()
        {
            return RepositoryObjects;
        }

        public DalHolder GetByNumber(string id)
        {
            return RepositoryObjects.Find(x=> x.IdentificationNumber == id);
        }

        public void Dispose()
        {
        }


    }
}

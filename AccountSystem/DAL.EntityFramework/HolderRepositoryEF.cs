using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Interface.Interfaces;
using DAL.Interface.DTO;

namespace DAL.EntityFramework
{
    public class HoldertRepositoryEF : IRepository<DalHolder>
    {
        public List<DalHolder> RepositoryObjects { get; set; }

        public void Create(DalHolder account)
        {
            using (HolderContext context = new HolderContext())
            {
                context.Holders.Add(account);
            }
        }

        public void Dispose()
        {

        }

        public DalHolder GetByNumber(string id)
        {
            using (HolderContext context = new HolderContext())
            {
                return context.Holders.First(x => x.IdentificationNumber == id);
            }
        }

        public List<DalHolder> Read()
        {
            using (HolderContext context = new HolderContext())
            {
                return context.Holders.ToList();
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(DalHolder obj)
        {
            using (HolderContext context = new HolderContext())
            {
                var result = context.Holders.SingleOrDefault(b => b.IdentificationNumber == obj.IdentificationNumber);
                if (result != null)
                {
                    result = obj;
                    context.SaveChanges();
                }
            }
        }
    }
}

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
            using (MainContext context = new MainContext())
            {
                context.Holders.Add(account);
                context.SaveChanges();
            }
        }

        public void Dispose()
        {

        }

        public DalHolder GetByNumber(string id)
        {
            using (MainContext context = new MainContext())
            {
                return context.Holders.First(x => x.IdentificationNumber == id);
            }
        }

        public List<DalHolder> Read()
        {
            using (MainContext context = new MainContext())
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
            using (MainContext context = new MainContext())
            {
                var result = context.Holders.SingleOrDefault(b => b.IdentificationNumber == obj.IdentificationNumber);
                if (result != null)
                {
                    result.Accounts = obj.Accounts;
                    result.EMail = obj.EMail;
                    result.Name = obj.Name;
                    context.SaveChanges();
                }
            }
        }
    }
}

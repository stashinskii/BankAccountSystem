using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using DAL.Interface.Interfaces;
using DAL.Interface.DTO;

namespace DAL.EntityFramework
{
    public class AccountRepositoryEF : IRepository<DalAccount>
    {
        public List<DalAccount> RepositoryObjects { get; set; }

        public void Create(DalAccount account)
        {
            using (AccountContext context = new AccountContext())
            {
                context.Accounts.Add(account);
                context.SaveChanges();
            }     
        }

        public void Dispose()
        {
           
        }

        public DalAccount GetByNumber(string id)
        {
            using (AccountContext context = new AccountContext())
            {
                return context.Accounts.First(x => x.AccountNumber == id);
            }
        }

        public List<DalAccount> Read()
        {
            using (AccountContext context = new AccountContext())
            {
                return context.Accounts.ToList();
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(DalAccount obj)
        {
            using (AccountContext context = new AccountContext())
            {
                var result = context.Accounts.SingleOrDefault(b => b.AccountNumber == obj.AccountNumber);
                if (result != null)
                {
                    result = obj;
                    context.SaveChanges();
                }
            }
        }
    }
}

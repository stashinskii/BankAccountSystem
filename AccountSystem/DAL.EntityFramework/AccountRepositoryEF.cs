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
            using (MainContext context = new MainContext())
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
            using (MainContext context = new MainContext())
            {
                return context.Accounts.Include(p => p.AccountHolder).First(x => x.AccountNumber == id);
            }
        }

        public List<DalAccount> Read()
        {
            using (MainContext context = new MainContext())
            {
                return context.Accounts.Include(p => p.AccountHolder).ToList();
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(DalAccount obj)
        {
            using (MainContext context = new MainContext())
            {
                var result = context.Accounts.SingleOrDefault(b => b.AccountNumber == obj.AccountNumber);
                if (result != null)
                {
                    result.AccountHolder = obj.AccountHolder;
                    result.Balance = obj.Balance;
                    result.BonusPoints = obj.BonusPoints;
                    context.SaveChanges();
                }
            }
        }
    }
}

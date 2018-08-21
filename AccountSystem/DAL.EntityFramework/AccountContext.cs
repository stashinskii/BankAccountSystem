using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using System.Data.Entity;

namespace DAL.EntityFramework
{
    public class AccountContext : DbContext
    {
        public AccountContext() : base("AccountsDB") { }

        public DbSet<DalAccount> Accounts { get; set; }

    }
}

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
    class MainContext : DbContext
    {
        public MainContext() : base("BanksDataDB") { }

        public DbSet<DalAccount> Accounts { get; set; }
        public DbSet<DalHolder> Holders { get; set; }
    }
}

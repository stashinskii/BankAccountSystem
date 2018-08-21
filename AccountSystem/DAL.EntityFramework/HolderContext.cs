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
    public class HolderContext: DbContext
    {
        public HolderContext(): base("HoldersDB") { }

        public DbSet<DalHolder> Holders { get; set; }

    }
}

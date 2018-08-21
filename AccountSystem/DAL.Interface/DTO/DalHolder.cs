using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalHolder
    {
        public string IdentificationNumber { get; set; }
        public List<string> Accounts { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalHolder
    {
        public int Id { get; set; }
        public string IdentificationNumber { get; set; }
        public List<string> Accounts { get; set; } = new List<string>();
        public string Name { get; set; }
        public string EMail { get; set; }
    }
}

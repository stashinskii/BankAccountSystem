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
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string EMail { get; set; }
        public string passportNumber { get; set; }
    }
}

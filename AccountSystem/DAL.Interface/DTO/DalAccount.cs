using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalAccount
    {
        protected double BonusPointsCoefficient { get; set; }
        protected decimal MinimumBalance { get; set; }

        public AccountStatus Status { get; set; }
        public HolderEntity AccountHolder { get; set; }
        public AccountType Type { get; set; }

        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public int BonusPoints { get; set; }
    }
}

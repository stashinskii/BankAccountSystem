using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalAccount
    {
        public int Id { get; set; }
        protected double BonusPointsCoefficient { get; set; }
        protected decimal MinimumBalance { get; set; }

        public DalHolder AccountHolder { get; set; }

        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public int BonusPoints { get; set; }
    }
}

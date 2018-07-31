using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BllEntityMappers
    {
        public static DalAccount ToDalAccount(this AccountEntity accountEntity)
        {
            return new DalAccount()
            {
                AccountHolder = accountEntity.AccountHolder,
                Balance = accountEntity.Balance,
                AccountNumber = accountEntity.AccountNumber,
                BonusPoints = accountEntity.BonusPoints,
                Status = accountEntity.Status,
                Type = accountEntity.Type
            };
        }

        public static DalHolder ToDalDoler(this HolderEntity holderEntity)
        {
            return new DalHolder()
            {
                Accounts = holderEntity.Accounts,
                EMail = holderEntity.EMail,
                FirstName = holderEntity.FirstName,
                IdentificationNumber = holderEntity.IdentificationNumber,
                SecondName = holderEntity.SecondName
            };
        }
    }
}
  
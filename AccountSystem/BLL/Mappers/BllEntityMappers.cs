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
                AccountHolder = accountEntity.AccountHolder.ToDalHolder(),
                Balance = accountEntity.Balance,
                AccountNumber = accountEntity.AccountNumber,
                BonusPoints = accountEntity.BonusPoints,

            };
        }

        public static AccountEntity ToAccount(this DalAccount accountEntity)
        {
            return new AccountEntity()
            {
                AccountHolder = accountEntity.AccountHolder.ToHolder(),
                Balance = accountEntity.Balance,
                AccountNumber = accountEntity.AccountNumber,
                BonusPoints = accountEntity.BonusPoints,

            };
        }

        public static IEnumerable<AccountEntity> ToAccount(this List<DalAccount> baseAccounts)
        {
            foreach (var element in baseAccounts)
            {
                yield return element.ToAccount();
            }
        }

        public static IEnumerable<DalAccount> ToDalAccount(this List<AccountEntity> baseAccounts)
        {
            foreach (var element in baseAccounts)
            {
                yield return element.ToDalAccount();
            }
        }

        public static DalHolder ToDalHolder(this HolderEntity holderEntity)
        {
            return new DalHolder()
            {
                Accounts = holderEntity.Accounts,
                EMail = holderEntity.EMail,
                Name = holderEntity.Name,
                IdentificationNumber = holderEntity.IdentificationNumber,
            };
        }

        public static HolderEntity ToHolder(this DalHolder holderEntity)
        {
            return new HolderEntity()
            {
                Accounts =  holderEntity.Accounts,
                EMail = holderEntity.EMail,
                Name = holderEntity.Name,
                IdentificationNumber = holderEntity.IdentificationNumber,
            };
        }

        public static IEnumerable<HolderEntity> ToHolder(this List<DalHolder> holder)
        {
            foreach (var element in holder)
            {
                yield return element.ToHolder();
            }
        }

        public static IEnumerable<DalHolder> ToDalHolder(this List<HolderEntity> holder)
        {
            foreach (var element in holder)
            {
                yield return element.ToDalHolder();
            }
        }

    }
}
  
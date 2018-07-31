using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface IAccountService
    {
        void OpenAccount(AccountType type, string name, string surname, string email, string passport = null);
        void CloseAccount(string accountNumber);
        void Deposite(string accountNumber, decimal amount);
        void Wirthdraw(string accountNumber, decimal amount);
        Dictionary<string, AccountEntity> GetAllAccount();
        Dictionary<string, HolderEntity> GetAllHolders();
    }
}

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
        void OpenAccount(string name, string email, AccountType type, IAccountNumberCreateService numberGenerator);
        void CloseAccount(string accountNumber);
        void Deposit(string accountNumber, decimal amount);
        void Wirthdraw(string accountNumber, decimal amount);
        Dictionary<string, AccountEntity> GetAllAccounts();
        Dictionary<string, HolderEntity> GetAllHolders();
    }
}

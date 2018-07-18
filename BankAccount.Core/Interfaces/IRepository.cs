using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Core.Interfaces
{
    /// <summary>
    /// Represents interface which provide ability of managing accont 
    /// by service by different databases
    /// </summary>
    public interface IRepository : IDisposable
    {
        Dictionary<string, Account> Accounts { get; set; }

        void Create(Account account);
        void Save();
        void Update(string id);
        Dictionary<string, Account> Read();
        Account GetByNumber(string id);
    }
}

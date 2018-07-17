using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public interface IRepository
    {
        Dictionary<string, IAccount> Accounts { get; set; }

        void Create(IAccount account);
        void Save();
        void Update(string id);
        Dictionary<string, IAccount> Read();
        IAccount GetByNumber(string id);
    }
}

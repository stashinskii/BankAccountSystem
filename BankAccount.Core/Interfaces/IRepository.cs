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
    public interface IRepository<T> : IDisposable
    {
        Dictionary<string, T> RepositoryObjects { get; set; }

        void Create(T account);
        void Save();
        void Update(string key, string info);
        Dictionary<string, T> Read();
        T GetByNumber(string id);
    }
}

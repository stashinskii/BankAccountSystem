using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// Represents interface which provide ability of managing accont 
    /// by service by different databases
    /// </summary>
    public interface IRepository<T> : IDisposable
    {
        List<T> RepositoryObjects { get; set; }

        void Create(T account);
        void Save();
        void Update(T obj);
        List<T> Read();
        T GetByNumber(string id);
    }
}

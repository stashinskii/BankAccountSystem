using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface IAccountNumberCreateService
    {
        int LastAccountNumber { get; set; }
        string GenerateAccountNumber();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface.DTO;


namespace BLL.Services
{
    public class AccountNumberGenerator : IAccountNumberCreateService
    {
        public string GenerateAccountNumber() => Guid.NewGuid().ToString();
    }
}

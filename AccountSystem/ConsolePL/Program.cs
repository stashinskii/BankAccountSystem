using System;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
        }

        static void Main(string[] args)
        {
            IAccountService service = resolver.Get<IAccountService>();
            IAccountNumberCreateService creator = resolver.Get<IAccountNumberCreateService>();

            service.OpenAccount("Account owner 1", "ger@gmail.com",  AccountType.Base, creator);
            service.OpenAccount("Account owner 2", "ger1@gmail.com", AccountType.Base, creator);
            service.OpenAccount("Account owner 3", "ger4@gmail.com", AccountType.Silver, creator);
            service.OpenAccount("Account owner 4", "ger5@gmail.com", AccountType.Base, creator);

            var creditNumbers = service.GetAllAccounts().Select(acc => acc.AccountNumber).ToArray();

            foreach (var t in creditNumbers)
            {
                service.Deposit(t, 100);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            foreach (var t in creditNumbers)
            {
                service.WithdrawAccount(t, 10);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }
        }
    }
}

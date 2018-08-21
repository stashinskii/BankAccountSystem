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


            //IRepository<DalAccount> accounts = new AccountRepository();
            //IRepository<DalHolder> holders = new HolderRepository();

            //IAccountService service = new AccountService(accounts, holders, new AccountNumberGenerator());

            service.OpenAccount(new AccountEntity("Account owner 2", "sdsd","gerq@gmail.com"));
            service.OpenAccount(new AccountEntity("Account owner 2q", "sdsd", "gerwq@gmail.com"));
            service.OpenAccount(new AccountEntity("Account owner 2qw", "sdsd", "gerq1w@gmail.com"));
            service.OpenAccount(new AccountEntity("Account owner 2wq", "sdsd",  "gejrq@gmail.com"));



            var creditNumbers = service.GetAllAccounts().Select(acc => acc.AccountNumber).ToArray();

            foreach (var t in creditNumbers)
            {
                service.Deposit(t, 100);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item.AccountNumber + "  " + item.Balance);
            }


            Console.WriteLine();
            foreach (var t in creditNumbers)
            {
                service.Withdraw(t, 10);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item.AccountNumber+ "  "+ item.Balance);
            }
        }
    }
}

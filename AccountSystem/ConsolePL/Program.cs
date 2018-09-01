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

            while (true)
            {
                PrintMenu();
                ConsoleKeyInfo choose = Console.ReadKey();
                if (choose.KeyChar == '1')
                {
                    service.OpenAccount(InputAccountData());
                }
                else if (choose.KeyChar == '2')
                {
                    Console.WriteLine();
                    foreach (var item in service.GetAllAccounts())
                    {
                        Console.WriteLine(item.AccountNumber + " | " + item.Balance + " | " + item.AccountHolder.Name);
                    }
                    Console.WriteLine();
                }
                else if (choose.KeyChar == '3')
                {
                    service.Withdraw(
                        Console.ReadLine(),
                        decimal.Parse(Console.ReadLine()));
                }
                else if (choose.KeyChar == '4')
                {
                    service.Deposit(
                        Console.ReadLine(),
                        decimal.Parse(Console.ReadLine()));
                }
                else if (choose.KeyChar == '5')
                {
                    Console.WriteLine("Soon...");
                }

            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine("1. Add account");
            Console.WriteLine("2. List of accounts");
            Console.WriteLine("3. Wirthdraw money");
            Console.WriteLine("4. Deposit money");
            Console.WriteLine("5. Get account info");
        }

        public static AccountEntity InputAccountData()
        {
            Console.WriteLine("\nName, Surname, Email:");
            return new AccountEntity(
                Console.ReadLine(), 
                Console.ReadLine(), 
                Console.ReadLine());
        }
    }
}

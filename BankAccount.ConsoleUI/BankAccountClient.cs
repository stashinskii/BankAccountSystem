using System;
using BankAccount.Core;
using BankAccount.Core.Interfaces;
using BankAccount.Service;
using BankAccount.Repository;
using System.Collections.Generic;

namespace BankAccount.ConsoleUI
{
    class BankAccountClient
    {
        static void Main(string[] args)
        {
            FakeRepository repository = new FakeRepository();

            AccountService service = new AccountService(repository, new AccountNumberGenerator());

            service.OpenAccount(AccountType.Base, "Herman", "Stashynski", "germanstashinskii@gmail.com");
            service.OpenAccount(AccountType.Gold, "New", "Person", "newperson@gmail.com");
            service.OpenAccount(AccountType.Platinum, "Person", "New", "1newperson@gmail.com");


            Dictionary<string, Account> allAccount = service.GetAllAccount();
            PrintAccountInfo(allAccount);

            foreach (string number in GetAllAccountNumbers(allAccount))
            {
                service.Deposite(number, 20);
                service.Wirthdraw(number, 20);
            }

            Dictionary<string, Account> afterDeposite = service.GetAllAccount();
            PrintAccountInfo(afterDeposite);

            Console.ReadKey();
        }

        public static List<string> GetAllAccountNumbers(Dictionary<string, Account> data)
        {
            List<string> accountNumbers = new List<string>();
            foreach (KeyValuePair<string, Account> account in data)
            {
                accountNumbers.Add(account.Key);
            }

            return accountNumbers;
        }
        public static void PrintAccountInfo(Dictionary<string, Account> data)
        {
            foreach (KeyValuePair<string, Account> account in data)
            {
                Console.WriteLine("{0} {1} - {2}", account.Value.AccountHolder.FirstName, account.Value.AccountHolder.SecondName, account.Value.Type);
                Console.WriteLine(account.Value.Balance);
                Console.WriteLine(account.Value.BonusPoints);
            }
        }
    }
}

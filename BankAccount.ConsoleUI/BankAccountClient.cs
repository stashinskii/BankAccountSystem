using System;
using BankAccount.Core;
using BankAccount.Core.Interfaces;
using BankAccount.Service;
using BankAccount.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.ConsoleUI
{
    class BankAccountClient
    {
        public static List<string> GetAllAccountNumbers(Dictionary<string, IAccount> data)
        {
            List<string> accountNumbers = new List<string>(); 
            foreach (KeyValuePair<string, IAccount> account in data)
            {
                accountNumbers.Add(account.Key);
            }

            return accountNumbers;
        }
        public static void PrintAccountInfo(Dictionary<string, IAccount> data)
        {
            foreach (KeyValuePair<string, IAccount> account in data)
            {
                Console.WriteLine("{0} {1}", account.Value.AccountHolder.FirstName, account.Value.AccountHolder.SecondName);
                Console.WriteLine(account.Value.Balance);
            }
        }

        static void Main(string[] args)
        {

            FakeRepository repository = new FakeRepository();
            AccountService service = new AccountService(repository, new AccountNumberGenerator());

            service.OpenAccount("Herman", "Stashynski", "germanstashinskii@gmail.com");
            service.OpenAccount("New", "Person", "newperson@gmail.com");
            

            Dictionary<string, IAccount> allAccount = service.GetAllAccount();
            PrintAccountInfo(allAccount);

            foreach (string number in GetAllAccountNumbers(allAccount))
            {
                service.Deposite(number, 20);
            }

            Dictionary<string, IAccount> afterDeposite = service.GetAllAccount();
            PrintAccountInfo(afterDeposite);

            Console.ReadKey();
        }
    }
}

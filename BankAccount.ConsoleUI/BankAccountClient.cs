using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.ConsoleUI
{
    class BankAccountClient
    {
        public static void PrintAccountInfo(Tuple<Customer, int, double, AccountType, string> data)
        {
           
            Console.WriteLine(data.Item1.FirstName + " " + data.Item1.SecondName);
            Console.WriteLine("Balance:" + data.Item2);
            Console.WriteLine("Extra Point:" + data.Item3);
        }

        static void Main(string[] args)
        {
            Customer customer = new Customer("Herman", "Stashynski", "germanstashinskii@gmail.com");
            Account hermanAccount = new Account(AccountType.Gold, customer);

            BankManager.CreateNewAccount(hermanAccount);
            string id = hermanAccount.ID;
            Tuple<Customer, int, double, AccountType, string> data = BankManager.GetAccountData(id);
            PrintAccountInfo(data);

            BankManager.Income(20, id);
            BankManager.Outcome(10, id);
            Console.WriteLine(hermanAccount.Balance);


            Tuple<Customer, int, double, AccountType, string> data1 = BankManager.GetAccountData(id);
            PrintAccountInfo(data);

            Console.ReadKey();
        }
    }
}

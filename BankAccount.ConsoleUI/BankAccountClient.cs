using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.ConsoleUI
{
    class BankAccountClient
    {
        public static void PrintAccountInfo(Account customerAccount)
        {
            Tuple<Customer, string, int, double, AccountStatus> data = customerAccount.GetAccountData();
            Console.WriteLine("Customer information: {0} {1}", data.Item1.FirstName, data.Item1.SecondName);
            Console.WriteLine("ID: {0}", data.Item2);
            Console.WriteLine("Balance: {0}", data.Item3);
            Console.WriteLine("Extra Point: {0}", data.Item4);
            Console.WriteLine("Accoutn status: {0}", data.Item5);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Customer customer = new Customer("Herman", "Stashynski", "germanstashinskii@gmail.com");
            Account hermanAccount = new Account(AccountType.Gold, customer);
            PrintAccountInfo(hermanAccount);

            hermanAccount.Income(10);
            PrintAccountInfo(hermanAccount);

            hermanAccount.Outcome(5);
            PrintAccountInfo(hermanAccount);

            hermanAccount.CloseAccount();
            PrintAccountInfo(hermanAccount);

            try
            {
                hermanAccount.Income(50);
            }
            catch (InvalidAccountOperationException)
            {
                Console.WriteLine("Closed account! Invalid operation!");
            }

            Console.ReadKey();
        }
    }
}

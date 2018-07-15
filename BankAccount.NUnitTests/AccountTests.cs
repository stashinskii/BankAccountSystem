using System;
using NUnit.Framework;

namespace BankAccount.NUnitTests
{
    [TestFixture]
    public class AccountTests
    {
        public Account AccountGenerator()
        {
            string name = "Herman", surname = "Stashynski", email = "germanstashinskii@gmail.com";
            return new Account(AccountType.Platinum, name, surname, email);
        }

        [Test]
        public void AccountTest_CreateAccount()
        {
            Account account = AccountGenerator();
            Assert.IsInstanceOf(typeof(Account), account);
        }

        [TestCase(ExpectedResult = 10)]
        public int AcountTest_IncomeTests()
        {
            Account account = AccountGenerator();
            account.Income(10);
            return account.Balance;
        }

        [TestCase(ExpectedResult = 5)]
        public int AccountTest_OutcomeTests()
        {
            Account account = AccountGenerator();
            account.Income(10);
            account.Outcome(5);
            return account.Balance;
        }

        [TestCase(ExpectedResult = AccountStatus.Closed)]
        public AccountStatus AcountTest_CloseAccount()
        {
            Account account = AccountGenerator();
            account.CloseAccount();
            return account.Status;
        }

        [Test]
        public void AccountTest_InvalidOperationException()
        {
            Account account = AccountGenerator();
            account.CloseAccount();
            Assert.Throws(typeof(InvalidAccountOperationException), () => account.Income(10));
            Assert.Throws(typeof(InvalidAccountOperationException), () => account.Outcome(10));
        }

        [Test]
        public void AccountTest_InvalidEmail()
        {
            Assert.Throws(typeof(FormatException), () => new Account(AccountType.Gold, "Herman", "Stashynski", "dfdfeji"));
        }

        [Test]
        public void AccountTest_NullData()
        {
            Assert.Throws(typeof(ArgumentNullException), () => new Account(AccountType.Gold, null, null, "germanstashinskii@gmail.com"));
        }

        [Test]
        public void AccountTest_EmptyData()
        {
            Assert.Throws(typeof(ArgumentException), () => new Account(AccountType.Gold, string.Empty, string.Empty, "germanstashinskii@gmail.com"));
        }

        [Test]
        public void AccountTest_NegativeBalanceException()
        {
            Account account = AccountGenerator();
            Assert.Throws(typeof(InvalidAccountOperationException), () => account.Outcome(10));
        }
    }
}

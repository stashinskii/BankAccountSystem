using System;
using BankAccount.Core;
using BankAccount.Repository;
using BankAccount.Service;
using BankAccount.Core.Interfaces;
using NUnit.Framework;

namespace BankAccount.NUnitTests
{
    [TestFixture]
    public class AccountTests
    {
        static FakeRepository repository = new FakeRepository();
        static AccountService manager = new AccountService(repository ,new AccountNumberGenerator());

        public Account AccountGenerator()
        { 
            string name = "Herman", surname = "Stashynski", email = "germanstashinskii@gmail.com";
            return new BaseAccount(new AccountNumberGenerator(), name, surname, email);
        }
            
        [Test]
        public void AccountTest_CreateAccount()
        {
            Account account = AccountGenerator();
            Assert.IsInstanceOf(typeof(BaseAccount), account);
        }
        

        
        [TestCase(ExpectedResult = 10)]
        public decimal AcountTest_IncomeTests()
        {
            Account account = AccountGenerator();
            account.Deposit(10);
            return account.Balance;
        }

        [TestCase(ExpectedResult = 5)]
        public decimal AccountTest_OutcomeTests()
        {
            Account account = AccountGenerator();
            account.Deposit(10);
            account.Wirthdraw(5);
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
            Assert.Throws(typeof(InvalidAccountOperationException), () => account.Deposit(10));
            Assert.Throws(typeof(InvalidAccountOperationException), () => account.Wirthdraw(10));
        }

        
        [Test]
        public void AccountTest_InvalidEmail()
        {
            Assert.Throws(typeof(FormatException), () => new GoldAccount(new AccountNumberGenerator(), "Herman", "Stashynski", "dfdfeji"));
        }

        
        [Test]
        public void AccountTest_NullData()
        {
            Assert.Throws(typeof(ArgumentNullException), () => new GoldAccount(new AccountNumberGenerator(), "Herman", "Stashynski", "dfdfeji"));
        }

        [Test]
        public void AccountTest_EmptyData()
        {
            Assert.Throws(typeof(ArgumentException), () => new GoldAccount(new AccountNumberGenerator(), "Herman", "Stashynski", "dfdfeji"));
        }
    }
}

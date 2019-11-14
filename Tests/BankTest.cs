using Inlamning1_TomBergqvist.Models;
using System;
using System.Linq;
using Xunit;

namespace Tests
{
    public class BankTest
    {
        private BankRepository repository;

        [Fact]
        public void Deposit()
        {
            repository = new BankRepository();

            decimal amount = 500;
            int account = 1;

            repository.Accounts.Add(new Account(account, 1, 1000));
            repository.Deposit(account, amount);

            Assert.Equal(1500, repository.Accounts[0].Balance);
        }

        [Fact]
        public void DepositNegative()
        {
            repository = new BankRepository();

            decimal amount = -500;
            int account = 1;

            repository.Accounts.Add(new Account(account, 1, 1000));
            repository.Deposit(account, amount);

            Assert.Equal(1000, repository.Accounts[0].Balance);
        }

        [Fact]
        public void Withdraw()
        {
            repository = new BankRepository();

            decimal amount = 500;
            int account = 1;

            repository.Accounts.Add(new Account(account, 1, 1000));
            repository.Withdraw(account, amount);

            Assert.Equal(500, repository.Accounts[0].Balance);
        }

        [Fact]
        public void WithdrawTooMuch()
        {
            repository = new BankRepository();

            decimal amount = 1001;
            int account = 1;

            repository.Accounts.Add(new Account(account, 1, 1000));
            repository.Withdraw(account, amount);

            Assert.Equal(1000, repository.Accounts[0].Balance);
        }
    }
}

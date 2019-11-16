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

        [Fact]
        public void Transfer()
        {
            repository = new BankRepository();

            var accountOne = new Account(1 , 1 , 1000);
            var accountTwo = new Account(2, 2, 2000);
            repository.Accounts.Add(accountOne);
            repository.Accounts.Add(accountTwo);
            accountOne.Transfer(accountTwo.Id ,500 ,repository);
            Assert.Equal(500, accountOne.Balance);
            Assert.Equal(2500, accountTwo.Balance);
        }

        [Fact]
        public void TransferOverLimit()
        {
            repository = new BankRepository();
            var accountOne = new Account(1, 1, 1000);
            var accountTwo = new Account(2, 2, 2000);
            repository.Accounts.Add(accountOne);
            repository.Accounts.Add(accountTwo);
            accountOne.Transfer(accountTwo.Id, 3500, repository);
            Assert.Equal(1000, accountOne.Balance);
            Assert.Equal(2000, accountTwo.Balance);

        }

    }
}

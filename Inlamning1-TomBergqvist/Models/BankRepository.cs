using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlamning1_TomBergqvist.Models
{
    public class BankRepository
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Account> Accounts { get; set; } = new List<Account>();

        public string Withdraw(int id, decimal amount)
        {
            var account = Accounts.SingleOrDefault(a => a.Id == id);

            if(account == null)
            {
                return $"The account {id} does not exist.";
            }
            else
            {
                if (amount <= 0)
                {
                    return "The amount has to be positive.";
                }
                if (account.Balance < amount)
                {
                    return $"The balance on account {id} is too low.";
                }
                else
                {
                    account.Balance -= amount;
                    return $"The account {id} now has {account.Balance} after withdrawing {amount}.";
                }
            }
        }
        
        public string Deposit(int id, decimal amount)
        {
            var account = Accounts.SingleOrDefault(a => a.Id == id);

            if (account == null)
            {
                return $"The account {id} does not exist.";
            }
            else
            {
                if (amount <= 0)
                {
                    return "The amount has to be positive.";
                }
                account.Balance += amount;
                return $"The account {id} now has {account.Balance} after depositing {amount}.";
            }
        }
    }
}

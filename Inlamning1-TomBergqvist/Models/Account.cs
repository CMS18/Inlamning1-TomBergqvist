using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlamning1_TomBergqvist.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int AccountHolder { get; set; }
        public decimal Balance { get; set; }

        public Account(int id, int holder, decimal balance)
        {
            Id = id;
            AccountHolder = holder;
            Balance = balance;
        }

        public string Transfer( int toAccount, decimal toTransferAmount , BankRepository bank)
        {
            var fromAcc = bank.Accounts.FirstOrDefault(k => k.Id == Id);
            var toAcc = bank.Accounts.FirstOrDefault(k => k.Id == toAccount);
            if(toAcc == null)
            {
                return "Invalid Reciving Account";
            }
            if (fromAcc == null)
            {
                return "Invalid Sending Account";
            }
            if(toAcc == fromAcc)
            {
                return " Reciving and Sending Account Can not be the Same";
            }

            if (toTransferAmount< 0 )
            {
                return "Invalid Amount ";
            }
            if(toTransferAmount > Balance )
            {
                return "Insufficienet Balance ";
            }

            bank.Deposit(toAcc.Id, toTransferAmount);
            bank.Withdraw(fromAcc.Id, toTransferAmount);
            return $"Transfered {toTransferAmount} from {Id} to {toAccount} resulting in a balance of {toAcc.Balance}.";
        }

    }
}

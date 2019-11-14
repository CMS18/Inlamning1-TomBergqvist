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
    }
}

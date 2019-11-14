using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlamning1_TomBergqvist.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();

        public Customer(int id, string first, string last)
        {
            Id = id;
            FirstName = first;
            LastName = last;
        }
    }
}

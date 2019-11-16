using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlamning1_TomBergqvist.Models.ViewModels
{
    public class TransferViewModel
    {
        public int FromAcc { get; set; }
        public int ToAcc { get; set; }
        public decimal Amount { get; set; }

        public string Message { get; set; }

    }
}

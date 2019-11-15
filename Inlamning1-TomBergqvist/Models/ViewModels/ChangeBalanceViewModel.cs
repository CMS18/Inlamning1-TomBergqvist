using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inlamning1_TomBergqvist.Models.ViewModels
{
    public class ChangeBalanceViewModel
    {
        [Display(Name = "Account Id")]
        [Required]
        public int Account { get; set; }

        [Display(Name = "Amount")]
        [Required]
        public decimal Amount { get; set; }

        public string Message { get; set; }

        public string Mode { get; set; }
    }
}

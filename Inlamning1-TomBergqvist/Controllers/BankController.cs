using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlamning1_TomBergqvist.Models;
using Inlamning1_TomBergqvist.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inlamning1_TomBergqvist.Controllers
{
    public class BankController : Controller
    {
        private BankRepository _repository;

        public BankController(BankRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new ChangeBalanceViewModel();
            return View("ChangeBalance", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Bank")]
        public IActionResult ChangeBalance(ChangeBalanceViewModel model)
        {
            if (ModelState.IsValid)
            {
                switch (model.Mode)
                {
                    case "withdraw":
                        model.Message = _repository.Withdraw(model.Account, model.Amount);
                        break;
                    case "deposit":
                        model.Message = _repository.Deposit(model.Account, model.Amount);
                        break;
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Transfer()
        {
            var model = new TransferViewModel();
          
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public IActionResult Transfer(TransferViewModel model)
        {
            if (ModelState.IsValid)
            {
                var account = _repository.Accounts.FirstOrDefault(n => n.Id == model.FromAcc);


                if(account== null)
                {
                    model.Message = "This Account Does Not Exist";
                }
                else
                {
                    model.Message = account.Transfer(model.ToAcc , model.Amount, _repository);  
                    
                }
            }
            return View(model);
        }

    }
}

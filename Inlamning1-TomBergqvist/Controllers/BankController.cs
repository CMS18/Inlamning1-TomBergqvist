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
        [Route("bank")]
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
    }
}

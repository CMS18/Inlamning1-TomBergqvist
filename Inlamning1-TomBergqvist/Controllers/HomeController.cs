using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Inlamning1_TomBergqvist.Models;
using Inlamning1_TomBergqvist.Models.ViewModels;

namespace Inlamning1_TomBergqvist.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankRepository _repository;

        public HomeController(BankRepository repo)
        {
            _repository = repo;
        }

        public IActionResult Index()
        {
            var model = new CustomerAccountsViewModel();
            model.Customers = _repository.Customers;

            foreach(var customer in model.Customers)
            {
                customer.Accounts = _repository.Accounts.Where(a => a.AccountHolder == customer.Id).ToList();
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Johannas_Bank.BankModels;
using Johannas_Bank.Repo;
using Johannas_Bank.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Johannas_Bank.Controllers
{
    public class Feature3Controller : Controller
    {
        private BankRepository _repo;

        public Feature3Controller(BankRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Transaction(int verify)
        {
            if (verify == 2) //Om man returneras tillbaka hit från misslyckande, om ej ifsats = error meddelande
            {
                ViewBag.ErrorMessage = TempData["error"].ToString();
            }

            List<Customer> viewModel = _repo.Customers;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Transaction(string amount, int numberFrom, int numberTo)
        {
            var account = new Account();
            var stringReturned = "";

            var accounts = _repo.Accounts.Where(a => a.Id == numberFrom)?.ToList();
            accounts.Add(_repo.Accounts.Where(a => a.Id == numberTo)?.FirstOrDefault());

            stringReturned = account.WithdrawFromDepositTo(amount, accounts, numberFrom);

            if (stringReturned != "OK")
            {
                TempData["error"] = stringReturned;
                return RedirectToAction("Transaction", new { verify = 2 });
            }

            else
            {
                return RedirectToAction("Verify", new { id = numberTo });
            }


        }

        public IActionResult Verify(int id)
        {
            Customer customer = _repo.Customers.Where(a => a.Account.Id == id).FirstOrDefault();
            return View(customer);
        }
    }
}
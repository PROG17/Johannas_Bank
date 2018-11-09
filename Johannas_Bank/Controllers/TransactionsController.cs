using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Johannas_Bank.BankModels;
using Johannas_Bank.Repo;
using Johannas_Bank.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Johannas_Bank.Controllers
{
    public class TransactionsController : Controller
    {
        private BankRepository _repo;

        public TransactionsController(BankRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            List<Account> accounts = _repo.Accounts;
            TransactionVM model = new TransactionVM(){ Accounts = accounts };
            return View(model);
        }

        [HttpPost]
        public IActionResult Deposit(TransactionVM vm)
        {
            if (ModelState.IsValid)
            {
                if (!_repo.Accounts.Any(a => a.Id == vm.Account))
                    return View("AccountNotFound");

                _repo.Deposit(vm.Account, vm.Sum);
                Account account = _repo.Accounts.Where(a => a.Id == vm.Account).FirstOrDefault();
                return View(account);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult WithDraw(TransactionVM vm)
        {
            if (ModelState.IsValid)
            {
                if (!_repo.Accounts.Any(a => a.Id == vm.Account))
                    return View("AccountNotFound");

                if (!_repo.WithDraw(vm.Account, vm.Sum))
                    return View("TransactionFailed");
                else
                {
                    Account account = _repo.Accounts.Where(a => a.Id == vm.Account).FirstOrDefault();
                    return View(account);
                }
            }
            return RedirectToAction("Index");
        }
 
    }
}
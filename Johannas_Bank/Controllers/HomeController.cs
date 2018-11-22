using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Johannas_Bank.Models;
using Johannas_Bank.Repo;
using Johannas_Bank.BankModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;
using Johannas_Bank.Email;

namespace Johannas_Bank.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment _environment;
        private readonly IConfiguration _config;
        private BankRepository _repo;
        private IEmailsender _emailSender;

        public HomeController(BankRepository repo, IHostingEnvironment environment, IConfiguration config, IEmailsender emailSender)
        {
            _repo = repo;
            _environment = environment;
            _config = config;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            List<Customer> viewModel = _repo.Customers;

            return View(viewModel);
        }

        public IActionResult About()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SendEmail(Customer customer, string emailAdress)
        {
            _emailSender.SendEmail(customer, emailAdress);
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

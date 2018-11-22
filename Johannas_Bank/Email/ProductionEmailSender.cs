using Johannas_Bank.BankModels;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;

namespace Johannas_Bank.Email
{
    public class ProductionEmailSender : IEmailsender
    {
        private readonly IConfiguration _config;

        public ProductionEmailSender(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(Customer model, string emailAdress = "johanna.akerstrom@yh.nackademin.se")
        {
            string sendgrid_apikey = _config.GetValue<string>("EmailSettings:sendgrid_apikey");
            var client = new SendGridClient(sendgrid_apikey);
            var from = new EmailAddress("johanna.akerstrom@yh.nackademin.se", "Johanna");
            var to = new EmailAddress(emailAdress, "Example User");
            var subject = "customer data";
            var plainTextContent = "Name: " + model.Name + ", Saldo: " + model.Account.Balance.ToString();
            var htmlContent = "<strong>" + plainTextContent +"</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var response = client.SendEmailAsync(msg);
        }
    }
}

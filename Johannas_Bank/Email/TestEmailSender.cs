using Johannas_Bank.BankModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace Johannas_Bank.Email
{
    public class TestEmailSender : IEmailsender
    {
        private readonly IConfiguration _config;

        public TestEmailSender(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(Customer model, string emailAdress = " ")
        {
            string hostname = _config.GetValue<string>("EmailSettings:HostName");
            string userName = _config.GetValue<string>("EmailSettings:UserName");
            string passWord = _config.GetValue<string>("EmailSettings:PassWord");
            string messageContent = "Name: " + model.Name + ", Saldo: " + model.Account.Balance.ToString();

            var client = new SmtpClient(hostname, 2525) // hostname, port
            {
                Credentials = new NetworkCredential(userName, passWord), // username, password
                EnableSsl = true
            };
            // from, to, subject, text
            client.Send("from@example.com", "to@example.com", "Customer data", messageContent);
        }
    }
}

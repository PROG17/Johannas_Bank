using Johannas_Bank.BankModels;

namespace Johannas_Bank.Email
{
    public interface IEmailsender
    {
        void SendEmail(Customer model, string emailAdress = " ");
    }
}

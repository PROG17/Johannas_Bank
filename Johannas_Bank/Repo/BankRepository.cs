using Johannas_Bank.BankModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Johannas_Bank.Repo
{
    public class BankRepository
    {
        public List<Customer> Customers { get; set; }
        public List<Account> Accounts { get; set; }

        public BankRepository()
        {
            CreateAccounts();
            CreateCustomers();            
        }

        public bool Deposit(int account, long sum)
        {
            Account depoAccount = Accounts.Where(a => a.Id == account).FirstOrDefault();
            depoAccount.Deposit(sum);
            return true;
        }

        public bool WithDraw(int account, long sum)
        {
            Account withdrawAccount = Accounts.Where(a => a.Id == account).FirstOrDefault();
            return withdrawAccount.Withdraw(sum);
        }

        private void CreateCustomers()
        {
            Customers = new List<Customer>()
            {
                new Customer
                {
                    Id = 1,
                    Name = "Stina",
                    Account = Accounts.Where(a => a.Owner == "Stina").FirstOrDefault() 
                },
                new Customer
                {
                    Id = 2,
                    Name = "Ulla",
                    Account = Accounts.Where(a => a.Owner == "Ulla").FirstOrDefault()
                },
                new Customer
                {
                    Id = 3,
                    Name = "Erik",
                    Account = Accounts.Where(a => a.Owner == "Erik").FirstOrDefault()
                }
            };
        }

        private void CreateAccounts()
        {
            Accounts = new List<Account>()
            {
                new Account
                {
                    Id = 891213,
                    Owner = "Erik",
                    Balance = 12000
                },
                new Account
                {
                    Id = 750912,
                    Owner = "Ulla",
                    Balance = 130000
                },
                new Account
                {
                    Id = 771030,
                    Owner = "Stina",
                    Balance = 25000
                }
            };
        }

    }
}

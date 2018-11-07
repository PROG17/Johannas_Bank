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

        private void CreateCustomers()
        {
            Customers = new List<Customer>()
            {
                new Customer
                {
                    Name = "Stina",
                    Account = Accounts.Where(a => a.Owner == "Stina").FirstOrDefault() 
                },
                new Customer
                {
                    Name = "Ulla",
                    Account = Accounts.Where(a => a.Owner == "Ulla").FirstOrDefault()
                },
                new Customer
                {
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
                    Owner = "Erik",
                    Balance = 12000
                },
                new Account
                {
                    Owner = "Ulla",
                    Balance = 130000
                },
                new Account
                {
                    Owner = "Stina",
                    Balance = 25000
                }
            };
        }

    }
}

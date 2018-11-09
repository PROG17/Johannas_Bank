using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Johannas_Bank.BankModels
{
    public class Account
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public long Balance { get; set; }

        public bool Deposit(long sum)
        {
            Balance += sum;
            return true;
        }

        public bool Withdraw(long sum)
        {
            if(Balance < sum)
                return false;           
            else
                Balance -= sum;
                return true;
        }
    }
}

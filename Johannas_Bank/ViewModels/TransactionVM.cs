using Johannas_Bank.BankModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Johannas_Bank.ViewModels
{
    public class TransactionVM
    {
        public List<Account> Accounts { get; set; }

        [DisplayName("Konto")]
        [Range(1, int.MaxValue, ErrorMessage = "nummret är för långt")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Enbart siffror får anges")]
        public int Account { get; set; }

        [DisplayName("Summa")]
        [Range(1, long.MaxValue, ErrorMessage = "Summan är för lång")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Enbart siffror får anges")]
        public long Sum { get; set; }
    }
}

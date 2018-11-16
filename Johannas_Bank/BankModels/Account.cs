using Johannas_Bank.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Johannas_Bank.BankModels
{
    public class Account //Lägg till metoder för överföring på Account-klassen == WithdrawFromDepositTo
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
            if (Balance < sum)
                return false;
            else
                Balance -= sum;
            return true;
        }

        public string WithdrawFromDepositTo(string amount, List<Account> standingList, int number) //Summan, Lista på personerna som det handlar om, numret på kontot som för över
        {
            var check = true;


            if (amount == null || amount.Contains(",") || amount.Contains("."))
            {
                if (amount == null)
                    return "Du måste fylla i alla rutor";

                else return "Felaktigt format i belopp rutan";
            }

            check = Regex.IsMatch(amount, @"[a-zA-Z]");

            if (check == false) //Inga bokstäver i 
            {
                foreach (var item in standingList)
                {
                    if (item == null)
                    {
                        return "Någon av kontona finns inte";
                    }
                }

                if (standingList.Count == 2)
                {
                    var payToPerson = standingList.Where(x => x.Id != number).FirstOrDefault();
                    var payFromPerson = standingList.Where(x => x.Id == number).FirstOrDefault();

                    

                    if (payFromPerson.Balance >= Convert.ToInt64(amount))
                    {
                        payFromPerson.Balance -= Convert.ToInt64(amount);
                        payToPerson.Balance += Convert.ToInt64(amount);

                        return "OK";
                    }

                    else return "Det finns inte tillräckligt med pengar på överföringskontot";
                }

                return "Någon av kontona finns inte";
            }

            return "Felaktigt format i belopp rutan";


        }
    }
}

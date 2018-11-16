using Johannas_Bank.BankModels;
using System;
using Xunit;

namespace Bank_Test
{
    public class Account_test
    {
        /// <summary>
        ///Första testerna testar att metoderna Account.Deposit/Account.WithDraw 
        ///Returnerar true eller false
        /// </summary>


        [Theory]
        [InlineData(5)]
        public void Deposit(long sum)
        {
            Account testAccount = new Account() { Balance = 5 };

            bool expected = true;
            bool actual = testAccount.Deposit(sum);

            Assert.Equal(expected, actual);
        }


        //Testar om uttaget är för stort
        [Theory]
        [InlineData(10)]
        public void WithDraw_SumBiggerThanBalance(long sum)
        {
            Account testAccount = new Account() { Balance = 5 };

            bool expected = false;
            bool actual = testAccount.Withdraw(sum);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2)]
        public void WithDraw_SumSmallerThanBallance(long sum)
        {
            Account testAccount = new Account() { Balance = 5 };

            bool expected = true;
            bool actual = testAccount.Withdraw(sum);

            Assert.Equal(expected, actual);
        }

        /// <summary>
        ///Andra testerna testar att Account.Balance ändras till rätt värde
        ///Efter insättning/uttag
        /// </summary>
        /// 

        [Theory]
        [InlineData(50, 150)]
        public void Deposit_BalanceIsRight(long sum, long expectedBalance)
        {
            Account testAccount = new Account() { Balance = 100 };

            long expected = expectedBalance;

            testAccount.Deposit(sum);

            long actual = testAccount.Balance;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(50, 50)]
        public void WithDraw_BalanceIsRight(long sum, long expectedBalance)
        {
            Account testAccount = new Account() { Balance = 100 };

            long expected = expectedBalance;

            testAccount.Withdraw(sum);

            long actual = testAccount.Balance;

            Assert.Equal(expected, actual);
        }

        /*Emmas Unittest*/
        //Skapa enhetstester som verifierar att saldot på kontot blir korrekt efter överföring på från- respektive till-konto.
        [Theory]
        [InlineData(10, 40, 10)]
        public void Transaction_BalanceIsRight(long sum, long firstExpected, long secondExpected)
        {
            Account firstPerson = new Account() { Balance = 50, Id = 1 };
            Account secondPerson = new Account() { Balance = 0, Id = 2 };

            firstPerson.Withdraw(sum); //Tar från
            secondPerson.Deposit(sum); //Lägger in

            var result = firstPerson.Balance;
            var resultTwo = secondPerson.Balance;

            Assert.Equal(firstExpected, result); //Första personens förväntade resultat
            Assert.Equal(secondExpected, resultTwo); //Andra personens förväntade resultat
        }

        //Skapa en enhetstest som verifierar att det inte går att överföra mer pengar än det finns saldo på från-kontot.
        [Theory]
        [InlineData(10, true)]
        [InlineData(100, false)]
        public void TransactionFailure_BalanceIsRight(long sum, bool expected)
        {
            Account firstPerson = new Account() { Balance = 50, Id = 1 };

            var isItNot = firstPerson.Withdraw(sum);

            Assert.Equal(expected, isItNot);
        }
    }
}

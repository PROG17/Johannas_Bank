using Johannas_Bank.BankModels;
using System;
using Xunit;

namespace Bank_Test
{
    public class Account_test
    {
        /// <summary>
        ///F�rsta testerna testar att metoderna Account.Deposit/Account.WithDraw 
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


        //Testar om uttaget �r f�r stort
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
        ///Andra testerna testar att Account.Balance �ndras till r�tt v�rde
        ///Efter ins�ttning/uttag
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
        //Skapa enhetstester som verifierar att saldot p� kontot blir korrekt efter �verf�ring p� fr�n- respektive till-konto.
        [Theory]
        [InlineData(10, 40, 10)]
        public void Transaction_BalanceIsRight(long sum, long firstExpected, long secondExpected)
        {
            Account firstPerson = new Account() { Balance = 50, Id = 1 };
            Account secondPerson = new Account() { Balance = 0, Id = 2 };

            firstPerson.Withdraw(sum); //Tar fr�n
            secondPerson.Deposit(sum); //L�gger in

            var result = firstPerson.Balance;
            var resultTwo = secondPerson.Balance;

            Assert.Equal(firstExpected, result); //F�rsta personens f�rv�ntade resultat
            Assert.Equal(secondExpected, resultTwo); //Andra personens f�rv�ntade resultat
        }

        //Skapa en enhetstest som verifierar att det inte g�r att �verf�ra mer pengar �n det finns saldo p� fr�n-kontot.
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

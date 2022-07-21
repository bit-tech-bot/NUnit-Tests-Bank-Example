using Bank;
using NUnit.Framework;

namespace BankNUnitTests
{
    public class BankAccountTests
    {
        private BankAccount account;

        [SetUp]

        public void Setup()
        {
            // Arrange for all tests
            account = new BankAccount(1000);
        }

        [Test]
        public void Adding_Funds_Updates_Balance()
        {
            // Act
            account.Add(500);

            // Assert
            Assert.AreEqual(1500, account.Balance);


        }

        [Test]
        public void Adding_Negative_Funds_Throws()
        {
            // Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Add(-500));


        }

        [Test]
        public void Withdrawing_Funds_Updates_Balance()
        {
            // Act
            account.Withdraw(500);

            // Assert
            Assert.AreEqual(500, account.Balance);


        }

        [Test]
        public void Withdrawing_Negative_Funds_Throws()
        {
            // Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-500));


        }

        [Test]
        public void Withdrawing_More_Than_Balance_Throws()
        {
            // Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(2000));


        }

        [Test]
        public void Transferring_Funds_Updates_Both_Accounts()
        {
            // Arrange
            var account2 = new BankAccount();

            // Act
            account.TransferFundsTo(account2, 500);

            // Assert
            Assert.AreEqual(500, account.Balance);
            Assert.AreEqual(500, account2.Balance);


        }

        [Test]
        public void Transfer_To_Non_Existing_Account_Throws()
        {
            // Act + Assert
            Assert.Throws<ArgumentNullException>(() => account.TransferFundsTo(null, 2000));


        }

    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;

namespace ProjectTestcases
{
    [TestClass]
    public class AuthorizeDepositTestCase
    {
        private AuthorizeDepositData depositData;

        [TestInitialize]
        public void SetUp()
        {
            depositData = new AuthorizeDepositData();
        }

        // Test case for valid deposit
        [TestMethod]
        public void TestDeposit_ValidAmount_Success()
        {
            // Arrange
            int accountNumber = 12345;
            decimal amount = 1000;

            // Act
            bool result = depositData.DepositAmount(accountNumber, amount);

            // Assert
            Assert.IsTrue(result, "Deposit should be successful for a valid amount.");
        }

        // Test case for deposit with zero amount
        [TestMethod]
        public void TestDeposit_ZeroAmount_Failure()
        {
            // Arrange
            int accountNumber = 12345;
            decimal amount = 0;

            bool result = depositData.DepositAmount(accountNumber, amount);

            Assert.IsFalse(result, "Deposit should fail when the amount is zero.");
        }

        // Test case for deposit with negative amount (this will fail)
        [TestMethod]
        public void TestDeposit_NegativeAmount_Failure()
        {
            // Arrange
            int accountNumber = 12345;
            decimal amount = -500;

            // Act
            bool result = depositData.DepositAmount(accountNumber, amount);

            // Assert
            Assert.IsTrue(result, "Deposit should fail when the amount is negative.");  // This will fail, because it should be false.
        }

        // Test case for deposit with invalid account number
        [TestMethod]
        public void TestDeposit_InvalidAccount_Failure()
        {
            // Arrange
            int accountNumber = 99999; // Invalid account
            decimal amount = 1000;

            // Act
            bool result = depositData.DepositAmount(accountNumber, amount);

            // Assert
            Assert.IsFalse(result, "Deposit should fail when the account number is invalid.");
        }

        [TestMethod]
        public void TestDeposit_LargeAmount_Success()
        {

            int accountNumber = 12345;
            decimal amount = 100000;

            bool result = depositData.DepositAmount(accountNumber, amount);

            Assert.IsTrue(result, "Deposit should be successful for a large amount.");
        }
    }
}


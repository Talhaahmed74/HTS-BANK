using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace ProjectTestcases
{
    [TestClass]
    public class BillPaymentTestCase
    {
        [TestMethod]
        public void TestPayBill_ValidAmount_Success()
        {
            // Arrange
            int accountNo = 1001;  // Valid account number
            string billType = "Electricity";
            decimal billAmount = 150.75m;  // Valid amount
            string billPaymentId = "BP123"; // Valid payment ID

            // Act
            bool result = BillPaymentData.PayBill(accountNo, billType, billAmount, billPaymentId);

            // Assert
            Assert.IsTrue(result, "The bill payment should be successful with a valid amount.");
        }

        [TestMethod]
        public void TestPayBill_InsufficientBalance_Failure()
        {
            // Arrange
            int accountNo = 1001;  // Valid account number
            string billType = "Electricity";
            decimal billAmount = 9999999.99m;  // Excessive amount (greater than account balance)
            string billPaymentId = "BP123"; // Valid payment ID

            // Act
            bool result = BillPaymentData.PayBill(accountNo, billType, billAmount, billPaymentId);

            // Assert
            Assert.IsFalse(result, "The bill payment should fail due to insufficient balance.");
        }

        [TestMethod]
        public void TestPayBill_ZeroAmount_Failure()
        {
            // Arrange
            int accountNo = 1001;  
            string billType = "Electricity";
            decimal billAmount = 0m; 
            string billPaymentId = "BP123"; 

            // Act
            bool result = BillPaymentData.PayBill(accountNo, billType, billAmount, billPaymentId);

            // Assert
            Assert.IsFalse(result, "The bill payment should fail when the amount is zero.");
        }

        [TestMethod]
        public void TestPayBill_NegativeAmount_Failure()
        {
            // Arrange
            int accountNo = 1001;  // Valid account number
            string billType = "Electricity";
            decimal billAmount = -150.75m;  // Invalid amount (negative)
            string billPaymentId = "BP123"; // Valid payment ID

            // Act
            bool result = BillPaymentData.PayBill(accountNo, billType, billAmount, billPaymentId);

            // Assert
            Assert.IsFalse(result, "The bill payment should fail when the amount is negative.");
        }

        [TestMethod]
        public void TestPayBill_InvalidBillPaymentId_Failure()
        {
            // Arrange
            int accountNo = 1001;  // Valid account number
            string billType = "Electricity";
            decimal billAmount = 150.75m;  // Valid amount
            string billPaymentId = "InvalidId"; // Invalid payment ID

            // Act
            bool result = BillPaymentData.PayBill(accountNo, billType, billAmount, billPaymentId);

            // Assert
            Assert.IsFalse(result, "The bill payment should fail when the bill payment ID is invalid.");
        }

        [TestMethod]
        public void TestGetBillDetails_ValidDetails_ReturnsCorrectData()
        {
            // Arrange
            string billPaymentId = "BP123";
            string accountNo = "1001";

            // Act
            var billDetails = BillPaymentData.GetBillDetails(billPaymentId, accountNo);

            // Assert
            Assert.IsNotNull(billDetails, "Bill details should not be null.");
            Assert.AreEqual("Electricity", billDetails.billType, "The bill type should match.");
            Assert.AreEqual("150.75", billDetails.billAmount, "The bill amount should match.");
        }

        [TestMethod]
        public void TestGetBillDetails_InvalidBillPaymentId_ReturnsNull()
        {
            // Arrange
            string billPaymentId = "InvalidId";
            string accountNo = "1001";

            // Act
            var billDetails = BillPaymentData.GetBillDetails(billPaymentId, accountNo);

            // Assert
            Assert.IsNull(billDetails.billType, "Bill type should be null.");
            Assert.IsNull(billDetails.billAmount, "Bill amount should be null.");
        }

        [TestMethod]
        public void TestGetDueBills_ValidAccount_ReturnsDueBills()
        {
            // Arrange
            int accountNo = 1001;

            // Act
            List<BillPayment> bills = BillPaymentData.GetDueBills(accountNo);

            // Assert
            Assert.IsNotNull(bills, "The list of due bills should not be null.");
            Assert.IsTrue(bills.Count > 0, "There should be at least one due bill.");
        }

        [TestMethod]
        public void TestGetDueBills_AccountWithNoBills_ReturnsEmptyList()
        {
            // Arrange
            int accountNo = 9999;  // Account with no due bills

            // Act
            List<BillPayment> bills = BillPaymentData.GetDueBills(accountNo);

            // Assert
            Assert.IsNotNull(bills, "The list of due bills should not be null.");
            Assert.AreEqual(0, bills.Count, "There should be no due bills.");
        }
    }
}

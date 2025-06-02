using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using System;

namespace ProjectTestcases

{
    [TestClass]
    public class CustomerLoginTestcases
    {
        private CustomerLoginData _customerLoginData;

        [TestInitialize]
        public void Setup()
        {
            // Initialize the CustomerLoginData instance before each test
            _customerLoginData = new CustomerLoginData();
        }

        [TestMethod]
        public void TestVerifyLogin_ValidCredentials_ReturnsTrue()
        {
            // Arrange: Use valid account number and password
            int accountNo = 12345; // Assume this account exists in the database
            string password = "validPassword"; // Assume this is the correct password

            // Act: Call VerifyLogin method
            bool result = _customerLoginData.VerifyLogin(accountNo, password);

            // Assert: Check if the result is true (authenticated)
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestVerifyLogin_InvalidAccountNo_ReturnsFalse()
        {
            // Arrange: Use an invalid account number (does not exist)
            int accountNo = 99999; // Assume this account does not exist in the database
            string password = "validPassword";

            // Act: Call VerifyLogin method
            bool result = _customerLoginData.VerifyLogin(accountNo, password);

            // Assert: Check if the result is false (not authenticated)
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestVerifyLogin_InvalidPassword_ReturnsFalse()
        {
            // Arrange: Use valid account number but an incorrect password
            int accountNo = 12345; // Assume this account exists in the database
            string password = "incorrectPassword"; // Incorrect password

            // Act: Call VerifyLogin method
            bool result = _customerLoginData.VerifyLogin(accountNo, password);

            // Assert: Check if the result is false (not authenticated)
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestVerifyLogin_EmptyCredentials_ReturnsFalse()
        {
            // Arrange: Use empty account number and password
            int accountNo = 0;
            string password = "";

            // Act: Call VerifyLogin method
            bool result = _customerLoginData.VerifyLogin(accountNo, password);

            // Assert: Check if the result is false (not authenticated)
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestVerifyLogin_ExceptionHandling_ReturnsFalse()
        {
            // Arrange: Use account number and password that simulate an exception (e.g., database issue)
            int accountNo = -1; // Invalid account number that may throw an exception
            string password = "anyPassword";

            // Act: Call VerifyLogin method
            bool result = _customerLoginData.VerifyLogin(accountNo, password);

            // Assert: Check if the result is false (not authenticated)
            Assert.IsFalse(result);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Clean up any resources if necessary after each test
            _customerLoginData = null;
        }
    }
}

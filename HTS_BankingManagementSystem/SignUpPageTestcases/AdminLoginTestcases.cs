using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using System;

namespace ProjectTestcases
{
    [TestClass]
    public class AdminLoginTestcases
    {
        private AdminLoginData _adminLoginData;

        [TestInitialize]
        public void Setup()
        {
            // Initialize the AdminLoginData instance before each test
            _adminLoginData = new AdminLoginData();
        }

        [TestMethod]
        public void TestVerifyLogin_ValidCredentials_ReturnsTrue()
        {
            // Arrange: Use valid admin account number and password
            int accountNo = 1001; // Assume this admin account exists in the database
            string password = "adminPassword"; // Assume this is the correct password

            // Act: Call VerifyLogin method
            bool result = _adminLoginData.VerifyLogin(accountNo, password);

            // Assert: Check if the result is true (authenticated)
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestVerifyLogin_InvalidAccountNo_ReturnsFalse()
        {
            // Arrange: Use an invalid admin account number (does not exist)
            int accountNo = 9999; // Assume this admin account does not exist in the database
            string password = "adminPassword";

            // Act: Call VerifyLogin method
            bool result = _adminLoginData.VerifyLogin(accountNo, password);

            // Assert: Check if the result is false (not authenticated)
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestVerifyLogin_InvalidPassword_ReturnsFalse()
        {
            // Arrange: Use a valid admin account number but incorrect password
            int accountNo = 1001; // Assume this admin account exists in the database
            string password = "wrongPassword"; // Incorrect password

            // Act: Call VerifyLogin method
            bool result = _adminLoginData.VerifyLogin(accountNo, password);

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
            bool result = _adminLoginData.VerifyLogin(accountNo, password);

            // Assert: Check if the result is false (not authenticated)
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestVerifyLogin_ExceptionHandling_ReturnsFalse()
        {
            // Arrange: Use account number and password that simulate an exception (e.g., database issue)
            int accountNo = -1; 
            string password = "anyPassword";

            // Act: Call VerifyLogin method
            bool result = _adminLoginData.VerifyLogin(accountNo, password);

            // Assert: Check if the result is false (not authenticated)
            Assert.IsFalse(result);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Clean up any resources if necessary after each test
            _adminLoginData = null;
        }
    }
}

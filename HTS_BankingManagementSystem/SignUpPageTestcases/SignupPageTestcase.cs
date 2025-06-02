using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using System;

namespace ProjectTestcases

{
    [TestClass]
    public class SignUpDALTest
    {
        private SignUpDAL _signUpDAL;

        [TestInitialize]
        public void Setup()
        {
            _signUpDAL = new SignUpDAL();
        }

        [TestMethod]
        public void TestSetupAccount_ValidData_ReturnsSuccess()
        {
            string firstName = "John";
            string lastName = "Doe";
            string fatherName = "Richard Doe";
            int age = 30;
            string gender = "Male";
            string phoneNumber = "12345678901"; 
            string address = "123 Main St";
            string cnic = "1234567890123"; // CNIC without hyphens
            string email = "john.doe@example.com";
            string password = "password123";
            string accountType = "Standard";
            int branch = 1;
            int admin = 0;

            // Act: Call the SetupAccount method
            string result = _signUpDAL.SetupAccount(firstName, lastName, fatherName, age, gender, phoneNumber, address, cnic, email, password, accountType, branch, admin);

            // Assert: Check if the result is not an error message
            Assert.IsFalse(result.Contains("Error"));
        }

        [TestMethod]
        public void TestSetupAccount_InvalidCnic_ReturnsError()
        {
            // Arrange: Use invalid CNIC (with hyphens)
            string firstName = "John";
            string lastName = "Doe";
            string fatherName = "Richard Doe";
            int age = 30;
            string gender = "Male";
            string phoneNumber = "12345678901";
            string address = "123 Main St";
            string cnic = "12345-6789012-3"; // Invalid CNIC with hyphens
            string email = "john.doe@example.com";
            string password = "password123";
            string accountType = "Standard";
            int branch = 1;
            int admin = 0;

            // Act: Call the SetupAccount method
            string result = _signUpDAL.SetupAccount(firstName, lastName, fatherName, age, gender, phoneNumber, address, cnic, email, password, accountType, branch, admin);

            // Assert: Check if the result contains an error message
            Assert.IsTrue(result.Contains("Error"));
        }

        [TestMethod]
        public void TestSetupAccount_InvalidPhoneNumber_ReturnsError()
        {
            // Arrange: Use invalid phone number (not 11 digits)
            string firstName = "John";
            string lastName = "Doe";
            string fatherName = "Richard Doe";
            int age = 30;
            string gender = "Male";
            string phoneNumber = "12345"; // Invalid phone number (less than 11 digits)
            string address = "123 Main St";
            string cnic = "1234567890123"; // Valid CNIC without hyphens
            string email = "john.doe@example.com";
            string password = "password123";
            string accountType = "Standard";
            int branch = 1;
            int admin = 0;

            // Act: Call the SetupAccount method
            string result = _signUpDAL.SetupAccount(firstName, lastName, fatherName, age, gender, phoneNumber, address, cnic, email, password, accountType, branch, admin);

            // Assert: Intentionally check for success instead of error to cause failure
            Assert.IsFalse(result.Contains("Error")); // This will fail since the phone number is invalid
        }


        [TestMethod]
        public void TestSetupAccount_EmptyField_ReturnsError()
        {
            string firstName = "";
            string lastName = "Doe";
            string fatherName = "Richard Doe";
            int age = 30;
            string gender = "Male";
            string phoneNumber = "12345678901"; 
            string address = "123 Main St";
            string cnic = "1234567890123"; 
            string email = "john.doe@example.com";
            string password = "password123";
            string accountType = "Standard";
            int branch = 1;
            int admin = 0;

            string result = _signUpDAL.SetupAccount(firstName, lastName, fatherName, age, gender, phoneNumber, address, cnic, email, password, accountType, branch, admin);
            Assert.IsTrue(result.Contains("Error"));
        }

        [TestCleanup]
        public void Cleanup()
        {
           
            _signUpDAL = null;
        }
    }
}

using System;
using System.Linq;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class PasswordChangeBL
    {
        PasswordChangeDAL dal = new PasswordChangeDAL();

        public string ChangePassword(int accountNo, string currentPassword, string newPassword, string confirmPassword)
        {
            // Check if new password matches confirm password
            if (newPassword != confirmPassword)
            {
                return "Error: New password does not match confirm password.";
            }

            // Check if the new password meets the requirements
            if (!IsPasswordValid(newPassword))
            {
                return "Error: Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one special character, and one number.";
            }

            // Retrieve current password of the logged-in account from the DAL
            string currentLoggedInPassword = dal.GetCurrentPassword(accountNo);

            // Validate if the current password provided by the user matches the current logged-in password
            if (currentPassword != currentLoggedInPassword)
            {
                return "Error: Current password is incorrect.";
            }

            // Update password in the database through the DAL
            return dal.UpdatePassword(accountNo, newPassword);
        }

        // Method to check if the password meets the requirements
        private bool IsPasswordValid(string password)
        {
            // Check if the password is at least 8 characters long
            if (password.Length < 8)
            {
                return false;
            }

            // Check if the password contains at least one uppercase letter
            if (!password.Any(char.IsUpper))
            {
                return false;
            }

            // Check if the password contains at least one lowercase letter
            if (!password.Any(char.IsLower))
            {
                return false;
            }

            // Check if the password contains at least one number
            if (!password.Any(char.IsDigit))
            {
                return false;
            }

            // Check if the password contains at least one special character
            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                return false;
            }

            return true;
        }
    }
}

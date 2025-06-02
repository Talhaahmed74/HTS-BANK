using System;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class MobileRechargeData
    {
        // Using centralized connection string from Configuration
        private readonly string _connectionString = Configuration.ConnectionString;

        public int GetReceiverAccount(string phoneNumber)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Account_No FROM Accounts WHERE Account_PhoneNumber = @PhoneNumber";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int receiverAccount))
                    {
                        return receiverAccount;
                    }
                    else
                    {
                        return 0; // Return 0 or another value to indicate the account was not found
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0; // Return 0 or another value to indicate an error
                }
            }
        }

        public bool ValidatePhoneNumber(int receiverAccount, string phoneNumber)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(1) FROM Accounts WHERE Account_No = @AccountNo AND Account_PhoneNumber = @PhoneNumber";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@AccountNo", receiverAccount);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    // Handle the exception (e.g., log it)
                    Console.WriteLine(ex.Message);
                    return false; // Return false to indicate an error
                }
            }
        }

        public bool AddAmountToReceiver(int receiverAccount, decimal amount)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE Balance
                                     SET Current_Balance = Current_Balance + @Amount
                                     WHERE Account_No = @AccountNo";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@AccountNo", receiverAccount);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Handle the exception (e.g., log it)
                    Console.WriteLine(ex.Message);
                    return false; // Return false to indicate an error
                }
            }
        }

        public bool SubtractAmountFromSender(int senderAccount, decimal amount)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE Accounts
                                     SET Account_Balance = Account_Balance - @Amount
                                     WHERE Account_No = @AccountNo";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@AccountNo", senderAccount);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Handle the exception (e.g., log it)
                    Console.WriteLine(ex.Message);
                    return false; // Return false to indicate an error
                }
            }
        }
    }
}

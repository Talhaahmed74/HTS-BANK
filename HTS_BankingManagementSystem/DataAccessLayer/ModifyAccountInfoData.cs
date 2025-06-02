using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class ModifyAccountInfoData
    {
        // Using centralized connection string from Configuration
        private static readonly string connectionString = Configuration.ConnectionString;

        public int UpdateAddress(int accountNo, string address)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // Step 1: Update the address in Accounts table
                    string updateQuery = "UPDATE Accounts SET Account_Address = @Address WHERE Account_No = @AccountNo";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction);
                    updateCommand.Parameters.AddWithValue("@Address", address);
                    updateCommand.Parameters.AddWithValue("@AccountNo", accountNo);
                    int rowsUpdated = updateCommand.ExecuteNonQuery();

                    // Step 2: Delete the request from AccountInfoUpdateRequests table
                    string deleteQuery = "DELETE FROM AccountInfoUpdateRequests WHERE AccountNumber = @AccountNo";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction);
                    deleteCommand.Parameters.AddWithValue("@AccountNo", accountNo);
                    int rowsDeleted = deleteCommand.ExecuteNonQuery();

                    // Commit the transaction if both operations succeed
                    transaction.Commit();

                    return rowsUpdated; // Return the number of rows updated (should be 1) or handle as needed
                }
                catch (Exception ex)
                {
                    // Rollback the transaction on error
                    transaction?.Rollback();

                    // Handle exception as needed
                    Console.WriteLine("Error: " + ex.Message);
                    return -1; // Or throw exception
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}

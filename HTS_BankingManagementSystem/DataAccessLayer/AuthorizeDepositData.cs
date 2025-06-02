using System;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class AuthorizeDepositData
    {
        // Using centralized connection string
        private static readonly string connectionString = Configuration.ConnectionString;

        public bool DepositAmount(int accountNumber, decimal amount)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = "UPDATE Accounts SET Account_Balance = Account_Balance + @Amount WHERE Account_No = @AccountNumber";

                        using (SqlCommand command = new SqlCommand(query, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Amount", amount);
                            command.Parameters.AddWithValue("@AccountNumber", accountNumber);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                // Commit the transaction if the update is successful
                                transaction.Commit();
                                return true;
                            }
                            else
                            {
                                // Rollback if no rows were affected
                                transaction.Rollback();
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Rollback the transaction in case of an error
                        transaction.Rollback();
                        Console.WriteLine("Error: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}

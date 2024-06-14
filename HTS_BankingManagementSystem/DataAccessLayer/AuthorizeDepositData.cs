using System;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer
{
    public class AuthorizeDepositData
    {
        private string connectionString;

        public AuthorizeDepositData()
        {
            connectionString = "Data Source=DESKTOP-V9FJ71D\\SQLEXPRESS;Initial Catalog=HTS_BANK_FINAL;Integrated Security=True";
        }

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
                                transaction.Commit();
                                return true;
                            }
                            else
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}

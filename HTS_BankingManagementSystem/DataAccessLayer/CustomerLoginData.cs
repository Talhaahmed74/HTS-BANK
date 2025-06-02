using System;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class CustomerLoginData
    {
        // Using centralized connection string from Configuration
        private static readonly string connectionString = Configuration.ConnectionString;

        public bool VerifyLogin(int accountNo, string password)
        {
            bool isAuthenticated = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Login_Account", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add parameters to the stored procedure
                    cmd.Parameters.AddWithValue("@Account_No", accountNo);
                    cmd.Parameters.AddWithValue("@Account_Password", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Check if the account number and password match
                        int storedAccountNo = reader.GetInt32(0); // Assuming the first column is Account_No
                        string storedPassword = reader.GetString(1); // Assuming the second column is Account_Password
                        if (accountNo == storedAccountNo && password == storedPassword)
                        {
                            isAuthenticated = true;
                        }
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine("Error: " + ex.Message);
            }

            return isAuthenticated;
        }
    }
}

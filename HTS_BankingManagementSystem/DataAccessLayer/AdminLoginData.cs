using System;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class AdminLoginData
    {
        private readonly SqlConnection conn = new SqlConnection("Data Source=DESKTOP-V9FJ71D\\SQLEXPRESS;Initial Catalog=HTS_BANK_FINAL;Integrated Security=True");

        public bool VerifyLogin(int accountNo, string password)
        {
            bool isAuthenticated = false;
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("Admin_Login_Account", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // Add parameters to the stored procedure
                cmd.Parameters.AddWithValue("@Admin_Id", accountNo);
                cmd.Parameters.AddWithValue("@Admin_Password", password);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int storedAccountNo = reader.GetInt32(0);
                    string storedPassword = reader.GetString(1);
                    if (accountNo == storedAccountNo && password == storedPassword)
                    {
                        isAuthenticated = true;
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isAuthenticated;
        }
    }
}

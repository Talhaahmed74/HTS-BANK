using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class SignUpDAL
    {
        private readonly string _connectionString = "Data Source=DESKTOP-V9FJ71D\\SQLEXPRESS;Initial Catalog=HTS_BANK_FINAL;Integrated Security=True";

        public string SetupAccount(string firstName, string lastName, string fatherName, int age, string gender, string phoneNumber, string address, string cnic, string email, string password, string accountType, int branch, int admin)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spSignup", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@fatherName", fatherName);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@cnic", cnic);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@accountType", accountType);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@branchId", branch);
                    cmd.Parameters.AddWithValue("@adminId", admin);

                    try
                    {
                        conn.Open();
                        var result = cmd.ExecuteScalar();
                        return result?.ToString() ?? "Error: No account created";
                    }
                    catch (SqlException ex)
                    {
                        return "Error: " + ex.Message;
                    }
                }
            }
        }
    }
}

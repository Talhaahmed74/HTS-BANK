using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class ModifyInfoData
    {
        // Using centralized connection string from Configuration
        private static readonly string connectionString = Configuration.ConnectionString;

        public static List<UpdateRequest> GetRequests(int accountNo)
        {
            List<UpdateRequest> requests = new List<UpdateRequest>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                             SELECT 
                            aiur.AccountNumber,
                            ac.Account_First_Name + ' ' + ac.Account_Last_Name AS Account_Name,
                            ac.Account_Address,
                            ac.Account_Type,
                            ac.Account_PhoneNumber,
                            aiur.RequestDescription 
                        FROM AccountInfoUpdateRequests aiur 
                        LEFT JOIN Accounts ac ON ac.Account_No = aiur.AccountNumber
                        WHERE Admin_Id = @AccountNumber";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AccountNumber", accountNo);

                connection.Open();
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var request = new UpdateRequest
                        {
                            AccountNumber = reader.GetInt32(reader.GetOrdinal("AccountNumber")),
                            AccountName = reader.GetString(reader.GetOrdinal("Account_Name")),
                            AccountAddress = reader.GetString(reader.GetOrdinal("Account_Address")),
                            AccountType = reader.GetString(reader.GetOrdinal("Account_Type")),
                            AccountPhoneNumber = reader.GetString(reader.GetOrdinal("Account_PhoneNumber")),
                            RequestDescription = reader.GetString(reader.GetOrdinal("RequestDescription"))
                        };
                        requests.Add(request);
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle the exception appropriately
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return requests;
        }

        public class UpdateRequest
        {
            public int AccountNumber { get; set; }
            public string AccountName { get; set; }
            public string AccountAddress { get; set; }
            public string AccountType { get; set; }
            public string AccountPhoneNumber { get; set; }
            public string RequestDescription { get; set; }
        }
    }
}

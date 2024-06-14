using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlClient; 

namespace DataAccessLayer
{
    public class SearchAccountInfoDAL
    {
        private readonly string _connectionString = "Data Source=DESKTOP-V9FJ71D\\SQLEXPRESS;Initial Catalog=HTS_BANK_FINAL;Integrated Security=True";

        public AccountInfo GetAccountInfo(int accountNo, int adminId)
        {
            AccountInfo accountInfo = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"   SELECT
	                                bran.Branch_Address,
	                                acc.Account_No,
	                                acc.Account_Balance ,
                                    acc.Account_First_Name ,
                                    acc.Account_Last_Name ,		
                                    acc.Account_CNIC,  
                                    acc.Account_Age ,
                                    acc.Account_Email ,
                                    acc.Account_Address,
	                                acc.Account_Type,
	                                acc.Account_PhoneNumber,
	                                acc.Account_Gender,
	                                acc.Account_Father_Name
                                    FROM Accounts acc
                                    LEFT JOIN Branch bran On bran.Branch_Id = acc.Branch_Id
                                    WHERE Account_No = @Account_No AND acc.Admin_Id = @Admin_Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Account_No", accountNo);
                    command.Parameters.AddWithValue("@Admin_Id", adminId);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            accountInfo = new AccountInfo
                            {
                                AccountNo = reader.GetInt32(reader.GetOrdinal("Account_No")),
                                FirstName = reader.GetString(reader.GetOrdinal("Account_First_Name")),
                                LastName = reader.GetString(reader.GetOrdinal("Account_Last_Name")),
                                FatherName = reader.GetString(reader.GetOrdinal("Account_Father_Name")),
                                Age = reader.GetInt32(reader.GetOrdinal("Account_Age")),
                                Gender = reader.GetString(reader.GetOrdinal("Account_Gender")),
                                Email = reader.GetString(reader.GetOrdinal("Account_Email")),
                                Balance = reader.GetDecimal(reader.GetOrdinal("Account_Balance")),
                                PhoneNumber = reader.GetString(reader.GetOrdinal("Account_PhoneNumber")),
                                Address = reader.GetString(reader.GetOrdinal("Account_Address")),
                                Branch = reader.GetString(reader.GetOrdinal("Branch_Address")),
                                CNIC = reader.GetString(reader.GetOrdinal("Account_CNIC")),
                                AccountType = reader.GetString(reader.GetOrdinal("Account_Type"))
                                // Add more properties as needed
                            };
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions as needed
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
            return accountInfo;
        }

        
    }
    public class AccountInfo
    {
       
        public int AccountNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Branch { get; set; }
        public string CNIC { get; set; }
        public string AccountType { get; set; }
    }
}

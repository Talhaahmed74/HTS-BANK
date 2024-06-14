using System;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class AccountInfoData
    {

        private readonly string _connectionString = "Data Source=DESKTOP-V9FJ71D\\SQLEXPRESS;Initial Catalog=HTS_BANK_FINAL;Integrated Security=True";

        public Account GetAccountInfo(int accountNo)
        {
            string query = @"   SELECT 
                                Account_No, 
                                Account_Balance, 
                                Account_First_Name, 
                                Account_Last_Name, 
                                Account_Father_Name, 
                                Account_CNIC,
                                Account_Gender,
                                Account_Type,
                                Account_Age, 
                                Account_Email, 
                                Account_Address, 
                                Account_PhoneNumber, 
                                Branch_Address 
                                FROM Accounts ac
                                LEFT JOIN Branch br ON ac.Branch_Id = br.Branch_Id
                                WHERE Account_No =  @AccountNo";

            Account account = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AccountNo", accountNo);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            account = new Account
                            {
                                AccountNo = reader.GetInt32(reader.GetOrdinal("Account_No")),
                                Balance = reader.GetDecimal(reader.GetOrdinal("Account_Balance")),
                                FirstName = reader.GetString(reader.GetOrdinal("Account_First_Name")),
                                FatherName = reader.GetString(reader.GetOrdinal("Account_Father_Name")),
                                LastName = reader.GetString(reader.GetOrdinal("Account_Last_Name")),
                                CNIC = reader.GetString(reader.GetOrdinal("Account_CNIC")),
                                Gender = reader.GetString(reader.GetOrdinal("Account_Gender")),
                                AccountType = reader.GetString(reader.GetOrdinal("Account_Type")),
                                Age = reader.GetInt32(reader.GetOrdinal("Account_Age")),
                                Email = reader.GetString(reader.GetOrdinal("Account_Email")),
                                Address = reader.GetString(reader.GetOrdinal("Account_Address")),
                                BranchAddress = reader.GetString(reader.GetOrdinal("Branch_Address")),
                                PhoneNumber = reader.GetString(reader.GetOrdinal("Account_PhoneNumber")),
                            };
                        }
                    }
                }
            }

            return account;
        }

        public int SendInfoUpdateRequest(string description, int accountNo)
        {
            string query = @"INSERT INTO AccountInfoUpdateRequests (AccountNumber , RequestDescription) 
                                VALUES (@Account_ID  , @Description)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Account_ID", accountNo);
                    cmd.Parameters.AddWithValue("@Description", description);

                    conn.Open();
                    object result = cmd.ExecuteNonQuery();
                    int rowsUpdated = 0;

                    if (int.TryParse(Convert.ToString(result), out rowsUpdated))
                    {
                        return rowsUpdated ;
                    }
                    return 0;
                }

            }
        }

    public bool UpdatePhoneNumber(string newNumber, string accountNo)
        {
            string query = @"UPDATE Accounts
                                SET Account_PhoneNumber = @NewNumber
                                WHERE Account_No = @AccountNo";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AccountNo", accountNo);
                    cmd.Parameters.AddWithValue("@NewNumber", newNumber);

                    conn.Open();
                    object result = cmd.ExecuteNonQuery();
                    int rowsUpdated = 0 ;

                    if (int.TryParse(Convert.ToString(result), out rowsUpdated))
                    {
                        return rowsUpdated > 0;
                    }
                    return false;
                }

            }
        }

        public class Account
        {
            public int AccountNo { get; set; }
            public decimal Balance { get; set; }
            public string FirstName { get; set; }
            public string FatherName { get; set; }
            public string LastName { get; set; }
            public string CNIC { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
            public string BranchAddress { get; set; }
            public string Gender { get; set; }
            public string AccountType { get; set; }
        }
    }
}

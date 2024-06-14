using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class AdminStatsTransactionData
    {
        private static readonly string connectionString = "Data Source=DESKTOP-V9FJ71D\\SQLEXPRESS;Initial Catalog=HTS_BANK_FINAL;Integrated Security=True";

        public static (List<DepositHistory> deposits, int count) ViewDeposits(int adminId, string dateInterval)
        {
            var deposits = new List<DepositHistory>();
            string dateCondition;
            int totalRecords = 0;

            switch (dateInterval.ToLower())
            {
                case "weekly":
                    dateCondition = "d.Deposit_Date >= DATEADD(WEEK, -1, GETDATE())";
                    break;
                case "monthly":
                    dateCondition = "d.Deposit_Date >= DATEADD(MONTH, -1, GETDATE())";
                    break;
                case "yearly":
                    dateCondition = "d.Deposit_Date >= DATEADD(YEAR, -1, GETDATE())";
                    break;
                default:
                    throw new ArgumentException("Invalid date interval");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        d.Deposited_By,
                        d.Receiver,
                        d.Account_No,
                        d.Deposit_Amount,
                        d.Deposit_Date,
                        d.Deposit_Status,
                        ac.Account_First_Name + ' ' + ac.Account_Last_Name AS Account_Name,
                    FROM 
                        Deposit d
                    LEFT JOIN 
                        Accounts ac ON ac.Account_No = d.Account_No
                    WHERE 
                        " + dateCondition + @"
                        AND (d.Deposited_By = @AdminId OR d.Receiver = @AdminId)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AdminId", adminId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var deposit = new DepositHistory
                        {
                            DepositedBy = reader.GetInt32(reader.GetOrdinal("Deposited_By")),
                            Receiver = reader.IsDBNull(reader.GetOrdinal("Receiver")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("Receiver")),
                            AccountNo = reader.GetInt32(reader.GetOrdinal("Account_No")),
                            DepositAmount = reader.GetDecimal(reader.GetOrdinal("Deposit_Amount")),
                            DepositDate = reader.GetDateTime(reader.GetOrdinal("Deposit_Date")),
                            DepositStatus = reader.IsDBNull(reader.GetOrdinal("Deposit_Status")) ? null : reader.GetString(reader.GetOrdinal("Deposit_Status")),
                            AccountName = reader.GetString(reader.GetOrdinal("Account_Name"))
                        };
                        deposits.Add(deposit);
                    }
                    reader.Close();

                    // Count query
                    string countQuery = @"
                        SELECT 
                            COUNT(*)
                        FROM 
                            Deposit d
                        WHERE 
                            " + dateCondition + @"
                            AND (d.Deposited_By = @AdminId OR d.Receiver = @AdminId)";

                    SqlCommand countCommand = new SqlCommand(countQuery, connection);
                    countCommand.Parameters.AddWithValue("@AdminId", adminId);
                    totalRecords = (int)countCommand.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                    Console.WriteLine("Connection closed.");
                }

                return (deposits, totalRecords);
            }
        }

        public class DepositHistory
        {
            public int DepositedBy { get; set; }
            public int? Receiver { get; set; }
            public int AccountNo { get; set; }
            public decimal DepositAmount { get; set; }
            public DateTime DepositDate { get; set; }
            public string DepositStatus { get; set; }
            public string AccountName { get; set; }
           
        }
    }
}

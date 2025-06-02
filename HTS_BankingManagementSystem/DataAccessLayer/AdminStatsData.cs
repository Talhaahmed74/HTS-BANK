using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class AdminStatsTransactionData
    {
        // Use the centralized connection string from Configuration class
        private static readonly SqlConnection conn = new SqlConnection(Configuration.ConnectionString);

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

            // Use the already instantiated SqlConnection (conn)
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = @"
                    SELECT 
                        d.Deposited_By,
                        d.Receiver,
                        d.Account_No,
                        d.Deposit_Amount,
                        d.Deposit_Date,
                        d.Deposit_Status,
                        ac.Account_First_Name + ' ' + ac.Account_Last_Name AS Account_Name
                    FROM 
                        Deposit d
                    LEFT JOIN 
                        Accounts ac ON ac.Account_No = d.Account_No
                    WHERE 
                        " + dateCondition + @"
                        AND (d.Deposited_By = @AdminId OR d.Receiver = @AdminId)";

                command.Parameters.AddWithValue("@AdminId", adminId);

                try
                {
                    conn.Open();
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

                    SqlCommand countCommand = new SqlCommand(countQuery, conn);
                    countCommand.Parameters.AddWithValue("@AdminId", adminId);
                    totalRecords = (int)countCommand.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
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

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class AdminStatsBillPaymentData
    {
        private static readonly string connectionString = "Data Source=DESKTOP-V9FJ71D\\SQLEXPRESS;Initial Catalog=HTS_BANK_FINAL;Integrated Security=True";


        public static (List<BillPayment> transaction, int count) ViewTransactions(int adminId, string dateInterval)
        {
            var transactions = new List<BillPayment>();
            string dateCondition;
            int totalRecords = 0;

            switch (dateInterval.ToLower())
            {
                case "weekly":
                    dateCondition = "bp.Payment_Date >= DATEADD(WEEK, -1, GETDATE())";
                    break;
                case "monthly":
                    dateCondition = "bp.Payment_Date >= DATEADD(MONTH, -1, GETDATE())";
                    break;
                case "yearly":
                    dateCondition = "bp.Payment_Date >= DATEADD(YEAR, -1, GETDATE())";
                    break;
                default:
                    throw new ArgumentException("Invalid date interval");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = @"SELECT 
                                        Bill_Amount, 
                                        ac.Account_No,
                                        Payment_Date,
                                        Bill_Type
                                        from BillPayment bp
                                        LEFT JOIN Accounts ac 
                                        ON ac.Account_No = bp.Account_No
                                        WHERE bp.IsPaid = 1 
                                        AND Admin_Id = @AdminId
                                        AND " + dateCondition;

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AdminId", adminId);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var transaction = new BillPayment
                        {
                            AccountNo = reader.GetInt32(reader.GetOrdinal("Account_No")),
                            BillType = reader.GetString(reader.GetOrdinal("Bill_Type")),
                            Date = reader.GetDateTime(reader.GetOrdinal("Payment_Date")),
                            Amount = reader.GetDecimal(reader.GetOrdinal("Bill_Amount"))
                        };
                        transactions.Add(transaction);
                    }
                    reader.Close();
                    string countQuery = @"SELECT COUNT(*)
                                        from BillPayment bp
                                        LEFT JOIN Accounts ac 
                                        ON ac.Account_No = bp.Account_No
                                        WHERE bp.IsPaid = 1 
                                        AND Admin_Id = @AdminId";
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

                return (transactions, totalRecords);
            }
        }

        public class BillPayment
        {
            public int AccountNo { get; set; }
            public string BillType { get; set; }
            public DateTime Date { get; set; }
            public decimal Amount { get; set; }
        }
    }
}

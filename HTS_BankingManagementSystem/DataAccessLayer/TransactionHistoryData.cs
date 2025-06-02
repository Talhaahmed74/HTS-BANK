using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class TransactionHistoryData
    {
        // Use the centralized connection string from Configuration class
        private static readonly string connectionString = Configuration.ConnectionString;

        public static List<Transaction> GetTransactionHistory(int accountNo)
        {
            var transactions = new List<Transaction>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                    th.Receiver_Account_Id, 
                    th.Transaction_Type, 
                    th.Amount, 
                    th.Transaction_Date, 
                    ac.Account_First_Name + ' ' + ac.Account_Last_Name AS Sender,
                    r_ac.Account_First_Name + ' ' + r_ac.Account_Last_Name AS Receiver
                    FROM
                    Transaction_History th JOIN Accounts ac ON ac.Account_No = th.Sender_Account_Id
                    LEFT JOIN Accounts r_ac ON r_ac.Account_No = th.Receiver_Account_Id
                    WHERE Receiver_Account_Id = @AccountNo OR Sender_Account_Id = @AccountNo";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AccountNo", accountNo);

                connection.Open();
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var transaction = new Transaction
                        {
                            ReceiverName = reader.IsDBNull(reader.GetOrdinal("Receiver")) ? "-" : reader.GetString(reader.GetOrdinal("Receiver")),
                            SenderName = reader.GetString(reader.GetOrdinal("Sender")),
                            Date = reader.GetDateTime(reader.GetOrdinal("Transaction_Date")),
                            Amount = reader.GetDecimal(reader.GetOrdinal("Amount")),
                            Type = reader.GetString(reader.GetOrdinal("Transaction_Type")),
                            Status = reader.IsDBNull(reader.GetOrdinal("Receiver_Account_Id"))
                                    ? "Paid"
                                    : (reader.GetInt32(reader.GetOrdinal("Receiver_Account_Id")) == accountNo ? "Received" : "Sent")
                        };
                        transactions.Add(transaction);
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

            return transactions;
        }

        public class Transaction
        {
            public int TransactionID { get; set; }
            public string SenderName { get; set; }
            public string ReceiverName { get; set; }
            public DateTime Date { get; set; }
            public Decimal Amount { get; set; }
            public string Type { get; set; }
            public string Status { get; set; }
        }
    }
}

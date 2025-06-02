using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class BillPaymentData
    {
        // Using centralized connection string from Configuration
        private static readonly string connectionString = Configuration.ConnectionString;

        // PayBill Method to process bill payment
        public static bool PayBill(int accountNo, string billType, decimal billAmount, string billPaymentId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Check account balance
                    decimal accountBalance = GetAccountBalance(accountNo, connection);
                    if (accountBalance < billAmount)
                    {
                        // Insufficient funds
                        return false;
                    }

                    // Update account balance
                    bool balanceUpdated = UpdateAccountBalance(accountNo, accountBalance - billAmount, connection);
                    if (!balanceUpdated)
                    {
                        return false;
                    }

                    // Process bill payment
                    string query = @"UPDATE BillPayment
                                     SET IsPaid = 1
                                     WHERE BillPayment_Id = @BillPaymentId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@BillPaymentId", billPaymentId);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Log error (for production environments, use logging libraries like Serilog or NLog)
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        // Update payment status after processing
        private static bool UpdateDuePaymentByBillPaymentId(string billPaymentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"UPDATE BillPayment
                                 SET Bill_Amount = 0
                                 WHERE BillPayment_ID = @BillPaymentID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BillPaymentID", billPaymentId);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Get Bill Details by BillPaymentId and AccountNo
        public static (string billType, string billAmount) GetBillDetails(string billPaymentId, string accountNo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT Bill_Type, Bill_Amount 
                                 FROM BillPayment 
                                 WHERE BillPayment_ID = @BillPaymentID
                                 AND Account_No = @AccountNo";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BillPaymentID", billPaymentId);
                command.Parameters.AddWithValue("@AccountNo", accountNo);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string billType = reader["Bill_Type"].ToString();
                        string billAmount = reader["Bill_Amount"].ToString();
                        return (billType, billAmount);
                    }
                    else
                    {
                        // Handle case where no data is found
                        return (null, null);
                    }
                }
            }
        }

        // Get account balance for a given account number
        protected static decimal GetAccountBalance(int accountNo, SqlConnection connection)
        {
            string query = "SELECT Account_Balance FROM Accounts WHERE Account_No = @AccountNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountNo", accountNo);

            object result = command.ExecuteScalar();
            return result != null ? Convert.ToDecimal(result) : 0;
        }

        // Update account balance after payment
        protected static bool UpdateAccountBalance(int accountNo, decimal newBalance, SqlConnection connection)
        {
            string query = "UPDATE Accounts SET Account_Balance = @NewBalance WHERE Account_No = @AccountNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NewBalance", newBalance);
            command.Parameters.AddWithValue("@AccountNo", accountNo);

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        // Get a list of due bills for a given account
        public static List<BillPayment> GetDueBills(int accountNo)
        {
            List<BillPayment> bills = new List<BillPayment>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT BillPayment_ID, Bill_Type, Bill_Amount, Payment_Date FROM BillPayment WHERE Account_No = @AccountNo";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@AccountNo", accountNo);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var bill = new BillPayment
                        {
                            BillPaymentID = reader.GetInt32(0),
                            BillType = reader.GetString(1),
                            BillAmount = reader.GetDecimal(2),
                            PaymentDate = reader.GetDateTime(3)
                        };
                        bills.Add(bill);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error (for production environments, use logging libraries like Serilog or NLog)
                Console.WriteLine("Error: " + ex.Message);
            }

            return bills;
        }
    }

    public class BillPayment
    {
        public int BillPaymentID { get; set; }
        public string BillType { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}

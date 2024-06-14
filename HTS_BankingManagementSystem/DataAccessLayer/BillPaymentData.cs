using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class BillPaymentData
    {
        private static readonly string connectionString = "Data Source=DESKTOP-V9FJ71D\\SQLEXPRESS;Initial Catalog=HTS_BANK_FINAL;Integrated Security=True";
        public static SqlConnection connection = null;

        public BillPaymentData()
        {
            connection = new SqlConnection(connectionString);
        }

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

                    // Deduct amount from account balance
                    bool balanceUpdated = UpdateAccountBalance(accountNo, accountBalance - billAmount, connection);
                    if (!balanceUpdated)
                    {
                        return false;
                    }

                    // Process bill payment
                    //string query = "INSERT INTO BillPayment (Account_No, Bill_Type, Bill_Amount, Payment_Date) VALUES (@AccountNo, @BillType, @BillAmount, GETDATE())";
                    string query = @"UPDATE BillPayment
                                            SET IsPaid = 1
                                            WHERE BillPayment_Id = @BillPaymentId";
                    SqlCommand command = new SqlCommand(query, connection);
                    //command.Parameters.AddWithValue("@AccountNo", accountNo);
                    command.Parameters.AddWithValue("@BillPaymentId", billPaymentId);
                    //command.Parameters.AddWithValue("@BillAmount", billAmount);

                    int rowsAffected = command.ExecuteNonQuery();



                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Log error
                return false;
            }
        }

        private static bool UpdateDuePaymentByBillPaymentId(string billPaymentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"   UPDATE BillPayment
                                    SET Bill_Amount = 0
                                    WHERE BillPayment_ID = @BillPaymentID
                                ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BillPaymentID", billPaymentId);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;

            }
        }

        public static (string billtype, string billAmount) GetBillDetails(string billPaymentId, string AccountNo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT Bill_Type , Bill_Amount 
                                 FROM BillPayment 
                                 WHERE BillPayment_ID = @BillPaymentID
                                 AND Account_No = @AccountNo
                                ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BillPaymentID", billPaymentId);
                command.Parameters.AddWithValue("@AccountNo", AccountNo);

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

        private static decimal GetAccountBalance(int accountNo, SqlConnection connection)
        {
            string query = "SELECT Account_Balance FROM Accounts WHERE Account_No = @AccountNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountNo", accountNo);

            object result = command.ExecuteScalar();
            return result != null ? Convert.ToDecimal(result) : 0;
        }

        private static bool UpdateAccountBalance(int accountNo, decimal newBalance, SqlConnection connection)
        {
            string query = "UPDATE Accounts SET Account_Balance = @NewBalance WHERE Account_No = @AccountNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NewBalance", newBalance);
            command.Parameters.AddWithValue("@AccountNo", accountNo);

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public static List<BillPayment> GetDueBills(int accountNo)
        {
            List<BillPayment> bills = new List<BillPayment>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT BillPayment_ID, Bill_Type, Bill_Amount, Payment_Date FROM BillPayment WHERE Account_No = @AccountNo";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@AccountNo", accountNo);

                    connection.Open();
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
                // Log error
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

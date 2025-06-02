using System;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DepositData
    {
        // Using centralized connection string from Configuration
        private readonly string connectionString = Configuration.ConnectionString;

        public decimal GetAccountBalance(int accountNumber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Account_Balance FROM Accounts WHERE Account_No = @AccountNo";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AccountNo", accountNumber);

                connection.Open();
                object result = command.ExecuteScalar();
                connection.Close();

                if (result != null)
                {
                    return Convert.ToDecimal(result);
                }
                return -1; // Indicates account not found
            }
        }

        public bool TransferMoney(int currentAccountNumber, int receiverAccountNumber, decimal amount)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Add amount to receiver's account
                    string querySender = "UPDATE Accounts SET Account_Balance = Account_Balance + @Amount WHERE Account_No = @AccountNo";
                    SqlCommand commandSender = new SqlCommand(querySender, connection, transaction);
                    commandSender.Parameters.AddWithValue("@Amount", amount);
                    commandSender.Parameters.AddWithValue("@AccountNo", receiverAccountNumber);
                    commandSender.ExecuteNonQuery();

                    // Deduct amount from current account
                    string queryReceiver = "UPDATE Accounts SET Account_Balance = Account_Balance - @Amount WHERE Account_No = @AccountNo";
                    SqlCommand commandReceiver = new SqlCommand(queryReceiver, connection, transaction);
                    commandReceiver.Parameters.AddWithValue("@Amount", amount);
                    commandReceiver.Parameters.AddWithValue("@AccountNo", currentAccountNumber);
                    commandReceiver.ExecuteNonQuery();

                    // Store Deposit Record
                    string depositRecord = @"INSERT INTO Deposit (Deposited_By, Receiver, Deposit_Amount, Deposit_Date)
                                            VALUES(@CurrentAccount, @DepositedTo, @DepositAmount, GETDATE())";
                    SqlCommand commandDeposit = new SqlCommand(depositRecord, connection, transaction);
                    commandDeposit.Parameters.AddWithValue("@DepositAmount", amount);
                    commandDeposit.Parameters.AddWithValue("@DepositedTo", receiverAccountNumber);
                    commandDeposit.Parameters.AddWithValue("@CurrentAccount", currentAccountNumber);
                    commandDeposit.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}

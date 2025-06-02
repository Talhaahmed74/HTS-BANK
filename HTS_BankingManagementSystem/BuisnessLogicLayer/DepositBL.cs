using System;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class TransactionBLL
    {
        private DepositData dal = new DepositData();

        public string PerformTransaction(int receiverAccountNumber, decimal amount, int currentAccountNumber)
        {
            if (amount <= 0)
            {
                return "Amount should be greater than zero.";
            }

            if (amount > 25000)
            {
                return "For transactions greater than 25,000, please contact your bank branch.";
            }

            decimal senderBalance = dal.GetAccountBalance(currentAccountNumber);
            if (senderBalance == -1)
            {
                return "Sender account not found.";
            }

            decimal receiverBalance = dal.GetAccountBalance(receiverAccountNumber);
            if (receiverBalance == -1)
            {
                return "Receiver account not found.";
            }

            if (senderBalance < amount)
            {
                return "Insufficient balance in sender's account.";

            }

            bool isSuccess = dal.TransferMoney(currentAccountNumber, receiverAccountNumber, amount);
            return isSuccess ? "Transaction successful." : "Transaction failed. Please try again.";
        }
    }
}

using System.Collections.Generic;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class TransactionHistoryBL
    {
        public List<TransactionHistoryData.Transaction> GetTransactionHistory(int accountNo)
        {
            return TransactionHistoryData.GetTransactionHistory(accountNo);
        }
        
    }
}

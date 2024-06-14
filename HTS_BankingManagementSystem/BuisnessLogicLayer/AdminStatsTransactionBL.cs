using System.Collections.Generic;
using DataAccessLayer;

namespace BuisnessLogicLayer
{
    public class AdminStatsTransactionBL
    {
        public (List<AdminStatsTransactionData.DepositHistory> transaction , int count) ViewWeeklyTransactions(int adminId)
        {
            return AdminStatsTransactionData.ViewDeposits(adminId, "weekly");
        }

        public (List<AdminStatsTransactionData.DepositHistory> transaction, int count) ViewMonthlyTransactions(int adminId)
        {
            return AdminStatsTransactionData.ViewDeposits(adminId, "monthly");
        }

        public (List<AdminStatsTransactionData.DepositHistory> transaction, int count) ViewYearlyTransactions(int adminId)
        {
            return AdminStatsTransactionData.ViewDeposits(adminId, "yearly");
        }
    }
}

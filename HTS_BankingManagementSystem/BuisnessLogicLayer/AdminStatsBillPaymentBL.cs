using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BuisnessLogicLayer
{
    public class AdminStatsBillPaymentBL
    {
        public (List<AdminStatsBillPaymentData.BillPayment> transtransaction , int count) ViewWeeklyBillPayment(int adminId)
        {
            return AdminStatsBillPaymentData.ViewTransactions(adminId, "weekly");
        }

        public (List<AdminStatsBillPaymentData.BillPayment> transtransaction, int count) ViewMonthlyBillPayment(int adminId)
        {
            return AdminStatsBillPaymentData.ViewTransactions(adminId, "monthly");
        }

        public (List<AdminStatsBillPaymentData.BillPayment> transtransaction, int count) ViewYearlyBillPayment(int adminId)
        {
            return AdminStatsBillPaymentData.ViewTransactions(adminId, "yearly");
        }
    }
}

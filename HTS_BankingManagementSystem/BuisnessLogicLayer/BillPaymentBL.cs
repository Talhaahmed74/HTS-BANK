using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BillPaymentBL
    {
        public bool PayBill(int accountNo, string billType, decimal billAmount, string billPaymentId)
        {
            return BillPaymentData.PayBill(accountNo, billType, billAmount, billPaymentId);
        }

        public List<DataAccessLayer.BillPayment> GetDueBills(int accountNo)
        {
            return BillPaymentData.GetDueBills(accountNo);
        }

        public (string billtype, string billAmount) GetBillDetails(string billPaymentId, string AccountNo)
        {
            return BillPaymentData.GetBillDetails(billPaymentId, AccountNo);
        }
    }
}

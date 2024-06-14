using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AdminViewTransactionData
    {

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

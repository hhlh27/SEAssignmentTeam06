using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    public class ReservationPayment
    {
        public int TransactionId { get; set; }
        public string PaymentMethod { get; set; }
        public float PaymentAmt { get; set; }
        public bool TransactionSuccessStatus { get; set; }
        public string VoucherUsed { get; set; }

        public ReservationPayment(int transactionId, string paymentMethod, float paymentAmt, bool transactionSuccessStatus, string voucherUsed)
        {
            TransactionId = transactionId;
            PaymentMethod = paymentMethod;
            PaymentAmt = paymentAmt;
            TransactionSuccessStatus = transactionSuccessStatus;
            VoucherUsed = voucherUsed;
        }
    }
}

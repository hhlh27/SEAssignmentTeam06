using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    public class Voucher
    {
        public string VoucherId { get; set; }
        public int VoucherDiscount { get; set; }
        public ReservationPayment ReservationPayment { get; set; }

        public Voucher(string voucherId, int voucherDiscount)
        {
            VoucherId = voucherId;
            VoucherDiscount = voucherDiscount;
        }

        public Voucher() { }
    }
}

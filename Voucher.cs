using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    public class Voucher
    {
        public int VoucherId { get; set; }
        public string VoucherDiscount { get; set; }

        public Voucher(int voucherId, string voucherDiscount)
        {
            VoucherId = voucherId;
            VoucherDiscount = voucherDiscount;
        }
    }
}

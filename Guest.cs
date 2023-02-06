using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    public class Guest : Person
    {
        public string PersonalId { get; set; }
        public int ContactNum { get; set; }
        public double AccountBalance { get; set; }
        public int HotelId { get; set; }
        public List<Voucher> VoucherList { get; set; }
        public Reservation Reservation { get; set; }
    }
}

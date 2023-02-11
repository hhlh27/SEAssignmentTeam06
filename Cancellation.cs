using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    public class Cancellation
    {
        public string CancellationId { get; set; }
        public int ReservationId { get; set; }
        public DateTime CancellationDate { get; set; }
        public double AmtRefunded { get; set; }

        public Reservation Reservation { get; set; }
        public Cancellation(string cancellationId, int reservationId, DateTime cancellationDate, double amtRefund)
        {
            CancellationId = cancellationId;
            ReservationId = reservationId;
            CancellationDate = cancellationDate;
            AmtRefunded = amtRefund;
        }

        public Cancellation() { }
    }
}

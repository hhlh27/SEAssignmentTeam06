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
        public DateTime CancellationDate { get; set; }
        public double AmtRefunded { get; set; }

        public Cancellation(string cancellationId, DateTime cancellationDate, double amtRefund)
        {
            CancellationId = cancellationId;
            CancellationDate = cancellationDate;
            AmtRefunded = amtRefund;
        }
    }
}

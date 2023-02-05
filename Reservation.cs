using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string ReservationStatus { get; set; }
        public bool IsFullyPaid { get; set; }
        public DateTime DatePaid { get; set; }

        public Reservation(int reservationId, DateTime checkInDate, DateTime checkOutDate, string reservationStatus, bool isFullyPaid, DateTime datePaid)
        {
            ReservationId = reservationId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            ReservationStatus = reservationStatus;
            IsFullyPaid = isFullyPaid;
            DatePaid = datePaid;
        }

        public bool confirmReservation(bool isFullyPaid)
        {
            //implementation
            return true;
        }

        public void searchHotel(double budget, string hotelType, double reviewScore, string location, string facilities)
        {
            //implementation
        }

    }
}

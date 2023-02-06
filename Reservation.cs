using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    public class Reservation
    {  
        public int ReservationId { get; set; }
        public int GuestId { get; set; }
        public Room Room { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string ReservationStatus { get; set; }
        public DateTime DateCancelled
        {
            get
            {
                if (ReservationStatus == "Cancelled")
                {
                    return DateTime.Now;
                }
                else
                {
                    // If transaction success status is false, date paid is set to "01/01/0001 00:00:00"
                    return new DateTime();
                }
            }
        }

        public Reservation(int reservationId, int guestId, Room room, DateTime checkInDate, DateTime checkOutDate, string reservationStatus)
        {
            ReservationId = reservationId;
            GuestId = guestId;
            Room = room;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            ReservationStatus = reservationStatus;
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

        public void setReservationStatus(string reservationStatus)
        {
            this.ReservationStatus = reservationStatus;
        }

    }
}

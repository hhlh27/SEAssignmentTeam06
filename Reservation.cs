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
        public bool IsFullyPaid { get; set; }
        public DateTime DatePaid { get; set; }
        public double AmountDue
        {
            get 
            { 
                if (IsFullyPaid)
                {
                    return 0.00;
                }
                else
                {
                    return Room.Cost * (CheckOutDate - CheckInDate).TotalDays;
                }                
            }
        }

        public Reservation(int reservationId, int guestId, Room room, DateTime checkInDate, DateTime checkOutDate, string reservationStatus, bool isFullyPaid, DateTime datePaid)
        {
            ReservationId = reservationId;
            GuestId = guestId;
            Room = room;
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

        public void setReservationStatus(string reservationStatus)
        {
            this.ReservationStatus = reservationStatus;
        }

    }
}

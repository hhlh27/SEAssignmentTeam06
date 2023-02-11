using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    public class Reservation
    {  
        public int ReservationId { get; set; }
        public int GuestId { get; set; }
        public Room Room { get; set; } = new Room();
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string ReservationStatus { get; set; }
        public ReservationPayment ReservationPayment { get; set; }
        public Cancellation Cancellation { get; set; }

        public Reservation(int reservationId, int guestId, Room room, DateTime checkInDate, DateTime checkOutDate, string reservationStatus, ReservationPayment reservationPayment, Cancellation cancellation)
        {
            ReservationId = reservationId;
            GuestId = guestId;
            Room = room;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            ReservationStatus = reservationStatus;
            ReservationPayment = reservationPayment;
            Cancellation = cancellation;
        }

        public Reservation() { }

        public bool confirmReservation(bool isFullyPaid)
        {
            //implementation
            return true;
        }

        public Hotel searchHotel(double budget, string hotelType, double reviewScore, string location, string facilities)
        {
            //implementation
            return null;
        }

        public void setReservationStatus(string reservationStatus)
        {
            this.ReservationStatus = reservationStatus;
        }

        public void makeReservation(Hotel hotel, DateTime checkInDate, DateTime checkOutDate)
        {
           //implementation
        }
        public void makePayment(double price)
        {
            //implementation
        }
        public void sendEmail(Reservation reservation)
        {
            //implementation
        }
        public void contactHotel(Reservation reservation,Hotel hotel)
        {
            //implementation
        }
        public void checkIn(Reservation reservation)
        {
            //implementation
        }
        public void rateHotel( Hotel hotel)
        {
            //implementation
        }
        public void credit(double amount, Voucher voucher, Guest guestAccount)
        {
            //implementation
        }
    }
}

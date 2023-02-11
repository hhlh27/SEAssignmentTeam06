using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    public class ReservationPayment
    {
        public Reservation Reservation { get; set; }
        public Guest Guest { get; set; }
        public string TransactionId { get; set; }
        public IcaPersonnel IcaPersonnel { get; set; }
        public string PaymentMethod { get; set; }
        public bool TransactionSuccessStatus { get; set; }
        public Voucher VoucherUsed { get; set; }
        public DateTime DatePaid 
        { 
            get
            {
                if (TransactionSuccessStatus) 
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
        public double PaymentDue
        {
            get
            {
                if (TransactionSuccessStatus)
                {
                    return 0.00;
                }
                else
                {
                    if (PaymentMethod == "Credit Card")
                    {
                        if (Guest.Reservation.ReservationPayment.VoucherUsed != null)
                        {
                            double percent = (double)(100 - Guest.Reservation.ReservationPayment.VoucherUsed.VoucherDiscount) / (double)100;
                            return ((Guest.Reservation.Room.Cost * (Guest.Reservation.CheckOutDate - Guest.Reservation.CheckInDate).TotalDays) * 0.8) * percent;
                        }
                        else
                        {
                            return (Guest.Reservation.Room.Cost * (Guest.Reservation.CheckOutDate - Guest.Reservation.CheckInDate).TotalDays) * 0.8;
                        }                       
                    }
                    else
                    {
                        if (Guest.Reservation.ReservationPayment.VoucherUsed != null)
                        {
                            double percent = (double)(100 - Guest.Reservation.ReservationPayment.VoucherUsed.VoucherDiscount) / (double)100;
                            return (Guest.Reservation.Room.Cost * (Guest.Reservation.CheckOutDate - Guest.Reservation.CheckInDate).TotalDays) * percent;
                        }
                        else
                        {
                            return Guest.Reservation.Room.Cost * (Guest.Reservation.CheckOutDate - Guest.Reservation.CheckInDate).TotalDays;
                        }
                    }           
                }
            }
        }
        public double PaymentAmt
        {
            get
            {
                if (!TransactionSuccessStatus)
                {
                    return 0.00;
                }
                else
                {
                    if (PaymentMethod == "Credit Card")
                    {
                        if (Guest.Reservation.ReservationPayment.VoucherUsed != null)
                        {
                            double percent = (double)(100 - Guest.Reservation.ReservationPayment.VoucherUsed.VoucherDiscount) / (double)100;
                            return ((Guest.Reservation.Room.Cost * (Guest.Reservation.CheckOutDate - Guest.Reservation.CheckInDate).TotalDays) * 0.8) * percent;
                        }
                        else
                        {
                            return (Guest.Reservation.Room.Cost * (Guest.Reservation.CheckOutDate - Guest.Reservation.CheckInDate).TotalDays) * 0.8;
                        }
                    }
                    else
                    {
                        if (Guest.Reservation.ReservationPayment.VoucherUsed != null)
                        {
                            double percent = (double)(100 - Guest.Reservation.ReservationPayment.VoucherUsed.VoucherDiscount) / (double)100;
                            return (Guest.Reservation.Room.Cost * (Guest.Reservation.CheckOutDate - Guest.Reservation.CheckInDate).TotalDays) * percent;
                        }
                        else
                        {
                            return Guest.Reservation.Room.Cost * (Guest.Reservation.CheckOutDate - Guest.Reservation.CheckInDate).TotalDays;
                        }
                    }
                }
            }
        }

        public ReservationPayment(Reservation reservation, Guest guest, string transactionId, string paymentMethod, bool transactionSuccessStatus, Voucher voucherUsed)
        {
            Reservation = reservation;
            Guest = guest;
            TransactionId = transactionId;
            PaymentMethod = paymentMethod;
            TransactionSuccessStatus = transactionSuccessStatus;
            VoucherUsed = voucherUsed;
        }

        public ReservationPayment() { }
    }
}

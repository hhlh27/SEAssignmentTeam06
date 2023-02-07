using SEAssignment;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SEAssignment
{
    public class Program
    {
        
        // Wait for user
        public static void Main(string[] args)
        {
            Hotel h = new Hotel(3, "Budget Hotel", "123 Geylang Road", "Budget", true, 2);

            while (true)
            {
                displayMenu();
                Console.Write("Enter an option: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    // Add different cases and print statements depending on the user's input
                    case "1":
                        manageGuestAccount();

                        break;
                    case "2":
                        viewAllHotels();

                        break;
                    case "3":
                        viewHotelDetails();

                        break;
                    case "4":
                        makeReservation();
                        break;

                    case "5":
                        cancelReservation();

                        break;
                    case "6":
                        manageVouchers();

                        break;
                    case "7":
                        rateHotel(h);

                        break;
                    case "8":
                        updateRating();

                        break;
                   
                }

            }


        }

        private static void manageRatings()
        {
            throw new NotImplementedException();
        }

        private static void updateRating()
        {
            throw new NotImplementedException();
        }

        private static void makeReservation()
        {
            throw new NotImplementedException();
        }

        private static void viewAllHotels()

        {
            //implement view hotels using iterator design patter(Hannnah)
           

        }

        private static void manageGuestAccount()
        {
            //implement Guest Account use case(Juliana)
            Console.WriteLine("Guest Account");
        }

        private static void rateHotel(Hotel h)
        {
            //implement Ratings use case (Hannah)

            Console.WriteLine("----Rate Hotel---- ");
            Console.WriteLine("Reseravations Details: ");
            Console.WriteLine("Hotel Details: ");
            Console.WriteLine("Hotel Name: " + h.HotelName);
            Console.WriteLine("Hotel Type: " + h.HotelType);
            Console.Write("Enter a Star Rating (1-5): ");
            int starRating = Int32.Parse(Console.ReadLine());
            Console.Write("Enter your feedback:  ");
            string feedback = Console.ReadLine();
            string ratingState = "submitted a review";
            // Admin that observes rating
            var sysAdmin = new SystemAdmin();
            sysAdmin.LoginEmail = "abc@gmail.com";
            sysAdmin.LoginPassword = "123";
            sysAdmin.Name = "John";
            // Regiser observer
            Rating r = new Rating(starRating, feedback);
            r.RegisterObserver(sysAdmin);
            r.RatingState = ratingState;
            h.addRating(r);

            Console.WriteLine("Rating submitted successfully.\n");
        }

        private static void notifySystemAdmin(Rating r)
        {
            var sysAdmin = new SystemAdmin();
            sysAdmin.LoginEmail = "abc@gmail.com";
            sysAdmin.LoginPassword = "123";
            sysAdmin.Name = "John";
            //r.RegisterObserver(sysAdmin);
        }

        private static void manageVouchers()
        {
            //implement vouchers use case (Lay How)
            throw new NotImplementedException();
        }

        private static void cancelReservation()
        {
            // Test objects
            Guest guest = new Guest();
            Hotel hotel = new Hotel(1, "Fullteron", "1 Fullerton Square, Singapore 049178", "Luxury hotel", true, 4);       
            Room room = new Room(1, hotel, "Deluxe", "Queen", true, 2, 150.00, "Reserved");
            guest.Reservation = new Reservation(1, 1, room, DateTime.Now.AddDays(3),DateTime.Now.AddDays(4),"Confirmed");
            ReservationPayment reservationPayment = new ReservationPayment();
            reservationPayment.Reservation = guest.Reservation;
            reservationPayment.Guest = guest;
            reservationPayment.VoucherUsed = new Voucher("v12345", "15%");
            reservationPayment.TransactionSuccessStatus = true;

            //implement cancellation use case (Caleb)
            if (guest.Reservation == null)
            {
                Console.WriteLine("You have not made a reservation.\n");
            }
            else
            {              
                viewReservation(guest, reservationPayment);
                Console.Write("Would you like to cancel this reservation? (y/n): ");
                var userInput = Console.ReadLine();
                if (userInput == "y")
                {
                    Console.WriteLine();
                    if ((guest.Reservation.CheckInDate - DateTime.Now).TotalDays >= 2)
                    {
                        if (reservationPayment.TransactionSuccessStatus)
                        {
                            guest.AccountBalance += reservationPayment.PaymentAmt;
                            Console.WriteLine("${0} has been credited back to your account!", Math.Round(reservationPayment.PaymentAmt, 2));
                            Console.WriteLine("Your new account balance: ${0}\n", Math.Round(guest.AccountBalance, 2));
                            
                        }
                        if (reservationPayment.VoucherUsed != null)
                        {
                            guest.AddVoucher(reservationPayment.VoucherUsed);
                            Console.WriteLine("Your voucher {0} with a discount of {1} has been stored back in your account.\n", reservationPayment.VoucherUsed.VoucherId, reservationPayment.VoucherUsed.VoucherDiscount);
                        }
                        guest.Reservation.Room.RoomStatus = "Available";
                        guest.Reservation.setReservationStatus("Cancelled");
                        Console.WriteLine("\nYour reservation has been cancelled!\n");
                        viewReservation(guest, reservationPayment);
                    }
                    else
                    {
                        Console.WriteLine("Sorry, your reservation cannot be cancelled as the check-in date is less than 2 days away.\n");
                    }
                }
            }
        }

        private static void viewHotelDetails()
        {
            //implement hotel details use case (Xuan Qing)
            throw new NotImplementedException();
        }

        private static void displayMenu()
        {

            Console.WriteLine("-----BookHoliStay Menu-------");
            Console.WriteLine("1. Manage Guest Account ");
            Console.WriteLine("2. View All Hotels");
            Console.WriteLine("3. View Hotel Details");
            Console.WriteLine("4. Make a reservation ");
            Console.WriteLine("5. Cancel a Reservation");
            Console.WriteLine("6. Manage Vouchers");
            Console.WriteLine("7. Rate Hotel");
            Console.WriteLine("8. Update Rating");
            //check in state
            Console.WriteLine("");
        }

        private static void viewReservation(Guest guest, ReservationPayment reservationPayment)
        {
            Console.WriteLine("----- Your reservation -----");
            Console.WriteLine("Hotel name: " + guest.Reservation.Room.Hotel.HotelName);
            Console.WriteLine("Hotel location: " + guest.Reservation.Room.Hotel.Location);
            Console.WriteLine("Hotel type: " + guest.Reservation.Room.Hotel.HotelType);
            Console.WriteLine("Room type: " + guest.Reservation.Room.RoomType);
            Console.WriteLine("Bed type: " + guest.Reservation.Room.BedType);
            Console.WriteLine("Check-in date: " + guest.Reservation.CheckInDate);
            Console.WriteLine("Check-out date: " + guest.Reservation.CheckOutDate);
            if (reservationPayment.TransactionSuccessStatus == true)
            {
                if (guest.Reservation.ReservationStatus == "Cancelled")
                {
                    Console.WriteLine("Amount due: ${0} (Refunded ${1} on {2})", Math.Round(reservationPayment.PaymentDue, 2), Math.Round(reservationPayment.PaymentAmt, 2), guest.Reservation.DateCancelled);
                }
                else
                {
                    Console.WriteLine("Amount due: ${0} (Fully paid ${1} on {2})", Math.Round(reservationPayment.PaymentDue, 2), Math.Round(reservationPayment.PaymentAmt, 2), reservationPayment.DatePaid);
                }
            }              
            else
            {

                Console.WriteLine("Amount due: ${0} (Not paid)", Math.Round(reservationPayment.PaymentDue, 2));
            }
            Console.WriteLine("Reservation status: {0}\n", guest.Reservation.ReservationStatus);
        }
    }
}

using SEAssignment;
using System;
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
                        rateHotel();

                        break;
                }

            }


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

        private static void rateHotel()
        {
            //implement Ratings use case (Hannah)
            Console.WriteLine("Ratings");

            var rating = new Rating();
            var sysAdmin = new SystemAdmin();
            sysAdmin.Name = "John";
            sysAdmin.LoginEmail = "abc@gmail.com";
            sysAdmin.LoginPassword = "123";
            rating.RegisterObserver(sysAdmin);

            // Testing observer pattern (Caleb)
            Console.WriteLine("Rate your stay out of 5 stars: ");
            var userRating = Convert.ToInt32(Console.ReadLine());
            rating.StarRating = userRating;
            rating.setRatingState("left a rating");

            Console.WriteLine("Leave a short review: ");
            var userReview = Console.ReadLine();
            rating.Review = userReview;
            rating.setRatingState("left a review");
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
            guest.AccountBalance = 0;
            Hotel hotel = new Hotel(1, "Fullteron", "1 Fullerton Square, Singapore 049178", "Luxury hotel", true, 4);
            Room room = new Room(1, hotel, "Deluxe", "Queen", true, 2, 150.00);
            guest.Reservation = new Reservation(1,1, room, DateTime.Now.AddDays(3),DateTime.Now.AddDays(4),"Confirmed",false,DateTime.Now);
            //implement cancellation use case (Caleb)
            if (guest.Reservation == null)
            {
                Console.WriteLine("You have not made a reservation.\n");
            }
            else
            {              
                viewReservation(guest);
                Console.Write("Would you like to cancel this reservation? (y/n): ");
                var userInput = Console.ReadLine();
                if (userInput == "y")
                {
                    if ((guest.Reservation.CheckInDate - DateTime.Now).TotalDays >= 2)
                    {
                        guest.Reservation.setReservationStatus("Cancelled");
                        Console.WriteLine("Your reservation has been cancelled!");
                        viewReservation(guest);
                    }
                    else
                    {
                        Console.WriteLine("Sorry, your reservation cannot be cancelled as the check-in date is less than 2 days away.");
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
            Console.WriteLine("1. Manage Guest Account");
            Console.WriteLine("2. View All Hotels");
            Console.WriteLine("3. View Hotel Details");
            Console.WriteLine("4. Make a reservation");
            Console.WriteLine("5. Cancel a Reservation");
            Console.WriteLine("6. Manage Vouchers");
            Console.WriteLine("7. Rate Hotel");
            //check in state
            Console.WriteLine("");
        }

        private static void viewReservation(Guest guest)
        {
            Console.WriteLine("----- Your reservation -----");
            Console.WriteLine("Hotel name: " + guest.Reservation.Room.Hotel.HotelName);
            Console.WriteLine("Hotel location: " + guest.Reservation.Room.Hotel.Location);
            Console.WriteLine("Hotel type: " + guest.Reservation.Room.Hotel.HotelType);
            Console.WriteLine("Room type: " + guest.Reservation.Room.RoomType);
            Console.WriteLine("Bed type: " + guest.Reservation.Room.BedType);
            Console.WriteLine("Check-in date: " + guest.Reservation.CheckInDate);
            Console.WriteLine("Check-out date: " + guest.Reservation.CheckOutDate);
            if (guest.Reservation.IsFullyPaid == true)
            {
                Console.WriteLine("Amount due: {0} (Fully paid on {1})", guest.Reservation.AmountDue, guest.Reservation.DatePaid);
            }
            else
            {

                Console.WriteLine("Amount due: {0} (Not paid)", Math.Round(guest.Reservation.AmountDue, 2).ToString("0.00"));
            }
            Console.WriteLine("Reservation status: {0}\n", guest.Reservation.ReservationStatus);
        }
    }
}

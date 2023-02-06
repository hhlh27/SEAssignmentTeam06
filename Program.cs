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
            //This is our Observable also known as publisher that notifies about change
            var ratingObservable = new Observable<Rating>();
            // Admin that observes rating
            var sysAdmin = new SystemAdmin();
            sysAdmin.LoginEmail = "abc@gmail.com";
            sysAdmin.LoginPassword = "123";
            sysAdmin.Name = "John";
            // Regiser observer
            ratingObservable.Register(sysAdmin);
            Rating r = new Rating(starRating, feedback, ratingState);
            // Setting subject as newly created rating object
            ratingObservable.Subject = r;
            h.addRating(r);

            Console.WriteLine("Rating submitted successfully ");
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
                        Console.WriteLine("\nYour reservation has been cancelled!");
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

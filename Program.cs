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
            Guest guest = new Guest();
            Hotel h = new Hotel(3, "Budget Hotel", "123 Geylang Road", "Budget", true, 2);
            Room room = new Room(1, h, "Deluxe", "Queen", true, 2, 150.00, "Reserved");
            ReservationPayment reservationPayment = new ReservationPayment
            {
                Guest = guest,
                VoucherUsed = new Voucher("v12345", "15%"),
                TransactionSuccessStatus = true
            };
            guest.Reservation = new Reservation(1, 1, room, DateTime.Now.AddDays(3), DateTime.Now.AddDays(4), "Confirmed", reservationPayment, new Cancellation());
            reservationPayment.Reservation = guest.Reservation;

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

                        Console.Write("Enter a date (e.g. 03/22/2023 07:22:00): ");
                        DateTime inputtedDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine(inputtedDate);

                        // The client code.                 
                        Hotel hotel = new Hotel(1, "name", "l", "ht", true, 9);
                        Room rr = new Room(1, hotel, "abc", "abc", true, 6, 9300.03, "stat");
                        var date1 = new DateTime(2023, 3, 1, 8, 30, 52);
                        var date2 = new DateTime(2023, 3, 4, 8, 30, 52);
                        Reservation r = new Reservation(1, 1, rr, date1, date2, "empty", null, null);

                        var context = new Context(new Submitted());
                        string status = context.Request1(r);

                        r.setReservationStatus(status);
                        Console.WriteLine(r.ReservationStatus);
                        //makeReservation();
                        break;

                    case "5":
                        if (guest.Reservation == null)
                        {
                            Console.WriteLine("You have not made a reservation.\n");
                        }
                        else
                        {
                            cancelReservation(guest);

                        }
                        break;
                    case "6":
                        manageVouchers();

                        break;
                    case "7":
                        rateHotel(h,guest);

                        break;
                    case "8":
                        updateRating(guest);

                        break;
                   
                }

            }


        }
        private static void makeReservation()
        {
            Guest guest = new Guest();
            //Hotel h1 = new Hotel(4, "Budget Hotel", "123 Geylang Road", "Budget", true, 4);
            //Hotel h2 = new Hotel(5, "Luxury Hotel", "311 Clementi Road", "Luxury", true, 5);
            //Hotel h3 = new Hotel(6, "City Hotel", "12 Woodlands Road", "City", true, 2);
            //Room r1 = new Room(1, h1, "Deluxe", "Queen", true, 2, 150.00, "Reserved");
            //Room r2 = new Room(2, h1, "Regular", "King", true, 2, 100.00, "Available");

            List<Hotel> hotelList = new List<Hotel>
            {
               new Hotel(1, "Budget Hotel", "123 Geylang Road", "Budget", true, 4),
               new Hotel(2, "Luxury Hotel", "311 Clementi Road", "Luxury", true, 5),
               new Hotel(3, "City Hotel", "12 Woodlands Road", "City", true, 2)
            };

            List<Room> roomList = new List<Room>
            {
                new Room(1, h1, "Deluxe", "Queen", true, 2, 150.00, "Reserved"),
               new Room(2, h1, "Regular", "King", true, 2, 100.00, "Available")
            };

            Console.WriteLine("----Make Reservation---- ");
            foreach (Hotel item in hotelList)
            {
                Console.WriteLine("[" + item.HotelId + "]" + item.HotelName + item.HotelType + item.Location + "Is Voucher Allowed: " + item.IsVouchersAllowed + item.ReviewScore);
            }
            Console.WriteLine("Select Hotel: ");
            int selectedHotel = Int32.Parse(Console.ReadLine());

            foreach (Room item in roomList)
            {
                Console.WriteLine("[" + item.RoomId + "]" + item.RoomType + item.Hotel + item.RoomStatus + item.BedType + item.MaxNumGuests + item.Cost + "Is Breakfast Served: " +item.IsBreakfastServed);
            }
            Console.WriteLine("Select Room: ");
            int selectedRoom = Int32.Parse(Console.ReadLine());
            Room reservedRoom = searchRoom(roomList, selectedRoom);

            Console.Write("Enter a date (e.g. 03/22/2023 07:22:00): ");
            DateTime inputtedDate = DateTime.Parse(Console.ReadLine());
            
            Reservation reservation = new Reservation(5, guest.GuestId, reservedRoom );

            

        }

        private static Room searchRoom(List<Room> roomList, int id)
        {
            foreach (Room item in roomList)
            {
                if(item.RoomId == id)
                {
                    return item;
                }
            }
           
            return null;

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

        private static Rating rateHotel(Hotel h, Guest guest)
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
            Rating r = new Rating(1, starRating, feedback, h);
            // (Caleb) I added rating to the guest's rating list
            guest.addRating(r);
            // Regiser observer
            r.RegisterObserver(sysAdmin);
            r.RatingState = ratingState;
            h.addRating(r);

            Console.WriteLine("Rating submitted successfully.\n");

            return r;
        }

        private static void manageVouchers()
        {
            //implement vouchers use case (Lay How)
            throw new NotImplementedException();
        }

        private static void cancelReservation(Guest guest)
        {
            viewReservation(guest);
            //implement cancellation use case (Caleb)
            Console.Write("Would you like to cancel this reservation? (y/n): ");
            var userInput = Console.ReadLine();
            if (userInput == "y")
            {
                Console.WriteLine();
                if ((guest.Reservation.CheckInDate - DateTime.Now).TotalDays >= 2)
                {
                    if (guest.Reservation.ReservationPayment.TransactionSuccessStatus)
                    {
                        guest.AccountBalance += guest.Reservation.ReservationPayment.PaymentAmt;
                        Console.WriteLine("${0} has been credited back to your account!", Math.Round(guest.Reservation.ReservationPayment.PaymentAmt, 2));
                        Console.WriteLine("Your new account balance: ${0}\n", Math.Round(guest.AccountBalance, 2));
                            
                    }
                    if (guest.Reservation.ReservationPayment.VoucherUsed != null)
                    {
                        guest.addVoucher(guest.Reservation.ReservationPayment.VoucherUsed);
                        Console.WriteLine("Your voucher {0} with a discount of {1} has been stored back in your account.\n", 
                            guest.Reservation.ReservationPayment.VoucherUsed.VoucherId, 
                            guest.Reservation.ReservationPayment.VoucherUsed.VoucherDiscount);
                    }
                    guest.Reservation.Room.RoomStatus = "Available";
                    guest.Reservation.setReservationStatus("Cancelled");
                    guest.Reservation.Cancellation.CancellationId = "Cancelled_" + guest.Reservation.ReservationId.ToString();
                    guest.Reservation.Cancellation.CancellationDate = DateTime.Now;
                    guest.Reservation.Cancellation.AmtRefunded = guest.Reservation.ReservationPayment.PaymentAmt;
                    Console.WriteLine("Your reservation has been cancelled!\n");
                    viewReservation(guest);
                }
                else
                {
                    Console.WriteLine("Sorry, your reservation cannot be cancelled as the check-in date is less than 2 days away.\n");
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
            if (guest.Reservation.ReservationPayment.TransactionSuccessStatus == true)
            {
                if (guest.Reservation.ReservationStatus == "Cancelled")
                {
                    Console.WriteLine("Amount due: ${0} (Refunded ${1} on {2})", 
                        Math.Round(guest.Reservation.ReservationPayment.PaymentDue, 2), 
                        Math.Round(guest.Reservation.Cancellation.AmtRefunded, 2), 
                        guest.Reservation.Cancellation.CancellationDate);
                }
                else
                {
                    Console.WriteLine("Amount due: ${0} (Fully paid ${1} on {2})", 
                        Math.Round(guest.Reservation.ReservationPayment.PaymentDue, 2), 
                        Math.Round(guest.Reservation.ReservationPayment.PaymentAmt, 2), 
                        guest.Reservation.ReservationPayment.DatePaid);
                }
            }              
            else
            {
                Console.WriteLine("Amount due: ${0} (Not paid)", Math.Round(guest.Reservation.ReservationPayment.PaymentDue, 2));
            }
            Console.WriteLine("Reservation status: {0}\n", guest.Reservation.ReservationStatus);
        }
        private static void updateRating(Guest guest)
        {
            int newStarRating;
            viewRatings(guest);
            List<Rating> ratings = guest.getRatings();
            Console.Write("Please select a number in the square brackets to update the rating: ");
            int choice = Int32.Parse(Console.ReadLine());
            Rating selectedRating = ratings[choice-1];
            Console.Write("\nEnter your new rating out of 5 stars (Press enter to skip): ");       
            // Handle empty input
            if (Int32.TryParse(Console.ReadLine(), out newStarRating))
            {
                selectedRating.StarRating = newStarRating;
                selectedRating.RatingState = "updated a star rating";
            }
            Console.Write("\nEnter your new review (Press enter to skip): ");
            string newReview = Console.ReadLine();
            if (newReview != String.Empty) 
            {
                selectedRating.Review = newReview;
                selectedRating.RatingState = "updated a review";
            }
            Console.WriteLine("\nYour rating has been updated!\n");
            viewRatings(guest);
        }
        private static void viewRatings(Guest guest)
        {
            Console.WriteLine("----- Your Ratings -----");
            List<Rating> ratings = guest.getRatings();
            int count = 0;
            foreach (Rating r in ratings)
            {
                count += 1;
                Console.WriteLine("[{0}]: Rating for {1}", count, r.Hotel.HotelName);
                Console.WriteLine("Rating out of 5 stars: " + r.StarRating);
                Console.WriteLine("Review: " + r.Review + "\n");
            }
        }
    }
}

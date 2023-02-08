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
                        makeReservation(guest, h);
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
        private static void makeReservation(Guest guest, Hotel h1)
        {
            //available hotel
            List<Hotel> hotelList = new List<Hotel>
            {
               new Hotel(1, "Budget Hotel", "123 Geylang Road", "Budget", true, 4),
               new Hotel(2, "Luxury Hotel", "311 Clementi Road", "Luxury", true, 5),
               new Hotel(3, "City Hotel", "12 Woodlands Road", "City", true, 2),
               new Hotel(4, "Budget Hotel", "321 Geylang Road", "Budget", true, 4)
            };

            //available room type
            List<Room> roomList = new List<Room>
            {
                new Room(1, h1, "Deluxe", "Queen", true, 2, 150.00, "Reserved"),
               new Room(2, h1, "Regular", "King", true, 2, 100.00, "Available")
            };

            //prompt user to select hotel and room
            Console.WriteLine("\n----Make Reservation---- ");
            foreach (Hotel item in hotelList)
            {
                Console.WriteLine("[" + item.HotelId + "]" + " " + item.HotelName + " " + item.HotelType + " " + item.Location + " Is Voucher Allowed: " + item.IsVouchersAllowed + " Rating: " + item.ReviewScore);
            }
            Console.WriteLine("Select Hotel: ");
            int selectedHotel = Int32.Parse(Console.ReadLine());

            Console.WriteLine();
            foreach (Room item in roomList)
            {
                Console.WriteLine("[" + item.RoomId + "]" + " " + item.RoomType + " " + item.RoomStatus + " " + item.BedType + " " + item.MaxNumGuests + " $" + item.Cost + " Is Breakfast Served: " + item.IsBreakfastServed);
            }

            Console.WriteLine("Select Room: ");
            int selectedRoom = Int32.Parse(Console.ReadLine());
            Room reservedRoom = searchRoom(roomList, selectedRoom);

            //prompt user to enter date
            Console.Write("\nEnter check-in date (e.g. 2023-03-30 22:12 PM): ");
            var checkInDate = Console.ReadLine();
            DateTime oCheckInDate = DateTime.ParseExact(checkInDate, "yyyy-MM-dd HH:mm tt", null);

            Console.Write("\nEnter check-out date (e.g. 2023-03-30 22:12 PM): ");
            var checkOutDate = Console.ReadLine();
            DateTime oCheckOutDate = DateTime.ParseExact(checkOutDate, "yyyy-MM-dd HH:mm tt", null);

            //prompt user to enter promo code (if applicable)
            Console.Write("\nDo you wish to use credit card? (y/n): ");
            var answer = Console.ReadLine();
            double price = 0.00;
            if (answer == "y")
            {
                price = reservedRoom.Cost * 0.8;
            }
            else
            {
                price = reservedRoom.Cost;
            }

            //update reservation status using state design pattern
            Reservation reservation = new Reservation();
            var context = new Context(new Submitted());
            string status = context.Request1(reservation);
            reservation.setReservationStatus(status);

            //print out reservation details
            Console.WriteLine("\n----Confirm Details---- ");
            Console.WriteLine("Guest ID: " + guest.GuestId);
            Console.WriteLine("Selected Room: " + reservedRoom.RoomType);
            Console.WriteLine("Check In Date: " + oCheckInDate.ToString("MM/dd/yyyy HH:mm"));
            Console.WriteLine("Check Out Date: " + oCheckOutDate.ToString("MM/dd/yyyy HH:mm"));
            Console.WriteLine("Reservation Status: " + reservation.ReservationStatus);
            Console.WriteLine("Total Cost: " + price);

            //prompt user to confirm and create reservation
            Console.Write("Confrim Submit (y/n): ");
            var respond = Console.ReadLine();
            if(respond == "y")
            {
                ReservationPayment reservationPayment = new ReservationPayment();
                Reservation r = new Reservation(5, guest.GuestId, reservedRoom, oCheckInDate, oCheckOutDate, "Submitted", reservationPayment, null);
                // When making reservation, new reservationpayment object is created
                // Since payment has not been made, payment properties such as TransactionId, TransactionSuccessStatus are not set
                reservationPayment.Reservation = r;
                reservationPayment.Guest = guest;

                // Setting reservation to guest's reservation object
                guest.Reservation = r;
                Console.WriteLine("\nYou have successfully made a reservation!");
                viewReservation(guest);
                Console.WriteLine("Amount due: ${0} (Not paid after discount)\n", price);
            }
            else
            {
                Console.WriteLine("Reservation not submitted, please try again.");
            }
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
                // Initilize Cancellation object in guest's reservation
                Cancellation cancellation = new Cancellation();
                guest.Reservation.Cancellation = cancellation;

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

                    //update reservation status
                    var context = new Context(new Submitted());
                    string status = context.Request3(guest.Reservation);
                    guest.Reservation.setReservationStatus(status);

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

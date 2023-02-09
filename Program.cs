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
            HotelCollection hotelCollection = new HotelCollection();
            hotelCollection[0] = new Hotel(1, "Grand Hyatt Singapore", "10 Scotts Rd", "City", true, 4);
            hotelCollection[1] = new Hotel(2, "Budget A Hotel", "123 Geylang Road", "Budget", false, 2);
            hotelCollection[2] = new Hotel(3, "Family B Hotel", "223 Avenue Road", "Family-friendly", true, 3);
            hotelCollection[3] = new Hotel(4, "Luxury C Hotel", "113 Orchard Road", "Luxury", true, 5);
            Hotel h = new Hotel(3, "Grand Hyatt Singapore", "10 Scotts Rd", "Citf5btny Hotel", true, 4);
            Room room = new Room(1, h, "Deluxe", "Queen", true, 2, 150.00, "Reserved");
            List<Voucher> voucherList = new List<Voucher>();
            Voucher voucher1 = new Voucher("v99887", 30);
            Voucher voucher2 = new Voucher("v11294", 12);
            Voucher voucher3 = new Voucher("v12345", 15);
            Voucher voucher4 = new Voucher("v55141", 20);
            Voucher voucher5 = new Voucher("v34567", 25);
            voucherList.Add(voucher1);
            voucherList.Add(voucher2);
            voucherList.Add(voucher3);
            voucherList.Add(voucher4);
            voucherList.Add(voucher5);

            ReservationPayment reservationPayment = new ReservationPayment
            {
                Guest = guest,
                VoucherUsed = voucher3,
                TransactionSuccessStatus = true
            };


            guest.Reservation = new Reservation(1, 1, room, DateTime.Now.AddDays(3), DateTime.Now.AddDays(4), "Confirmed", reservationPayment, new Cancellation());
            reservationPayment.Reservation = guest.Reservation;
            Reservation r1 = new Reservation(1, 1, room, new DateTime(2022, 10, 1, 7, 0, 0), new DateTime(2022, 10, 10, 7, 0, 0), "Fulfilled", reservationPayment, null);
            Reservation r2 = new Reservation(2, 1, room, new DateTime(2022, 11, 5, 7, 0, 0), new DateTime(2022, 11, 22, 5, 0, 0), "Fulfilled", reservationPayment, null);
            Reservation r3 = new Reservation(3, 1, room, new DateTime(2022, 12, 10, 7, 0, 0), new DateTime(2022, 12, 17, 7, 0, 0), "Fulfilled", reservationPayment, null);
            List <Reservation> fulfilledReservationList = new List<Reservation>();
            fulfilledReservationList.Add(r1);
            fulfilledReservationList.Add(r2);
            fulfilledReservationList.Add(r3);
            while (true)
            {
                displayMenu();
                Console.Write("Enter an option: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    // Add different cases and print statements depending on the user's input
                    case "1":
                        Console.WriteLine("---- Sign in/Register ---- " +
                            "\n1. Sign in (Have existing account)\n" +
                            "2. Sign up (No existing account)\n" +
                            "3. Register guesst (For ICA Personnel");
                        Console.Write("Enter an option: ");
                        string accInput = Console.ReadLine();
                        if (accInput == "1")
                        {
                            Console.WriteLine("Signed in successfully. Welcome back to BookHoliStay!\n");
                        }
                        else if (accInput == "2")
                        {
                            Console.WriteLine("Signed up successfully. Welcome to BookHoliStay!\n");
                        }
                        else if (accInput == "3")
                        {
                            Console.WriteLine();
                            registerGuest();
                        }
                        else
                        {
                            displayMenu();
                        }
                        break;

                    case "2":
                        viewAllHotelsAcceptVouchers(hotelCollection);

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
                        makePayment(voucherList,guest);

                        break;
                    case "7":
                        rateHotel(fulfilledReservationList,h,guest);

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

        private static void viewAllHotelsAcceptVouchers(HotelCollection hc)

        {
            //implement view hotels using iterator design patter(Hannah)
            IIterator i = hc.CreateIterator();
            Console.WriteLine("Displaying All Hotels that accept Vouchers:");


            for (Hotel item = (Hotel)i.First();
                   !i.IsDone; item = (Hotel)i.Next())
            {
                if (item.IsVouchersAllowed==true)
                    Console.WriteLine("Hotel Name: "+item.HotelName+", Address: "+item.Location+ ", Type:"+item.HotelType);
                //Console.WriteLine(item.Location);
            }


        }
      

        private static void registerGuest()
        {
            //implement Guest Account use case(Juliana)
            Console.WriteLine("----Register Guest----");

        }

        private static Rating rateHotel(List<Reservation> frList,Hotel h, Guest guest)
        {
            //implement Ratings use case (Hannah)
            int starRating = 0;
            bool ratingIsValid = false;
            string sRating = "";
            Console.WriteLine("----Rate Hotel---- ");
            foreach (Reservation reservation in frList)
            {
                Console.WriteLine("Reservation ID: " + reservation.ReservationId);
                Console.WriteLine("Check In Date: " + reservation.CheckInDate);
                Console.WriteLine("Check Out Date: " + reservation.CheckOutDate);
                Console.WriteLine("Reservation Status: " + reservation.ReservationStatus);
                Console.WriteLine();
            }
            Console.Write("Enter reservation ID to rate hotel: ");
            string idInput = Console.ReadLine();
            bool idIsValid = validateIdInput(frList, idInput);
            while (!idIsValid)
            {
                Console.WriteLine("Invalid input.");
                Console.Write("Enter a valid reservation ID : ");
                idInput = Console.ReadLine();
                idIsValid = validateIdInput(frList, idInput);
            }
            Console.WriteLine("Hotel Details: ");
            Console.WriteLine("Hotel Name: " + h.HotelName);
            Console.WriteLine("Hotel Address: " + h.Location);
            Console.WriteLine("Hotel Type: " + h.HotelType);
            Console.Write("Enter a Star Rating (1-5): ");
            string rating = Console.ReadLine();
            ratingIsValid = validateStarRating(rating);
            while (!ratingIsValid)
            {
                Console.WriteLine("Invalid input.");
                Console.Write("Enter a Star Rating (1-5): ");
                rating = Console.ReadLine();
                ratingIsValid = validateStarRating(rating);
            }
            
            starRating = Int32.Parse(rating);
            Console.Write("Would you like to input a feedback of the hotel? (y/n): ");
            string input = Console.ReadLine();
            input.ToLower();
            bool isValid = validateYNInput(input);
            while (!isValid)
            {
                Console.WriteLine("Invalid input.");
                Console.Write("Enter a valid option (Y/N): ");
                input = Console.ReadLine();
                input.ToLower();
                isValid = validateYNInput(input);
            }
            if (input == "y")
            {
                Console.Write("Enter your feedback:  ");
                string feedback = Console.ReadLine();
                string ratingState = "submitted a review";
                Rating r = new Rating(1, starRating, feedback, h);
                Console.WriteLine("Rating submitted successfully.\n");
                h.addRating(r);
                // (Caleb) I added rating to the guest's rating list
                guest.addRating(r);
                // Regiser observer
                // Admin that observes rating
                var sysAdmin = new SystemAdmin();
                sysAdmin.LoginEmail = "abc@gmail.com";
                sysAdmin.LoginPassword = "123";
                sysAdmin.Name = "John";
                r.RegisterObserver(sysAdmin);
                r.RatingState = ratingState;
                return r;
            }
            else
            {
                string feedback = "";
                string ratingState = "submitted a review";
                Rating r = new Rating(1, starRating, feedback, h);
                Console.WriteLine("Rating submitted successfully.\n");
                h.addRating(r);
                // (Caleb) I added rating to the guest's rating list
                guest.addRating(r);
                // Regiser observer
                // Admin that observes rating
                var sysAdmin = new SystemAdmin();
                sysAdmin.LoginEmail = "abc@gmail.com";
                sysAdmin.LoginPassword = "123";
                sysAdmin.Name = "John";
                r.RegisterObserver(sysAdmin);
                r.RatingState = ratingState;
                return r;
            }
            
            
        }

        private static bool validateYNInput(string input)
        {
            if (input == "y" || input == "n")
                return true;
            else
                return false;
        }

        private static bool validateIdInput(List<Reservation> frList, string? idInput)
        {
            int numericValue;
            bool isNumber = int.TryParse(idInput, out numericValue);
            if (isNumber)
            {
                int userInput = Int32.Parse(idInput);
                if (userInput > 0 && userInput <= frList.Count() && isNumber)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private static bool validateStarRating(string? starRating)
        {
            int numericValue;
            bool isNumber = int.TryParse(starRating, out numericValue);
            if (isNumber)
            {
                int sRating = Int32.Parse(starRating);
                if (sRating >= 0 && sRating <= 5 && isNumber)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
    

        private static void makePayment(List<Voucher> voucherList, Guest id)
        {
            //implement vouchers use case (Lay How)
            
            if (id.Reservation.ReservationPayment.TransactionSuccessStatus == false)
            {
                Console.WriteLine("");
                Console.WriteLine("Payment $" + id.Reservation.ReservationPayment.PaymentAmt.ToString("0.00") + " for " + "Guest " + id.Reservation.GuestId + ", " + id.Reservation.Room + ", " + id.Reservation.CheckInDate + ", " + id.Reservation.CheckOutDate);

                Console.WriteLine("Do you have a voucher [Yes/No]");
                Console.WriteLine("[Yes] - \"Yes\"");
                Console.WriteLine("[No] - anything else");

                string reply = Console.ReadLine();

                bool found = false;
                bool run1 = false;

                while (run1 == false)
                {
                    if (reply == "Yes")
                    {
                        Console.WriteLine("Enter voucher code:");
                        string voucherId = Console.ReadLine();
                        for (int i = 0; i < voucherList.Count(); i++)
                        {
                            if (voucherId == "v" + voucherList[i].VoucherId)
                            {
                                var voucherApplied = new Voucher();
                                voucherApplied = voucherList[i];
                                found = true;
                            }
                        }

                        if (found == true)
                        {
                            Console.WriteLine("Voucher applied.");
                            run1 = true;
                        }
                        else
                        {
                            Console.WriteLine("Voucher not found.");
                            Console.WriteLine("Re-enter voucher code? [Yes/No]");

                            Console.WriteLine("[Yes] - \"Yes\"");
                            Console.WriteLine("[No] - anything else");

                            string reply1 = Console.ReadLine();

                            if (reply1 == "Yes")
                            {
                                run1 = false;
                            }
                            else
                            {
                                run1 = true;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                }

                Console.WriteLine("Next...");
            }
            else
            {
                Console.WriteLine("No payment needs to be made.");
            }
            
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
            Console.WriteLine("");
            Console.WriteLine("-----BookHoliStay Menu-------");
            Console.WriteLine("1. Sign/Register");
            Console.WriteLine("2. View All Hotels (Vouchers Accepted)");
            Console.WriteLine("3. View Hotel Details");
            Console.WriteLine("4. Make a reservation ");
            Console.WriteLine("5. Cancel a Reservation");
            Console.WriteLine("6. Make Payment");
            Console.WriteLine("7. Rate Hotel");
            Console.WriteLine("8. Update Rating");
            //check in state
           
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

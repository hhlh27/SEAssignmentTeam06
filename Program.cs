/**
------------------------------------
BookHoliStay Hotel Booking System
Done by Team 6:
Loh En Ting Hannah S10186258K
Lim Xuan Qing S10207455A
Ramos Juliana Charisse S10204975E 
Choo Jun Le Caleb S10205375H
Tan Lay How S10206171J
------------------------------------

**/

using SEAssignment;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;


namespace SEAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Register observer
            // Admin that observes rating
            var sysAdmin = new SystemAdmin();
            sysAdmin.LoginEmail = "abc@gmail.com";
            sysAdmin.LoginPassword = "123";
            sysAdmin.Name = "John";
            Guest guest = new Guest();
            Guest guest2 = new Guest();
            List<Guest> guestList = new List<Guest>();
            guestList.Add(guest);
            guestList.Add(guest2);
            HotelCollection hotelCollection = new HotelCollection();
            hotelCollection[0] = new Hotel(1, "Grand Hyatt Singapore", "10 Scotts Rd", "City", true, 4);
            hotelCollection[1] = new Hotel(2, "Budget A Hotel", "123 Geylang Road", "Budget", false, 2);
            hotelCollection[2] = new Hotel(3, "Family B Hotel", "223 Avenue Road", "Family-friendly", true, 3);
            hotelCollection[3] = new Hotel(4, "Luxury C Hotel", "113 Orchard Road", "Luxury", true, 5);
            Hotel hotel = new Hotel(3, "Grand Hyatt Singapore", "10 Scotts Rd", "City Hotel", true, 4);
            Room room = new Room(1, hotel, "Deluxe", "Queen", true, 2, 150.00, "Reserved");
            Room room2 = new Room(2, hotel, "Luxury", "Single", true, 2, 300.00, "Reserved");
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
            List<Hotel> hotelList = new List<Hotel>
            {
               new Hotel(1, "Grand Hyatt Singapore", "10 Scotts Rd", "City", true, 4),
               new Hotel(2, "Budget A Hotel", "123 Geylang Road", "Budget", false, 2),
               new Hotel(3, "Family B Hotel", "223 Avenue Road", "Family-friendly", true, 3),
               new Hotel(4, "Luxury C Hotel", "113 Orchard Road", "Luxury", true, 5)
            };
            ReservationPayment reservationPayment = new ReservationPayment
            {
                Guest = guest,
                VoucherUsed = voucher3,
                TransactionSuccessStatus = true
            };

            ReservationPayment reservationPayment2 = new ReservationPayment
            {
                Guest = guest2,
                TransactionSuccessStatus = false
            };

            guest2.AccountBalance = 150;
            guest.Reservation = new Reservation(1, 1, room, DateTime.Now.AddDays(3), DateTime.Now.AddDays(4), "Confirmed", reservationPayment, new Cancellation());
            guest2.Reservation = new Reservation(2, 2, room2, DateTime.Now.AddDays(4), DateTime.Now.AddDays(6), "Awaiting Payment", reservationPayment2, new Cancellation());
            reservationPayment.Reservation = guest.Reservation;
            reservationPayment2.Reservation = guest2.Reservation;
            Reservation r1 = new Reservation(1, 1, room, new DateTime(2022, 10, 1, 7, 0, 0), new DateTime(2022, 10, 10, 7, 0, 0), "Fulfilled", reservationPayment, null);
            Reservation r2 = new Reservation(2, 1, room, new DateTime(2022, 11, 5, 7, 0, 0), new DateTime(2022, 11, 22, 5, 0, 0), "Fulfilled", reservationPayment, null);
            Reservation r3 = new Reservation(3, 1, room, new DateTime(2022, 12, 10, 7, 0, 0), new DateTime(2022, 12, 17, 7, 0, 0), "Fulfilled", reservationPayment, null);
            List<Reservation> fulfilledReservationList = new List<Reservation>();
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
                        Console.WriteLine("---- Sign in/Sign up ---- " +
                            "\n1. Sign in (Have existing account)\n" +
                            "2. Sign up (No existing account)");
                        Console.Write("Enter an option: ");
                        string accInput = Console.ReadLine();
                        if (accInput == "1")
                        {
                            Console.WriteLine("Signed in successfully. Welcome back to BookHoliStay!\n");
                        }
                        else if (accInput == "2")
                        {
                            guestList.Add(signUp(guestList));
                            Console.WriteLine("\nGreat! Signed up successfully. Welcome to BookHoliStay!");
                        }
                        else
                        {
                            displayMenu();
                        }
                        break;

                    case "2":
                        viewAllHotels(hotelList);
                        

                        break;
                    case "3":
                        
                        viewAllHotelsAcceptVouchers(hotelCollection);
                        break;
                    case "4":
                        makeReservation(guest, hotel);
                        break;

                    case "5":
                        cancelReservation(guest);    
                        
                        break;
                    case "6":
                        makePayment(voucherList,guest2);

                        break;
                    case "7":
                        rateHotel(fulfilledReservationList,hotel,guest,sysAdmin);

                        break;
                    case "8":
                        updateRating(guest);

                        break;
                   
                }

            }


        }

        private static void viewAllHotels(List<Hotel> hotelList)
        {
            //Display all hotels
            Console.WriteLine("---Displayng all hotels---");
            foreach(Hotel hotel in hotelList)
            {
                Console.WriteLine("Hotel Name: "+ hotel.HotelName);
                Console.WriteLine("Hotel Type: "+hotel.HotelType);
                Console.WriteLine("Location: "+hotel.Location);
                Console.WriteLine("Vouchers allowed? "+hotel.IsVouchersAllowed);
                Console.WriteLine("");
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
                price = (reservedRoom.Cost * (oCheckOutDate - oCheckInDate).TotalDays) * 0.8;
            }
            else
            {
                price = reservedRoom.Cost * (oCheckOutDate - oCheckInDate).TotalDays;
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
            Console.Write("Confirm Submit (y/n): ");
            var respond = Console.ReadLine();
            if(respond == "y")
            {
                ReservationPayment reservationPayment = new ReservationPayment();
                Reservation r = new Reservation(5, guest.GuestId, reservedRoom, oCheckInDate, oCheckOutDate, "Submitted", reservationPayment, null);
                // When making reservation, new reservationpayment object is created
                // Since payment has not been made, payment properties such as TransactionId, TransactionSuccessStatus are not set
                reservationPayment.Reservation = r;
                reservationPayment.Guest = guest;
                reservationPayment.PaymentMethod = "Credit Card";

                // Setting reservation to guest's reservation object
                guest.Reservation = r;
                Console.WriteLine("\nYou have successfully made a reservation!");
                viewReservation(guest);
                //Console.WriteLine("Amount due: ${0} (Not paid after discount)\n", price);
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
            //implement view hotels that accept vouchers using iterator design pattern(Hannah)
            //Display a list of hotels that accept vouchers
            IIterator i = hc.CreateIterator();
            Console.WriteLine("Displaying All Hotels that accept Vouchers:");

            for (Hotel item = (Hotel)i.First();//go to first hotel object in collection
                   !i.IsDone; item = (Hotel)i.Next())//while last obj has not been reached, go to next obj
            {
                if (item.IsVouchersAllowed==true)//check if attribute IsVouchersAllowed is true
                    Console.WriteLine("Hotel Name: "+item.HotelName+", Address: "+item.Location+ ", Type:"+item.HotelType +", Vouchers allowed? "+ item.IsVouchersAllowed);
                    //display hotel details
            }


        }
      

        private static Guest signUp(List<Guest> guestList)
        {
            //implement Sign Up use case(Juliana)
            Console.WriteLine("----Sign Up----");
            Guest guest = new Guest();

            //prompt user to enter name
            Console.Write("Enter Name: ");
            var name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.Write("Name can't be empty! Enter name once more: ");
                name = Console.ReadLine();
            }
            guest.Name = name;

            //prompt user to enter personal id
            Console.Write("\nEnter Personal ID: ");
            var id = Console.ReadLine();
            while (string.IsNullOrEmpty(id))
            {
                Console.Write("Personal ID can't be empty! Enter Personal ID once more: ");
                id = Console.ReadLine();
            }
            for (int i = 0; i < guestList.Count(); i++)
            {
                while (id == guestList[i].PersonalId)
                {
                    Console.Write("Personal ID already exists! Enter Personal ID once more: ");
                    id = Console.ReadLine();
                }
            }
            guest.PersonalId = id;

            //prompt user to enter contact number
            Console.Write("\nEnter Contact Number: ");
            var num = Console.ReadLine();
            while (string.IsNullOrEmpty(num))
            {
                Console.Write("Contact Number can't be empty! Enter Contact Number once more: ");
                num = Console.ReadLine();
            }
            guest.ContactNum = Convert.ToInt32(num);

            //prompt user to enter email
            Console.Write("\nEnter Email: ");
            var email = Console.ReadLine();
            while (string.IsNullOrEmpty(email))
            {
                Console.Write("Email can't be empty! Enter Email once more: ");
                email = Console.ReadLine();
            }
            for (int i = 0; i < guestList.Count(); i++)
            {
                while (email == guestList[i].LoginEmail)
                {
                    Console.Write("Email already exists! Enter email once more: ");
                    email = Console.ReadLine();
                }
            }
            guest.LoginEmail = email;

            //prompt user to enter password
            Console.Write("\nEnter Password: ");
            var password = Console.ReadLine();
            while (string.IsNullOrEmpty(password))
            {
                Console.Write("Password can't be empty! Enter Password once more: ");
                password = Console.ReadLine();
            }
            guest.LoginPassword = password;

            return guest;
            
        }

        private static Rating rateHotel(List<Reservation> frList,Hotel h, Guest guest, SystemAdmin sysAdmin)
        {
            //implementation of rate hotel use case (Hannah)
            int starRating = 0;
            bool ratingIsValid = false;
            string sRating = "";
            Console.WriteLine("----Rate Hotel---- ");
            foreach (Reservation reservation in frList)//display a list of reservations
            {
                Console.WriteLine("Reservation ID: " + reservation.ReservationId);
                Console.WriteLine("Check In Date: " + reservation.CheckInDate);
                Console.WriteLine("Check Out Date: " + reservation.CheckOutDate);
                Console.WriteLine("Reservation Status: " + reservation.ReservationStatus);
                Console.WriteLine();
            }
            Console.Write("Enter reservation ID to rate hotel: ");//prompt user to input reservation id of hotel
            string idInput = Console.ReadLine();
            bool idIsValid = validateIdInput(frList, idInput);//validate user input of reservation id
            while (!idIsValid)//if input is not valid
            {
                Console.WriteLine("Invalid input.");//display error message
                Console.Write("Enter a valid reservation ID : ");//prompt user to input again
                idInput = Console.ReadLine();
                idIsValid = validateIdInput(frList, idInput);
            }
            Console.WriteLine("Hotel Details: ");//display hotel details
            Console.WriteLine("Hotel Name: " + h.HotelName);
            Console.WriteLine("Hotel Address: " + h.Location);
            Console.WriteLine("Hotel Type: " + h.HotelType);
            Console.Write("Enter a Star Rating (1-5): ");//prompt for input of star rating
            string rating = Console.ReadLine();
            ratingIsValid = validateStarRating(rating);//validate user input of star rating
            while (!ratingIsValid)//if input is not valid
            {
                Console.WriteLine("Invalid input.");//display error message
                Console.Write("Enter a Star Rating (1-5): ");//prompt user to input again
                rating = Console.ReadLine();
                ratingIsValid = validateStarRating(rating);
            }
            
            starRating = Int32.Parse(rating);
            Console.Write("Would you like to input a feedback of the hotel? (y/n): ");//prompt for user to enter whether to give feedback of hotel
            string input = Console.ReadLine();
            input.ToLower();
            bool isValid = validateYNInput(input);//validate user input y/n
            while (!isValid)//if input is not valid
            {
                Console.WriteLine("Invalid input.");//display error message
                Console.Write("Enter a valid option (Y/N): ");//prompt user to input again
                input = Console.ReadLine();
                input.ToLower();
                isValid = validateYNInput(input);
            }
            if (input == "y")//if input is 'y'
            {
                Console.Write("Enter your feedback:  ");//prompt user to enter feedback
                string feedback = Console.ReadLine();
                string ratingState = "submitted a star rating and review";
                Rating r = new Rating(1, starRating, feedback, h);//create rating object
                h.addRating(r); //add rating to hotel rating list
                guest.addRating(r);//add rating to guest rating list
                Console.WriteLine("Rating and review submitted successfully.\n");//display success message
                r.RegisterObserver(sysAdmin);//notify obeserver system admin
                r.RatingState = ratingState;
                return r;
            }
            else
            {
                string feedback = "";
                string ratingState = "submitted a star rating";
                Rating r = new Rating(1, starRating, feedback, h);   //create rating object            
                h.addRating(r);//add rating to hotel rating list
                guest.addRating(r);//add rating to guest rating list
                Console.WriteLine("Rating submitted successfully.\n");//display success message
                r.RegisterObserver(sysAdmin);//notify obeserver system admin
                r.RatingState = ratingState;
                return r;
            }
            
            
        }

        private static bool validateYNInput(string input)
        {
            //validation of y/n input for rate hotel use case (Hannah)
            if (input == "y" || input == "n")
                return true;
            else
                return false;
        }

        private static bool validateIdInput(List<Reservation> frList, string? idInput)
        {
            //validation of reservation id input for rate hotel use case (Hannah)
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
            //validation of star rating input for rate hotel use case (Hannah)
            int numericValue;
            bool isNumber = int.TryParse(starRating, out numericValue);
            if (isNumber)
            {
                int sRating = Int32.Parse(starRating);
                if (sRating > 0 && sRating <= 5 && isNumber)
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
                // Display reservation details
                Console.WriteLine("");
                Console.WriteLine("Payment $" + id.Reservation.ReservationPayment.PaymentDue.ToString("0.00") + " for " + "Guest " + id.Reservation.GuestId + ", " + id.Reservation.Room + ", " + id.Reservation.CheckInDate + ", " + id.Reservation.CheckOutDate);

                // Prompt guest for voucher
                Console.WriteLine("Do you have a voucher [Yes/No]");
                Console.WriteLine("[Yes] - \"Yes\"");
                Console.WriteLine("[No] - \"No\"");
                Console.WriteLine("[Exit] - anything else");
                
                // Guest inputs reply
                string reply = Console.ReadLine();

                bool found = false;
                bool run1 = false;
                bool run2 = false;

                int y = 0;
                double paymentPrice = id.Reservation.ReservationPayment.PaymentDue;
                while (run1 == false)
                {
                    // If guest has a voucher
                    if (reply == "Yes")
                    {
                        // Guest inputs voucher
                        Console.WriteLine("Enter voucher code:");
                        string voucherId = Console.ReadLine();

                        // System finds voucher
                        for (int i = 0; i < voucherList.Count(); i++)
                        {
                            if (voucherId == voucherList[i].VoucherId)
                            {
                                y = i;
                                found = true;
                            }
                        }

                        // If voucher is found
                        if (found == true)
                        {
                            int discount = voucherList[y].VoucherDiscount;
                            double percent = (double)(100-discount) / (double)100;
                            paymentPrice = percent * id.Reservation.ReservationPayment.PaymentDue;
                            Console.WriteLine("Voucher applied - " + voucherList[y].VoucherDiscount + "% off.");
                            Console.WriteLine("New reservation payment: $" + (percent * id.Reservation.ReservationPayment.PaymentDue).ToString("0.00"));
                            run1 = true;
                        }
                        // If voucher is not found
                        else
                        {
                            // Prompt guest again
                            Console.WriteLine("Voucher not found.");
                            Console.WriteLine("Re-enter voucher code? [Yes/No]");

                            Console.WriteLine("[Yes] - \"Yes\"");
                            Console.WriteLine("[No] - \"No\"");
                            Console.WriteLine("[Exit] - anything else");
                            string reply1 = Console.ReadLine();

                            // If user wants to re enter voucher code
                            if (reply1 == "Yes")
                            {
                                run1 = false;
                            }
                            // If guest does not want to re enter voucher code
                            else if (reply1 == "No")
                            {
                                run1 = true;
                            }
                            else
                            {
                                // exit program
                                Console.WriteLine("Sequence exited.");
                                System.Environment.Exit(0);
                            }
                        }
                    }

                    // User has no voucher
                    else if (reply == "No")
                    {
                        while (run2 == false)
                        {
                            // proceed to payment method
                            Console.WriteLine("");
                            Console.WriteLine("Payment Methods");
                            Console.WriteLine("[1] Account Balance" + "($" + id.AccountBalance.ToString("0.00") + " available)");
                            Console.WriteLine("[2] Credit Card");
                            Console.WriteLine("[anything else] Leave");

                            Console.WriteLine("Choose payment method:");
                            // Guest types option
                            string choice = Console.ReadLine();

                            // If guest wants to pay with account balance
                            if (choice == "1")
                            {
                                // If guest has enough account balance to cover
                                if (id.AccountBalance >= paymentPrice)
                                {
                                    id.AccountBalance = id.AccountBalance - paymentPrice;
                                    paymentPrice = 0;
                                    Console.WriteLine("You have fully paid for the reservation. New account balance: " + id.AccountBalance.ToString("0.00"));
                                    id.Reservation.ReservationPayment.TransactionSuccessStatus = true;
                                    id.Reservation.ReservationPayment.PaymentMethod = "Account Balance";

                                    // If voucher was used in transaction
                                    if (found == true)
                                    {
                                        Console.WriteLine("You have also used Voucher " + voucherList[y].VoucherId);
                                        id.Reservation.ReservationPayment.VoucherUsed = voucherList[y];
                                    }
                                    run2 = true;
                                }
                                else
                                {
                                    // if account balance does not have enough
                                    paymentPrice = paymentPrice - id.AccountBalance;
                                    id.AccountBalance = 0;
                                    Console.WriteLine("You have fully used up your account balance. Remaining payment due: $" + paymentPrice.ToString("0.00"));

                                    Console.WriteLine("Continue paying by credit card.");
                                    Console.WriteLine("Enter credit card credentials below or \"EXIT\" to Exit: (_ _ _ _  _ _ _ _  _ _ _ _  _ _ _ _) ");
                                    string creditCard = Console.ReadLine();
                                    // ask guest for credit card details
                                    while (creditCard.Length != 19)
                                    {
                                        // if credit card is not valid and EXIT is called
                                        if (creditCard == "EXIT")
                                        {
                                            Console.WriteLine("You have exited program.");
                                            System.Environment.Exit(0);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid credit card credentials");
                                            Console.WriteLine("Enter credit card credentials below or \"EXIT\" to Exit: (_ _ _ _  _ _ _ _  _ _ _ _  _ _ _ _) ");
                                            creditCard = Console.ReadLine();
                                        }
                                    }
                                    // if credit card is valid
                                    if (creditCard.Length == 19)
                                    {
                                        Console.WriteLine("Payment by credit card done successfully.");
                                        id.Reservation.ReservationPayment.TransactionSuccessStatus = true;
                                        id.Reservation.ReservationPayment.PaymentMethod = "Credit Card";
                                        paymentPrice = 0;
                                        System.Environment.Exit(0);
                                    }
                                }
                            }
                            else if (choice == "2")
                            {
                                // guest uses credit card
                                Console.WriteLine("Enter credit card credentials below or \"EXIT\" to Exit: (_ _ _ _  _ _ _ _  _ _ _ _  _ _ _ _) ");
                                string creditCard = Console.ReadLine();

                                // credit card invalid
                                while (creditCard.Length != 19)
                                {
                                    // guest wants to exit 
                                    if (creditCard == "EXIT")
                                    {
                                        Console.WriteLine("You have exited payment.");
                                        System.Environment.Exit(0);
                                    }
                                   else
                                    {
                                        // credit card is invalid
                                        Console.WriteLine("Invalid credit card credentials");
                                        Console.WriteLine("Enter credit card credentials below or \"EXIT\" to Exit: (_ _ _ _  _ _ _ _  _ _ _ _  _ _ _ _) ");
                                        creditCard = Console.ReadLine();
                                        // prompt guest to reenter credit card credentials
                                    }
                                }
                                if (creditCard.Length == 19)
                                {
                                    // payment is successful
                                    Console.WriteLine("Payment by credit card done successfully.");
                                    id.Reservation.ReservationPayment.TransactionSuccessStatus = true;
                                    id.Reservation.ReservationPayment.PaymentMethod = "Credit Card";
                                    paymentPrice = 0;
                                    System.Environment.Exit(0);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Sequence exited.");
                                System.Environment.Exit(0);
                            }

                        }
                    }
                    else 
                    {
                        Console.WriteLine("Sequence exited.");
                        System.Environment.Exit(0);
                    }
                }

                bool run3 = false;

                // after voucher is used
                while (run3 == false)
                {
                    // proceed to payment method
                    Console.WriteLine("");
                    Console.WriteLine("Payment Methods");
                    Console.WriteLine("[1] Account Balance" + "($" + id.AccountBalance.ToString("0.00") + " available)");
                    Console.WriteLine("[2] Credit Card");
                    Console.WriteLine("[anything else] Leave");

                    Console.WriteLine("Choose payment method:");
                    // Guest types option
                    string choice = Console.ReadLine();

                    // If guest wants to pay with account balance
                    if (choice == "1")
                    {
                        // If guest has enough account balance to cover
                        if (id.AccountBalance >= paymentPrice)
                        {
                            id.AccountBalance = id.AccountBalance - paymentPrice;
                            paymentPrice = 0;
                            Console.WriteLine("You have fully paid for the reservation. New account balance: " + id.AccountBalance.ToString("0.00"));
                            id.Reservation.ReservationPayment.TransactionSuccessStatus = true;
                            id.Reservation.ReservationPayment.PaymentMethod = "Account Balance";

                            // If voucher was used in transaction
                            if (found == true)
                            {
                                Console.WriteLine("You have also used Voucher " + voucherList[y].VoucherId);
                                id.Reservation.ReservationPayment.VoucherUsed = voucherList[y];
                            }
                            run2 = true;
                        }
                        else
                        {
                            // if account balance does not have enough
                            paymentPrice = paymentPrice - id.AccountBalance;
                            id.AccountBalance = 0;
                            Console.WriteLine("You have fully used up your account balance. Remaining payment due: $" + paymentPrice.ToString("0.00"));

                            Console.WriteLine("Continue paying by credit card.");
                            Console.WriteLine("Enter credit card credentials below or \"EXIT\" to Exit: (_ _ _ _  _ _ _ _  _ _ _ _  _ _ _ _) ");
                            string creditCard = Console.ReadLine();
                            // ask guest for credit card details
                            while (creditCard.Length != 19)
                            {
                                // if credit card is not valid and EXIT is called
                                if (creditCard == "EXIT")
                                {
                                    Console.WriteLine("You have exited program.");
                                    System.Environment.Exit(0);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid credit card credentials");
                                    Console.WriteLine("Enter credit card credentials below or \"EXIT\" to Exit: (_ _ _ _  _ _ _ _  _ _ _ _  _ _ _ _) ");
                                    creditCard = Console.ReadLine();
                                }
                            }
                            // if credit card is valid
                            if (creditCard.Length == 19)
                            {
                                Console.WriteLine("Payment by credit card done successfully.");
                                id.Reservation.ReservationPayment.TransactionSuccessStatus = true;
                                id.Reservation.ReservationPayment.PaymentMethod = "Credit Card";
                                paymentPrice = 0;
                                System.Environment.Exit(0);
                            }
                        }
                    }
                    else if (choice == "2")
                    {
                        // guest uses credit card
                        Console.WriteLine("Enter credit card credentials below or \"EXIT\" to Exit: (_ _ _ _  _ _ _ _  _ _ _ _  _ _ _ _) ");
                        string creditCard = Console.ReadLine();

                        // credit card invalid
                        while (creditCard.Length != 19)
                        {
                            // guest wants to exit 
                            if (creditCard == "EXIT")
                            {
                                Console.WriteLine("You have exited payment.");
                                System.Environment.Exit(0);
                            }
                            else
                            {
                                // credit card is invalid
                                Console.WriteLine("Invalid credit card credentials");
                                Console.WriteLine("Enter credit card credentials below or \"EXIT\" to Exit: (_ _ _ _  _ _ _ _  _ _ _ _  _ _ _ _) ");
                                creditCard = Console.ReadLine();
                                // prompt guest to reenter credit card credentials
                            }
                        }
                        if (creditCard.Length == 19)
                        {
                            // payment is successful
                            Console.WriteLine("Payment by credit card done successfully.");
                            id.Reservation.ReservationPayment.TransactionSuccessStatus = true;
                            id.Reservation.ReservationPayment.PaymentMethod = "Credit Card";
                            paymentPrice = 0;
                            System.Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sequence exited.");
                        System.Environment.Exit(0);
                    }

                }
            }
            else
            {
                // No reservation payment needed
                Console.WriteLine("No payment needs to be made.");
                System.Environment.Exit(0);
            }

        }

        //implement of cancellation use case (Caleb)
        private static void cancelReservation(Guest guest)
        {
            // Checks whether guest has an existing reservation
            if (guest.Reservation == null)
            {
                Console.WriteLine("You have no reservations.");
            }
            else
            {
                // Display guest's reservation       
                viewReservation(guest);
                Console.WriteLine();
                bool exit = false;
                while (exit == false)
                {
                    // Confirmation prompt
                    Console.Write("Would you like to cancel this reservation? (y/n): ");
                    string userInput = Console.ReadLine();
                    if (userInput == "y")
                    {
                        // Checks whether guest's reservation has already been cancelled
                        if (guest.Reservation.ReservationStatus == "Cancelled")
                        {
                            Console.WriteLine("This reservation has already been cancelled.\n");
                            exit = true;
                        }
                        else
                        {
                            // Initilize Cancellation object in guest's reservation
                            Cancellation cancellation = new Cancellation();
                            guest.Reservation.Cancellation = cancellation;

                            Console.WriteLine();

                            // Check whether current date is at least 2 days before reservation's check-in date
                            if ((guest.Reservation.CheckInDate - DateTime.Now).TotalDays >= 2)
                            {
                                // Check whether guest has already paid for the reservation
                                if (guest.Reservation.ReservationPayment.TransactionSuccessStatus)
                                {
                                    // Credits back amount paid back into guest's account
                                    guest.AccountBalance += guest.Reservation.ReservationPayment.PaymentAmt;
                                    Console.WriteLine("${0} has been credited back to your account!", Math.Round(guest.Reservation.ReservationPayment.PaymentAmt, 2).ToString("0.00"));
                                    Console.WriteLine("Your new account balance: ${0}\n", Math.Round(guest.AccountBalance, 2).ToString("0.00"));
                                }
                                // Check whether guest used a voucher for the reservation
                                if (guest.Reservation.ReservationPayment.VoucherUsed != null)
                                {
                                    // Adds voucher used back into guest's account
                                    guest.addVoucher(guest.Reservation.ReservationPayment.VoucherUsed);
                                    Console.WriteLine("Your voucher {0} with a discount of {1}% has been stored back in your account.\n",
                                        guest.Reservation.ReservationPayment.VoucherUsed.VoucherId,
                                        guest.Reservation.ReservationPayment.VoucherUsed.VoucherDiscount);
                                }

                                // Update room status to "Available"
                                guest.Reservation.Room.RoomStatus = "Available";

                                // Update reservation status to "Cancelled"
                                var context = new Context(new Submitted());
                                string status = context.Request3(guest.Reservation);
                                guest.Reservation.setReservationStatus(status);

                                // Set values for Cancellation object
                                guest.Reservation.Cancellation.CancellationId = "Cancelled_" + guest.Reservation.ReservationId.ToString();
                                // Capturing date of cancellation
                                guest.Reservation.Cancellation.CancellationDate = DateTime.Now;
                                guest.Reservation.Cancellation.AmtRefunded = guest.Reservation.ReservationPayment.PaymentAmt;

                                // Print success message
                                Console.WriteLine("Your reservation has been cancelled!\n");

                                // Display updated reservation
                                viewReservation(guest);
                                exit = true;
                            }
                            else
                            {
                                // Display error message if current date is not at least 2 days before reservation's check-in date
                                Console.WriteLine("Sorry, your reservation cannot be cancelled as the check-in date is less than 2 days away.");
                                exit = true;
                            }
                        }
                    }
                    // Return user to main menu if user enters "n" for confirmation prompt
                    else if (userInput == "n")
                    {
                        exit = true;
                    }
                    // Input validation for confirmation prompt
                    else
                    {
                        Console.WriteLine("Please enter either 'y' or 'n'.");
                    }
                }
            }
        }

      
        private static void displayMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("-----BookHoliStay Menu-------");
            Console.WriteLine("1. Sign in/Sign up");
            Console.WriteLine("2. View All Hotels ");
            Console.WriteLine("3. View All Hotels (Vouchers Accepted)");
            Console.WriteLine("4. Make a Reservation ");
            Console.WriteLine("5. Cancel a Reservation");
            Console.WriteLine("6. Make Payment");
            Console.WriteLine("7. Rate Hotel");
            Console.WriteLine("8. Update Rating");
           
        }

        // View reservation method
        private static void viewReservation(Guest guest)
        {
            Console.WriteLine("----- Your reservation -----");
            Console.WriteLine("Hotel name: " + guest.Reservation.Room.Hotel.HotelName);
            Console.WriteLine("Hotel location: " + guest.Reservation.Room.Hotel.Location);
            Console.WriteLine("Hotel type: " + guest.Reservation.Room.Hotel.HotelType);
            Console.WriteLine("Room type: " + guest.Reservation.Room.RoomType);
            Console.WriteLine("Room cost per night: ${0}", guest.Reservation.Room.Cost.ToString("0.00"));
            Console.WriteLine("Bed type: " + guest.Reservation.Room.BedType);
            Console.WriteLine("Check-in date: " + guest.Reservation.CheckInDate);
            Console.WriteLine("Check-out date: " + guest.Reservation.CheckOutDate);
            // Checks whether guest used a voucher for the reservation
            if (guest.Reservation.ReservationPayment.VoucherUsed != null)
            {
                Console.WriteLine("Voucher discount: {0}%", guest.Reservation.ReservationPayment.VoucherUsed.VoucherDiscount);
            }
            // Checks whethere guest has paid for the reservation
            if (guest.Reservation.ReservationPayment.TransactionSuccessStatus == true)
            {
                // Checks whether reservation has already been cancelled
                if (guest.Reservation.ReservationStatus == "Cancelled")
                {
                    Console.WriteLine("Amount due: ${0} (Refunded ${1} on {2})", 
                        Math.Round(guest.Reservation.ReservationPayment.PaymentDue, 2).ToString("0.00"), 
                        Math.Round(guest.Reservation.Cancellation.AmtRefunded, 2).ToString("0.00"), 
                        guest.Reservation.Cancellation.CancellationDate);
                }
                else
                {
                    Console.WriteLine("Amount due: ${0} (Fully paid ${1} on {2})", 
                        Math.Round(guest.Reservation.ReservationPayment.PaymentDue, 2).ToString("0.00"), 
                        Math.Round(guest.Reservation.ReservationPayment.PaymentAmt, 2).ToString("0.00"), 
                        guest.Reservation.ReservationPayment.DatePaid);
                }
            }              
            else
            {
                Console.WriteLine("Amount due: ${0} (Not paid) (Discounts included)", Math.Round(guest.Reservation.ReservationPayment.PaymentDue, 2).ToString("0.00"));
            }
            Console.WriteLine("Reservation status: {0}", guest.Reservation.ReservationStatus);
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

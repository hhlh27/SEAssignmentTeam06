﻿using SEAssignment;
using System;
using System.Collections.Generic; 
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
            var sysAdmin = new SystemAdmin("abc@gmail.com", "123", "John");
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
            //implement cancellation use case (Caleb)
            throw new NotImplementedException();
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
    }
}

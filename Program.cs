using SEAssignment;
using System;
using System.Collections.Generic;
namespace SEAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                displayMenu();
                Console.Write("Enter an option: ");
                string input= Console.ReadLine();
                switch (input)
                {
                    // Add different cases and print statements depending on the user's input
                    case "1":
                        ManageGuestAccount();

                        break;
                    case "2":
                        ViewAllHotels();

                        break;
                    case "3":
                        ViewHotelDetails();
                        
                        break;
                    case "4":
                        MakeReservation();
                        break;

                    case "5":
                        ManageCancellation();
                        
                        break;
                    case "6":
                        ManageVouchers();

                        break;
                    case "7":
                        ManageRatings();

                        break;
                }

            }


        }

        private static void MakeReservation()
        {
            throw new NotImplementedException();
        }

        private static void ViewAllHotels()

        {
            //implement view hotels using iterator design patter(Hannnah)
            throw new NotImplementedException();
        }

        private static void ManageGuestAccount()
        {
            //implement Guest Account use case(Juliana)
            Console.WriteLine("Guest Account");
        }

        private static void ManageRatings()
        {
            //implement Ratings use case (Hannah)
            Console.WriteLine("Ratings");
        }

        private static void ManageVouchers()
        {
            //implement vouchers use case (Lay How)
            throw new NotImplementedException();
        }

        private static void ManageCancellation()
        {
            //implement cancellation use case (Caleb)
            throw new NotImplementedException();
        }

        private static void ViewHotelDetails()
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
            Console.WriteLine("5. Manage Cancellations");
            Console.WriteLine("6. Manage Vouchers");
            Console.WriteLine("7. Manage Ratings");
            //check in state
            Console.WriteLine("");
        }
    }
}

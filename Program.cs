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
                        ViewHotelDetails();
                        
                        break;

                    case "3":
                        ManageCancellation();
                        
                        break;
                    case "4":
                        ManageVouchers();

                        break;
                    case "5":
                        ManageRatings();

                        break;
                }

            }


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
            Console.WriteLine("2. View Hotel Details");
            Console.WriteLine("3. Manage Cancellations");
            Console.WriteLine("4. Manage Vouchers");
            Console.WriteLine("5. Manage Ratings");
            Console.WriteLine("");
        }
    }
}

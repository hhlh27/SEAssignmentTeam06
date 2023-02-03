using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    class SystemAdmin : IObserver, Person
    {  
        public SystemAdmin(string loginEm, string loginPass)
        {
            LoginEmail = loginEm;
            LoginPassword = loginPass;
        }

        public void ViewGuestAccount();
        public void CreateHotelAccount();
        public void EditRoomRates();
        public void GenerateMonthlyReports();
        public void ViewGuestAccount();

        // Observer pattern method
        public void Update(ISubject subject)
        {
            if ((subject as Rating).RatingState == "StarRatingChanged")
            {
                Console.WriteLine("Administrator has been notified of a change made to the star rating.");
            }
            else if ((subject as Rating).RatingState == "ReviewChanged")
            {
                Console.WriteLine("Administrator has been notified of a change made to the review.");
            }
        }
    }
}

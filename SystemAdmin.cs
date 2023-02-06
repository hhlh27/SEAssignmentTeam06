using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    public class SystemAdmin : Person, IObserver<Rating>
    {
        public void ViewGuestAccount() { }
        public void CreateHotelAccount() { }
        public void EditRoomRates() { }
        public void GenerateMonthlyReports() { }

        // Observer pattern method
        public void Update(Rating ratingData)
        {
            Console.WriteLine(string.Format("*Administrator Notice* Hey {0}, a user has {1}.",Name, ratingData.RatingState));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    public class SystemAdmin : Person, IObserver
    {
        public void ViewGuestAccount() { }
        public void CreateHotelAccount() { }
        public void EditRoomRates() { }
        public void GenerateMonthlyReports() { }

        // Observer pattern method
        public void Update(Rating rating)
        {
            Console.WriteLine(string.Format("*Administrator Notice* A user has {0}. (RatingId: {1})", rating.RatingState, rating.RatingId));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    class SystemAdmin : Person, IObserver
    {
        public SystemAdmin(string loginEmail, string loginPassword, string name)
        {
            LoginEmail= loginEmail;
            LoginPassword= loginPassword;
            Name= name;
        }

        public void ViewGuestAccount() { }
        public void CreateHotelAccount() { }
        public void EditRoomRates() { }
        public void GenerateMonthlyReports() { }

        // Observer pattern method
        public void Update(string ratingState)
        {
            Console.WriteLine(string.Format("*Notice* Hey Administrator {0}, a user has {1}.",Name, ratingState));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    public class HotelAdmin : Person
    {
        public Hotel Hotel { get; set; }
        public void GenerateReservationList(string hotelId) { }
        public void ViewMonthlyReports(string hotelId) { }
    }
}

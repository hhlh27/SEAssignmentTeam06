
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{                    
    public class Hotel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string Location { get; set; }
        public string HotelType { get; set; }
        public bool IsVouchersAllowed { get; set; }
        public int ReviewScore { get; set; }

        private List<Room> roomsList = new List<Room>();
        private List<Guest> guestsList = new List<Guest>();
        private List<string> faciltiesList = new List<string>();

        private List<Rating> ratingsList = new List<Rating>();
        public Hotel(int hotelId, string hotelName, string location, string hotelType, bool isVouchersAllowed, int reviewScore)
        {
            HotelId = hotelId;
            HotelName = hotelName;
            Location = location;
            HotelType = hotelType;
            IsVouchersAllowed = isVouchersAllowed;
            ReviewScore = reviewScore;
        }
        public Hotel() { }
        public void addRating(Rating r)
        {

            ratingsList.Add(r);
        }

        public void addRoom(Room room)
        {
            roomsList.Add(room);
        }
    }
}

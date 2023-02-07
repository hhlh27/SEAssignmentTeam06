using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    public class Room
    {
        public int RoomId { get; set; }
        public Hotel Hotel { get; set; }
        public string RoomType { get; set; }
        public string BedType { get; set; }
        public bool IsBreakfastServed { get; set; }
        public int MaxNumGuests { get; set; }
        public double Cost { get; set; }
        public string RoomStatus { get; set; }

        private List<Reservation> reservationsList = new List<Reservation>();

        public Room(int roomId, Hotel hotel, string roomType, string bedType, bool isBreakfastServed, int maxGuest, double cost, string roomStatus)
        {
            RoomId = roomId;
            Hotel = hotel;
            RoomType = roomType;
            BedType = bedType;
            IsBreakfastServed = isBreakfastServed;
            MaxNumGuests = maxGuest;
            Cost = cost;
            RoomStatus = roomStatus;
        }

        public Room() { }
    }
}

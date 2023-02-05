using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    class Room
    {
        public int RoomId { get; set; }
        public string RoomType { get; set; }
        public string BedType { get; set; }
        public bool IsBreakfastServed { get; set; }
        public int MaxNumGuests { get; set; }
        public double Cost { get; set; }

        public Room(int roomId, string roomType, string bedType, bool isBreakfastServed, int maxGuest, double cost)
        {
            RoomId = roomId;
            RoomType = roomType;
            BedType = bedType;
            IsBreakfastServed = isBreakfastServed;
            MaxNumGuests = maxGuest;
            Cost = cost;
        }
    }
}

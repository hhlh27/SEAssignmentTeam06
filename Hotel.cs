﻿//Implementation of Hotel Class(Hannah)
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

        private List<Rating> ratingsList = new List<Rating>();
        public Hotel(int id, string n, string l, string ht, bool iv, int r)
        {
            HotelId = id;
            HotelName = n;
            Location = l;
            HotelType = ht;
            IsVouchersAllowed = iv;
            ReviewScore = r;
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

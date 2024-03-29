﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    public class Guest : Person
    {
        private List<Voucher> vouchersList = new List<Voucher>();
        private List<Rating> ratingsList= new List<Rating>();
        private List<Reservation> reservationsList = new List<Reservation>();
        public int GuestId { get; set; }
        public string PersonalId { get; set; }
        public int ContactNum { get; set; }
        public double AccountBalance { get; set; } = 0;
        public int HotelId { get; set; }
        public Reservation Reservation { get; set; }

        public Guest(int guestID, string personalID, int contactNum, double accountBalance, Reservation reservation)
        {
            GuestId = guestID;
            PersonalId = personalID;
            ContactNum = contactNum;
            AccountBalance = accountBalance;
            Reservation = reservation;
        }

        public Guest() { }

        public void editProfile(int guestID)
        {
            // implementation
        }
        public void viewBookingHistory()
        {
            // implementation
        }
        public void viewReservation(Reservation reservation)
        {
            // implementation
        }
        public void cancelReservation(Reservation reservation)
        {
            // implementation
        }
        public void signUp(string name, string personalID, int contactNum, string loginEmail)
        {
            // implementation
        }
        public void browseHotelRooms()
        {
            // implementation
        }
        public void viewHotels()
        {
            // implementation
        }
      
        public void addVoucher(Voucher voucher)
        {
            vouchersList.Add(voucher);
        }
        public void addRating(Rating rating)
        {
            ratingsList.Add(rating);
        }
        public List<Rating> getRatings() { return ratingsList; }
        public void updateRating(int updatedRatingIdx, int starRating, string review)
        {
            foreach (Rating r in ratingsList)
            {
                r.StarRating = starRating;
                r.Review = review;
            }
        }
    }
}

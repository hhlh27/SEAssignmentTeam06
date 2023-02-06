//Implementation of Rating Class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    public class Rating
    {
        public int StarRating { get; set; }
        public string Review { get; set; }
        public string RatingState { get; set; }

        public Rating(int starRating, string review, string ratingState) 
        {
            StarRating= starRating;
            Review = review;    
            RatingState= ratingState;
        }

        public Rating() { }

        // public string GetRating() { }
        // public string GetReview() { }
    }
}

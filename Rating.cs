//Implementation of Rating Class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SEAssignment
{
    public class Rating : ISubject
    {
        private List<IObserver> _observers;
        private string _ratingState;
        public int RatingId { get; set; }
        public int StarRating { get; set; }
        public string Review { get; set; }
        public Hotel Hotel { get; set; }

        public string RatingState 
        {
            get { return _ratingState; }
            set
            {
                _ratingState = value;
                NotifyObservers();
            }
        }

        public Rating(int ratingId, int starRating, string review, Hotel hotel) 
        {
            RatingId= ratingId;
            StarRating= starRating;
            Review = review;    
            Hotel = hotel;
            _observers = new List<IObserver>();
        }

        public Rating() { }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            _observers.ForEach(o =>
            {
                o.Update(this);
            });
        }

        // public string GetRating() { }
        // public string GetReview() { }
    }
}

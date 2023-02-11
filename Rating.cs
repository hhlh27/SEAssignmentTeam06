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
        public Guest Guest { get; set; }

        public string RatingState 
        {
            get { return _ratingState; }
            set
            {
                _ratingState = value;
                // Notify observers when RatingState is changed
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
            // Add an observer to the Rating's observers list
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            // Remove an observer from the Rating's observers list
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            _observers.ForEach(o =>
            {
                // Update each observer in the Rating's observer list with the newly updated Rating object
                o.Update(this);
            });
        }

    }
}

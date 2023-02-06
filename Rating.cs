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

        public int StarRating { get; set; }
        public string Review { get; set; }

        public string RatingState 
        {
            get { return _ratingState; }
            set
            {
                _ratingState = value;
                NotifyObservers();
            }
        }

        private string _ratingState;

        public Rating(int starRating, string review) 
        {
            StarRating= starRating;
            Review = review;    
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

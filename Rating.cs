//Implementation of Rating Class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    public class Rating : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
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

        //Rating methods for Observer Pattern(Caleb)
        public void RegisterObserver(IObserver observer)
        {
            this._observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            this._observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in _observers)
            {
                o.Update(RatingState);
            }
        }

        public void setRatingState(string ratingState)
        {
            this.RatingState = ratingState;
            NotifyObservers();
        }

        public string GetRating() { }
        public string GetReview() { }
        public bool RatingChanged() { }
    }
}

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
                o.Update(this);
            }
        }

        public void RatingChanged()
        {
            this.NotifyObservers();
        }
    }
}

//Implementation of HotelIterator for Iterator Design Pattern(Hannah)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    public class HotelIterator : IIterator
    {
        HotelCollection collection;
        int current = 0;
        int step = 1;
        // Constructor
        public HotelIterator(HotelCollection collection)
        {
            this.collection = collection;
        }
        // Gets first item
        public Hotel First()
        {
            current = 0;
            return collection[current] as Hotel;
        }
        // Gets next item
        public Hotel Next()
        {
            current += step;
            if (!IsDone)
                return collection[current] as Hotel;
            else
                return null;
        }
        // Gets or sets stepsize
        public int Step
        {
            get { return step; }
            set { step = value; }
        }
        // Gets current iterator item
        public Hotel CurrentItem
        {
            get { return collection[current] as Hotel; }
        }
        // Gets whether iteration is complete
        public bool IsDone
        {
            get { return current >= collection.Count; }
        }
    }
}


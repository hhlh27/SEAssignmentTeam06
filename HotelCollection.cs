//Implementation of HotelCollection Class for Iterator Design Pattern(Hannah)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    public class HotelCollection : ICollection
    {
        List<Hotel> items = new List<Hotel>();
        public IIterator CreateIterator()
        {
            return new HotelIterator(this);
        }
        // Get item count
        public int Count
        {
            get { return items.Count; }
        }
        //indexer
        public object this[int index]
        {
            get { return items[index]; }
            set { items.Add((Hotel)value); }
        }
    }

}

//Implementation of ICollection for Iterator Design Pattern(Hannah)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    public interface ICollection
    {
        public abstract IIterator CreateIterator();
    }
}


//Implementation of IIterator for Iterator Design Pattern(Hannah)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    public interface IIterator
    {

        Hotel First();
        Hotel Next();
        bool IsDone { get; }
        Hotel CurrentItem { get; }

    }
}

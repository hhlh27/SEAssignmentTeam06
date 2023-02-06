using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    // Define a generic interface for observers (subscribers) specifying how they should be updated.
    // In traditional observer pattern, the Update method doesn’t specify any parameters and observers keep a reference of the observable (publisher).
    // However, this approach usually creates a problem like memory leak if the observers and observables are not cleansed properly.
    public interface IObserver
    {
        void Update(Rating rating);
    }
}

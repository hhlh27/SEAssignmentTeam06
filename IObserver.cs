using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    public interface IObserver<T>
    {
        void Update(T ratingData);
    }
}

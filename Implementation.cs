using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    // The Context defines the interface of interest to clients. It also
    // maintains a reference to an instance of a State subclass, which
    // represents the current state of the Context.
    class Context
    {
        // A reference to the current state of the Context.
        private State _state = null;

        public Context(State state)
        {
            this.TransitionTo(state);
        }

        // The Context allows changing the State object at runtime.
        public void TransitionTo(State state)
        {
            //Console.WriteLine($"Reservation: Transition to {state.GetType().Name}.");
            this._state = state;
            this._state.SetContext(this);
        }

        // The Context delegates part of its behavior to the current State
        // object.
        public string Request1(Reservation reservation)
        {
            return this._state.Handle1(reservation);
        }

        public string Request2(Reservation reservation)
        {
            return this._state.Handle2(reservation);
        }

        public string Request3(Reservation reservation)
        {
            return this._state.Handle3(reservation);
        }

        public string Request4(Reservation reservation)
        {
            return this._state.Handle4(reservation);
        }

        public string Request5(Reservation reservation)
        {
            return this._state.Handle5(reservation);
        }
    }

    // The base State class declares methods that all Concrete State should
    // implement and also provides a backreference to the Context object,
    // associated with the State. This backreference can be used by States to
    // transition the Context to another State.
    abstract class State
    {
        protected Context _context;

        public void SetContext(Context context)
        {
            this._context = context;
        }

        public abstract string Handle1(Reservation reservation);

        public abstract string Handle2(Reservation reservation);

        public abstract string Handle3(Reservation reservation);

        public abstract string Handle4(Reservation reservation);

        public abstract string Handle5(Reservation reservation);
    }

    // Concrete States implement various behaviors, associated with a state of
    // the Context.
    class Submitted : State
    {
        public override string Handle1(Reservation reservation)
        {
            //implementation
            return "Submitted";
        }

        public override string Handle2(Reservation reservation)
        {
            if (reservation.ReservationPayment != null)
            {
                this._context.TransitionTo(new Confirmed());
                return "Confirmed";
            }

            return "";
        }

        public override string Handle3(Reservation reservation)
        {
            if (reservation.Cancellation != null)
            {
                this._context.TransitionTo(new Cancelled());
                return "Cancelled";
            }

            return "";
        }

        public override string Handle4(Reservation reservation)
        {
            this._context.TransitionTo(new Fulfilled());
            return "Fulfilled";
        }

        public override string Handle5(Reservation reservation)
        {
            this._context.TransitionTo(new NoShow());
            return "No Show";
        }
    }

    class Confirmed : State
    {
        public override string Handle1(Reservation reservation)
        {
            return "";
        }

        public override string Handle2(Reservation reservation)
        {
            //implementation
            return "";
        }

        public override string Handle3(Reservation reservation)
        {
            //implementation
            return "";
        }

        public override string Handle4(Reservation reservation)
        {
            //implementation
            return "";
        }

        public override string Handle5(Reservation reservation)
        {
            //implementation
            return "";
        }
    }

    class Cancelled : State
    {
        public override string Handle1(Reservation reservation)
        {
            return "";
        }

        public override string Handle2(Reservation reservation)
        {
            //implementation
            return "";
        }

        public override string Handle3(Reservation reservation)
        {
            //implementation
            return "";
        }

        public override string Handle4(Reservation reservation)
        {
            //implementation
            return "";
        }

        public override string Handle5(Reservation reservation)
        {
            //implementation
            return "";
        }
    }

    class Fulfilled : State
    {
        public override string Handle1(Reservation reservation)
        {
            return "";
        }

        public override string Handle2(Reservation reservation)
        {
            //implementation
            return "";
        }

        public override string Handle3(Reservation reservation)
        {
            //implementation
            return "";
        }

        public override string Handle4(Reservation reservation)
        {
            //implementation
            return "";
        }

        public override string Handle5(Reservation reservation)
        {
            //implementation
            return "";
        }
    }

    class NoShow : State
    {
        public override string Handle1(Reservation reservation)
        {
            return "";
        }

        public override string Handle2(Reservation reservation)
        {
            //implementation
            return "";
        }

        public override string Handle3(Reservation reservation)
        {
            //implementation
            return "";
        }

        public override string Handle4(Reservation reservation)
        {
            //implementation
            return "";
        }

        public override string Handle5(Reservation reservation)
        {
            //implementation
            return "";
        }
    }
}

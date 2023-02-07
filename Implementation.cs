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
            Console.WriteLine($"Reservation: Transition to {state.GetType().Name}.");
            this._state = state;
            this._state.SetContext(this);
        }

        // The Context delegates part of its behavior to the current State
        // object.
        public void Request1()
        {
            this._state.Handle1();
        }

        public void Request2()
        {
            this._state.Handle2();
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

        public abstract void Handle1();

        public abstract void Handle2();
    }

    // Concrete States implement various behaviors, associated with a state of
    // the Context.
    class Submitted : State
    {
        public override void Handle1()
        {
            this._context.TransitionTo(new Confirmed());
        }

        public override void Handle2()
        {
            Console.WriteLine("ConcreteStateA handles request2.");
        }
    }

    class Confirmed : State
    {
        public override void Handle1()
        {
            Console.Write("ConcreteStateB handles request1.");
        }

        public override void Handle2()
        {
            this._context.TransitionTo(new Submitted());
        }
    }
}

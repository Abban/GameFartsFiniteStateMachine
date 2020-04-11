using System;
using System.Collections.Generic;

namespace BBX.Library.FSM
{
    public abstract class State : IState
    {
        protected readonly List<Type> CanMoveToStates = new List<Type>();
        protected Type FromState;


        /// <inheritdoc />
        public virtual void Start(Type lastState)
        {
            FromState = lastState;
        }

        /// <inheritdoc />
        public virtual void Update()
        {
        }
        
        
        /// <inheritdoc />
        public abstract void Exit();


        /// <inheritdoc />
        public bool CanMoveToState(Type type)
        {
            return CanMoveToStates.Contains(type);
        }
    }
}
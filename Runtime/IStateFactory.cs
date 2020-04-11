using System;

namespace BBX.Library.FSM
{
    public interface IStateFactory
    {
        /// <summary>
        /// Get a new state for the state machine
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IState Get(Type type);
    }
}
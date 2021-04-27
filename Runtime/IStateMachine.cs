using System;

namespace GF.Library.FSM
{
    public interface IStateMachine : IStateMachineState
    {
        /// <summary>
        /// Try and change to a new state
        /// </summary>
        /// <param name="type"></param>
        void ChangeState(Type type);
        
        
        /// <summary>
        /// Check the current state against a type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool CurrentStateIs(Type type);
        
        
        /// <summary>
        /// Check the last state against a type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool LastStateWas(Type type);
    }
}
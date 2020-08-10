using System;
using GF.Library.FSM;

namespace StateMachineExample
{
    public class GameStateMachine : StateMachine
    {
        public static Action<Type> StateChangeEvent = type => { };
        
        public GameStateMachine(IStateFactory factory) : base(factory)
        {
        }

        public override void ChangeState(Type type)
        {
            base.ChangeState(type);
            
            if (!LastStateWas(type) && CurrentStateIs(type))
            {
                StateChangeEvent.Invoke(type);
            }
        }
    }
}
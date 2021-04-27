using System;

namespace GF.Library.FSM
{
    public interface IStateMachineState
    {
        IState CurrentState { get; }
        Type LastStateType { get; }
    }
}
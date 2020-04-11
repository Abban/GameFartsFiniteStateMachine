using System;

namespace BBX.Library.FSM.Tests.Fixtures
{
    public abstract class TestState : State
    {
        private readonly Action _startCallback;
        private readonly Action _exitCallback;

        protected TestState(
            Action startCallback,
            Action exitCallback)
        {
            _startCallback = startCallback;
            _exitCallback = exitCallback;
        }

        
        public override void Start(Type lastState)
        {
            base.Start(lastState);
            _startCallback?.Invoke();
        }


        public override void Exit()
        {
            _exitCallback?.Invoke();
        }
    }
}
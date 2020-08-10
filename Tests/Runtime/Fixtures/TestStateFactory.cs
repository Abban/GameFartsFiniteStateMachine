using System;

namespace GF.Library.FSM.Tests.Fixtures
{
    public class TestStateFactory : IStateFactory
    {
        private readonly Action _firstStartAction;
        private readonly Action _firstExitAction;


        public TestStateFactory(
            Action firstStartAction,
            Action firstExitAction)
        {
            _firstStartAction = firstStartAction;
            _firstExitAction = firstExitAction;
        }


        public IState Get(Type type)
        {
            if (type == typeof(TestStateFirst))
            {
                return new TestStateFirst(_firstStartAction, _firstExitAction);
            }

            if (type == typeof(TestStateSecond))
            {
                return new TestStateSecond(null, null);
            }
            
            if (type == typeof(TestStateNotAllowed))
            {
                return new TestStateNotAllowed(null, null);
            }
            
            throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}
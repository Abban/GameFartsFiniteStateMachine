using System;

namespace GF.Library.FSM.Tests.Fixtures
{
    public class TestStateFirst : TestState
    {
        public TestStateFirst(Action startCallback, Action exitCallback) : base(startCallback, exitCallback)
        {
            CanMoveToStates.Add(typeof(TestStateSecond));
        }
    }
}
using System;

namespace GF.Library.FSM.Tests.Fixtures
{
    public class TestStateSecond : TestState
    {
        public TestStateSecond(Action startCallback, Action exitCallback) : base(startCallback, exitCallback)
        {
            CanMoveToStates.Add(typeof(TestStateFirst));
        }
    }
}
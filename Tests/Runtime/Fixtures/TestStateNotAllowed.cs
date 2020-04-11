using System;

namespace BBX.Library.FSM.Tests.Fixtures
{
    public class TestStateNotAllowed : TestState
    {
        public TestStateNotAllowed(Action startCallback, Action exitCallback) : base(startCallback, exitCallback)
        {
        }
    }
}
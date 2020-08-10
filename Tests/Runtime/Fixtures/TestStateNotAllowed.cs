using System;

namespace GF.Library.FSM.Tests.Fixtures
{
    public class TestStateNotAllowed : TestState
    {
        public TestStateNotAllowed(Action startCallback, Action exitCallback) : base(startCallback, exitCallback)
        {
        }
    }
}
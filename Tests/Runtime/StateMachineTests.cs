using System;
using NUnit.Framework;
using Debug = UnityEngine.Debug;
using GF.Library.FSM.Tests.Fixtures;

namespace GF.Library.FSM.Tests
{
    [TestFixture]
    public class StateMachineTests
    {
        [Test]
        public void OnChangeState_ChangesState()
        {
            var factory = new TestStateFactory(null, null);
            var stateMachine = new StateMachine(factory);

            var state = stateMachine.CurrentState;
            stateMachine.ChangeState(typeof(TestStateFirst));
            Assert.That(state != stateMachine.CurrentState);
            Assert.That(stateMachine.CurrentStateIs(typeof(TestStateFirst)));
        }


        [Test]
        public void OnChangeState_SetsLastType()
        {
            var factory = new TestStateFactory(null, null);
            var stateMachine = new StateMachine(factory);

            stateMachine.ChangeState(typeof(TestStateFirst));
            stateMachine.ChangeState(typeof(TestStateSecond));
            Assert.That(stateMachine.LastStateWas(typeof(TestStateFirst)));
        }


        [Test]
        public void OnChangeState_CallsStartOnNewState()
        {
            var called = false;
            var factory = new TestStateFactory(() => { called = true; }, null);
            var stateMachine = new StateMachine(factory);

            stateMachine.ChangeState(typeof(TestStateFirst));
            Assert.That(called);
        }


        [Test]
        public void OnChangeState_CallsExitOnOldState()
        {
            var called = false;
            var factory = new TestStateFactory(null, () => { called = true; });
            var stateMachine = new StateMachine(factory);

            stateMachine.ChangeState(typeof(TestStateFirst));
            Assert.That(!called);
            stateMachine.ChangeState(typeof(TestStateSecond));
            Assert.That(called);
        }


        [Test]
        public void OnRequestToChangeStateToStateNotAllowed_ThrowsException()
        {
            var factory = new TestStateFactory(null, null);
            var stateMachine = new StateMachine(factory);

            stateMachine.ChangeState(typeof(TestStateFirst));

            Assert.Throws<ArgumentOutOfRangeException>(() => stateMachine.ChangeState(typeof(TestStateNotAllowed)));
        }
    }
}
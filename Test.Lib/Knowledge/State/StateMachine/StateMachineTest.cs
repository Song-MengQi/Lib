using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Lib;

namespace Test.Lib
{
    [TestClass]
    public class StateMachineTest
    {
        private enum TestState
        {
            A, B, C, D
        }
        private enum TestAction
        {
            X, Y, Z
        }
        private interface ITestStateMachine : IStateMachine<TestState, TestAction>
        {

        }
        private class TestStateMachine : StateMachineBase<TestStateMachine, ITestStateMachine, TestState, TestAction>, ITestStateMachine
        {
            public TestStateMachine() : base()
            {
                Assert.AreEqual(DoAction(TestState.A, TestAction.X), TestState.A);

                Dic = new Dictionary<TestState, Dictionary<TestAction, TestState>> {
                    { TestState.A, new Dictionary<TestAction, TestState> {
                        { TestAction.X, TestState.B },
                        { TestAction.Y, TestState.C },
                    } },
                    { TestState.B, new Dictionary<TestAction, TestState> {
                        { TestAction.Z, TestState.C },
                    } },
                    { TestState.C, new Dictionary<TestAction, TestState> {
                    } },
                };
            }
        }
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(TestStateMachine.Instance.DoAction(TestState.A, TestAction.X), TestState.B);
            Assert.AreEqual(TestStateMachine.Instance.DoAction(TestState.A, TestAction.Y), TestState.C);
            Assert.AreEqual(TestStateMachine.Instance.DoAction(TestState.B, TestAction.Z), TestState.C);
            Assert.AreEqual(TestStateMachine.Instance.DoAction(TestState.C, TestAction.X), TestState.C);


            Assert.AreEqual(TestStateMachine.Instance.DoAction(TestState.D, TestAction.Z), TestState.D);
            Assert.AreEqual(TestStateMachine.Instance.DoAction(TestState.A, TestAction.Z), TestState.A);
        }
    }
}

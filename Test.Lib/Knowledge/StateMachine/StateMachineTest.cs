using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test.Lib
{
    [TestClass]
    public class StateMachineTest : TestBase
    {
        #region 附加测试特性
        //在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext) { }

        //在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup() { }

        //在运行每个测试之前，使用 TestInitialize 来运行代码
        //[TestInitialize()]
        //public void MyTestInitialize() { }

        //在每个测试运行完之后，使用 TestCleanup 来运行代码
        //[TestCleanup()]
        //public void MyTestCleanup() { }
        #endregion
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

            TestStateMachine.UnsetInstance();
        }

        private class TestStateMachine2 : StateMachineBase<TestStateMachine2, ITestStateMachine, TestState, TestAction, TestState>, ITestStateMachine
        {
            //不override GetDefaultResult
            public TestStateMachine2() : base()
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
        public void Test2()
        {
            Assert.AreEqual(TestStateMachine2.Instance.DoAction(TestState.D, TestAction.X), default(TestState));
            Assert.AreEqual(TestStateMachine2.Instance.DoAction(TestState.A, TestAction.Z), default(TestState));

            TestStateMachine2.Instance.Dic = default(Dictionary<TestState, Dictionary<TestAction, TestState>>);
            Assert.AreEqual(TestStateMachine2.Instance.DoAction(TestState.A, TestAction.X), default(TestState));

            TestStateMachine2.UnsetInstance();
        }
    }
}

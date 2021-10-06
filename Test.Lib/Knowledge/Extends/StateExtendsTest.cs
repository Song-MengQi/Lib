using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class StateExtendsTest : TestBase
    {
        [TestMethod]
        public void TestGetState()
        {
            Assert.AreEqual(State.Negative, StateExtends.GetState(false));
            Assert.AreEqual(State.Positive, StateExtends.GetState(true));

            Assert.AreEqual(State.Negative, StateExtends.GetState(false, false));
            Assert.AreEqual(State.NegativeToPositive, StateExtends.GetState(false, true));
            Assert.AreEqual(State.PositiveToNegative, StateExtends.GetState(true, false));
            Assert.AreEqual(State.Positive, StateExtends.GetState(true, true));
        }
    }
}

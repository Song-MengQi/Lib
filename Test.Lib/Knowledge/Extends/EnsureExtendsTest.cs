using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class EnsureExtendsTest
    {
        [TestMethod]
        public void TestEnsureBool()
        {
            bool flag = false;
            int times = 0;

            EnsureExtends.Ensure(ref flag, () => { ++times; return 1; });
            Assert.IsFalse(flag);
            Assert.AreEqual(times, 1);

            EnsureExtends.Ensure(ref flag, () => { ++times; return 0; });
            Assert.IsTrue(flag);
            Assert.AreEqual(times, 2);

            EnsureExtends.Ensure(ref flag, () => { ++times; return 0; });
            Assert.IsTrue(flag);
            Assert.AreEqual(times, 2);
        }
        [TestMethod]
        public void TestEnsureState()
        {
            State flag = State.None;
            int times = 0;

            EnsureExtends.Ensure(ref flag, () => { ++times; return 1; });
            Assert.AreNotEqual(flag, State.Positive);
            Assert.AreEqual(times, 1);

            EnsureExtends.Ensure(ref flag, () => { ++times; return 0; });
            Assert.AreEqual(flag, State.Positive);
            Assert.AreEqual(times, 2);

            EnsureExtends.Ensure(ref flag, () => { ++times; return 0; });
            Assert.AreEqual(flag, State.Positive);
            Assert.AreEqual(times, 2);
        }
        [TestMethod]
        public void TestEnsureFunc()
        {
            bool flag = false;
            int times = 0;

            EnsureExtends.Ensure(()=>flag, ()=>flag=true, () => { ++times; return 1; });
            Assert.IsFalse(flag);
            Assert.AreEqual(times, 1);

            EnsureExtends.Ensure(()=>flag, ()=>flag=true, () => { ++times; return 0; });
            Assert.IsTrue(flag);
            Assert.AreEqual(times, 2);

            EnsureExtends.Ensure(()=>flag, ()=>flag=true, () => { ++times; return 0; });
            Assert.IsTrue(flag);
            Assert.AreEqual(times, 2);
        }
    }
}
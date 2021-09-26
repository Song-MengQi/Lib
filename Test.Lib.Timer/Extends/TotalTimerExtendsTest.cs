using Lib.Timer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test.Lib.Timer
{
    [TestClass]
    public class TotalTimerExtendsTest
    {
        [TestMethod]
        public void Test()
        {
            Action action = () => { };
            ulong key = 0ul;

            TotalTimerExtends.RegisterRepeat(ref key, action, 1);
            Assert.AreNotEqual(key, 0ul);
            TotalTimerExtends.UnRegisterRepeat(ref key);
            Assert.AreEqual(key, 0ul);

            TotalTimerExtends.RegisterOnce(ref key, action, 1);
            Assert.AreNotEqual(key, 0ul);
            TotalTimerExtends.UnRegisterOnce(ref key);
            Assert.AreEqual(key, 0ul);
        }
    }
}

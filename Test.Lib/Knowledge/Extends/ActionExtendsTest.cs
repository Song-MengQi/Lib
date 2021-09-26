using System;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class ActionExtendsTest : TestBase
    {
        [TestMethod]
        public void TestInvoke()
        {
            int x = 0;
            ActionExtends.Invoke(() => ++x);
            Assert.AreEqual(x, 1);

            int y = 100;
            Action<int> action = i => x=i;
            ActionExtends.Invoke(action, y);
            Assert.AreEqual(x, y);

            ActionExtends.Invoke(default(Action));
            ActionExtends.Invoke(default(Action<int>), y);
        }
    }
}
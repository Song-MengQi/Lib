using System;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class FuncExtendsTest : TestBase
    {
        [TestMethod]
        public void TestInvoke()
        {
            int x = 1;
            Assert.AreEqual(FuncExtends.Invoke(() => x), x);
            FuncExtends.Invoke(default(Func<int>));
        }
    }
}

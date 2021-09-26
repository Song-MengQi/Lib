using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lib;

namespace Test.Lib
{
    [TestClass]
    public class DateTimeExtendTest : TestBase
    {
        [TestMethod]
        public void Test()
        {
            DateTime.Now.GetMillisecond();
        }
    }
}
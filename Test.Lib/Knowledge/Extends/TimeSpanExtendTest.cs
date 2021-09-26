using System;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class TimeSpanExtendTest : TestBase
    {
        [TestMethod]
        public void TestToSeconds()
        {
            DateTime now = DateTime.Now;
            Assert.AreEqual((now.AddSeconds(1) - now).ToSeconds(), 1L);
        }
        [TestMethod]
        public void TestToMinutes()
        {
            DateTime now = DateTime.Now;
            Assert.AreEqual((now.AddMinutes(2) - now).ToMinutes(), 2L);
        }
        [TestMethod]
        public void TestToHours()
        {
            DateTime now = DateTime.Now;
            Assert.AreEqual((now.AddHours(3) - now).ToHours(), 3L);
        }
        [TestMethod]
        public void TestToDays()
        {
            DateTime now = DateTime.Now;
            Assert.AreEqual((now.AddDays(4) - now).ToDays(), 4L);
        }
    }
}
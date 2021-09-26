using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib;

namespace Test.Lib
{
    [TestClass]
    public class BoolExtendTest : TestBase
    {
        [TestMethod]
        public void TestToByte()
        {
            Assert.AreEqual(false.ToByte(), (byte)0);
            Assert.AreEqual(true.ToByte(), (byte)1);
        }
        [TestMethod]
        public void TestToByteString()
        {
            Assert.AreEqual(false.ToByteString(), "0");
            Assert.AreEqual(true.ToByteString(), "1");
        }
    }
}
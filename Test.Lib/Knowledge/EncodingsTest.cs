using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class EncodingsTest : TestBase
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsNotNull(Encodings.UTF8);
            Assert.IsNotNull(Encodings.UTF32);
            Assert.IsNotNull(Encodings.Unicode);
            Assert.IsNotNull(Encodings.BigEndianUnicode);
        }
    }
}
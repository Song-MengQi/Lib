using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Test.Lib
{
    [TestClass]
    public class StreamExtendTest
    {
        [TestMethod]
        public void TestToBytes()
        {
            byte[] bytes = new byte[] { 1, 2 };
            MemoryStream memoryStream = new MemoryStream(bytes);
            AssertExtends.AreSequenceEqual(bytes, memoryStream.ToBytes());
        }
    }
}

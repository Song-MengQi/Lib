using System.IO;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.IsTrue(IEnumerableExtends.SequenceEqual(bytes, memoryStream.ToBytes()));
        }
    }
}

using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class CompressionExtendsTest : TestBase
    {
        [TestMethod]
        public void TestCompression()
        {
            byte[] bytes = StringExtends.StringToBytes("UserId=root;Password=Password;CharacterSet=utf8mb4;Protocol=NamedPipe;Database=Database;Server=localhost;Pipe=Pipe");
            byte[] compressBytes = CompressionExtends.Compress(bytes);
            byte[] decompressBytes = CompressionExtends.Decompress(compressBytes);
            Assert.IsTrue(bytes.Length>compressBytes.Length);
            AssertExtends.AreSequenceEqual(bytes, decompressBytes);
        }
    }
}

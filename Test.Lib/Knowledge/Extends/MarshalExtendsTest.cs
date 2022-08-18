using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class MarshalExtendsTest : TestBase
    {
        [TestMethod]
        public void TestSizeOf()
        {
            Assert.AreEqual(sizeof(int), MarshalExtends.SizeOf<int>());
            Assert.AreEqual(sizeof(long), MarshalExtends.SizeOf<long>());
        }
    }
}
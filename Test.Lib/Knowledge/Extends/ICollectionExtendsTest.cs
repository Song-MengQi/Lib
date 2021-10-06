using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class ICollectionExtendsTest : TestBase
    {
        [TestMethod]
        public void TestIsNullOrEmpty()
        {
            Assert.IsTrue(ICollectionExtends.IsNullOrEmpty(default(int[])));
            Assert.IsTrue(ICollectionExtends.IsNullOrEmpty(new int[0]));
            Assert.IsFalse(ICollectionExtends.IsNullOrEmpty(new int[1]));
        }
    }
}

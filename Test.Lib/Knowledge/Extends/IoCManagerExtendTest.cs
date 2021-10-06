using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class IoCManagerExtendTest : TestBase
    {
        [TestMethod]
        public void TestSets()
        {
            string key = "key";
            Result value = new Result();

            IoCManager<Result>.SetInstance(key, value);
            Assert.AreEqual(value.GetKey(), key);

            IoCManager<Result>.UnsetInstance(key);
            Assert.AreEqual(value.GetKey(), default(string));
        }
    }
}

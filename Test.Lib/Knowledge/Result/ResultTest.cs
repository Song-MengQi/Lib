using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class ResultTest : TestBase
    {
        [TestMethod]
        public void TestResult()
        {
            Result<string> result;
            result = new Result<string>(3);
            Assert.AreEqual(3, result.State);
            Assert.AreEqual(default(string), result.Data);

            result = new Result<string>("qq");
            Assert.AreEqual(0, result.State);
            Assert.AreEqual("qq", result.Data);
        }
    }
}
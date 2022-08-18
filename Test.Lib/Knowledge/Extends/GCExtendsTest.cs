using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class GCExtendsTest : TestBase
    {
        [TestMethod]
        public void TestCollect()
        {
            GCExtends.Collect();
        }
    }
}

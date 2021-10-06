using System.Collections.Generic;
using System.Collections.Specialized;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class NameValueCollectionExtendTest : TestBase
    {
        [TestMethod]
        public void TestToDictionary()
        {
            NameValueCollection nvc = new NameValueCollection {
                {"a", "A"},
                {"b", "B"},
                {"c", "C"}
            };

            Dictionary<string, string> dic = nvc.ToDictionary();
            Assert.AreEqual(dic["a"], "A");
            Assert.AreEqual(dic["b"], "B");
            Assert.AreEqual(dic["c"], "C");
        }
    }
}
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace Test.Lib
{
    [TestClass]
    public class OrderedDictionaryTest : DictionaryTestBase
    {
        [TestMethod]
        public void TestDictionary()
        {
            TestDictionary<OrderedDictionary<int, string>>();

            new OrderedDictionary<int, int>(0);
            new OrderedDictionary<int, int>(default(IEqualityComparer));
            new OrderedDictionary<int, int>(0, default(IEqualityComparer));
        }
    }
}
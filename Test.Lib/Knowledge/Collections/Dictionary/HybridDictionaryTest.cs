using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class HybridDictionaryTest : DictionaryTestBase
    {
        [TestMethod]
        public void TestDictionary()
        {
            TestDictionary<HybridDictionary<int, string>>();
        }
    }
}
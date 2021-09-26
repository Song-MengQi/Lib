using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class ListDictionaryTest : DictionaryTestBase
    {
        [TestMethod]
        public void TestDictionary()
        {
            TestDictionary<ListDictionary<int, string>>();
        }
    }
}
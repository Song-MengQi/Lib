using System.Collections.Generic;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class DictionaryExtendsTest : TestBase
    {
        [TestMethod]
        public void TestFromKVs()
        {
            ulong[] keys = new ulong[] { 1ul, 2ul, 3ul };
            string[] values = new string[] { "A", "B", "C" };

            Dictionary<ulong, string> dic = DictionaryExtends.FromKVs(keys, values);
            Assert.AreEqual(dic[1ul], "A");
            Assert.AreEqual(dic[2ul], "B");
            Assert.AreEqual(dic[3ul], "C");
        }
    }
}
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test.Lib
{
    [TestClass]
    public class KeyValuePairExtendsTest
    {
        [TestMethod]
        public void TestCreate()
        {
            int key = 123;
            string value = "ABC";
            KeyValuePair<int ,string> kv = KeyValuePairExtends.Create(key, value);
            Assert.AreEqual(kv.Key, key);
            Assert.AreEqual(kv.Value, value);
        }
    }
}
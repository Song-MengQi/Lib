using Lib.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Specialized;

namespace Test.Lib.Json
{
    [TestClass]
    public class JsonsTest : TestBase
    {
        private class JsonsTestClass
        {
            public int X { get; set; }
            public string Y { get; set; }
        }
        [TestMethod]
        public void Test()
        {
            JsonsTestClass jtc = new JsonsTestClass {
                X = 1,
                Y = "2"
            };
            JsonsTestClass result;

            string json = Jsons.Serialize(jtc);

            result = Jsons.Deserialize<JsonsTestClass>(json);
            Assert.IsNotNull(result);
            Assert.AreEqual(jtc.X, result.X);
            Assert.AreEqual(jtc.Y, result.Y);

            result = (JsonsTestClass)Jsons.Deserialize(json, typeof(JsonsTestClass));
            Assert.IsNotNull(result);
            Assert.AreEqual(jtc.X, result.X);
            Assert.AreEqual(jtc.Y, result.Y);

            result = Jsons.TryDeserialize<JsonsTestClass>(json);
            Assert.IsNotNull(result);
            Assert.AreEqual(jtc.X, result.X);
            Assert.AreEqual(jtc.Y, result.Y);

            Assert.IsTrue(Jsons.TryDeserialize(json, out result));
            Assert.IsNotNull(result);
            Assert.AreEqual(jtc.X, result.X);
            Assert.AreEqual(jtc.Y, result.Y);

            Assert.IsNull(Jsons.TryDeserialize<JsonsTestClass>(default(string)));

            Assert.IsFalse(Jsons.TryDeserialize(default(string), out result));
            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestConvert()
        {
            ListDictionary ld = new ListDictionary {
                {"X", 1},
                {"Y", "2"},
            };
            JsonsTestClass result;

            result = Jsons.Convert<JsonsTestClass>(ld);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.X, ld["X"]);
            Assert.AreEqual(result.Y, ld["Y"]);

            result = (JsonsTestClass)Jsons.Convert(ld, typeof(JsonsTestClass));
            Assert.IsNotNull(result);
            Assert.AreEqual(result.X, ld["X"]);
            Assert.AreEqual(result.Y, ld["Y"]);

            result = Jsons.TryConvert<JsonsTestClass>(ld);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.X, ld["X"]);
            Assert.AreEqual(result.Y, ld["Y"]);

            Assert.IsTrue(Jsons.TryConvert(ld, out result));
            Assert.IsNotNull(result);
            Assert.AreEqual(result.X, ld["X"]);
            Assert.AreEqual(result.Y, ld["Y"]);

            //注意::null转过来还是null，这种情况认为操作成功
            result = Jsons.TryConvert<JsonsTestClass>(default(object));
            Assert.IsNull(result);

            //注意::null转过来还是null，这种情况认为操作成功
            Assert.IsTrue(Jsons.TryConvert(default(object), out result));
            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestClone()
        {
            JsonsTestClass jtc = new JsonsTestClass {
                X = 1,
                Y = "2"
            };
            JsonsTestClass result = Jsons.Clone(jtc);
            Assert.IsNotNull(result);
            Assert.AreNotEqual(result, jtc);
            Assert.AreEqual(jtc.X, result.X);
            Assert.AreEqual(jtc.Y, result.Y);
        }
    }
}

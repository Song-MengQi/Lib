using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test.Lib
{
    public abstract class DictionaryTestBase
    {
        private void Test1<T>()
             where T : IDictionary<int, string>, new()
        {
            T d = new T();
            Assert.AreEqual(d.Count, 0);
            Assert.IsFalse(d.ContainsKey(1));
            d.Add(1, "123");
            Assert.AreEqual(d.Count, 1);
            Assert.IsTrue(d.ContainsKey(1));
            Assert.IsTrue(d.Remove(1));
            Assert.AreEqual(d.Count, 0);
            Assert.IsFalse(d.ContainsKey(1));
            Assert.IsFalse(d.Remove(2));


            d[1] = "A";
            Assert.AreEqual(d[1], "A");
            string x;
            Assert.IsTrue(d.TryGetValue(1, out x));
            Assert.AreEqual(x, "A");
            Assert.IsFalse(d.TryGetValue(2, out x));
            Assert.AreEqual(x, default(string));

            KeyValuePair<int, string> kv = new KeyValuePair<int, string>(2, "B");
            Assert.IsFalse(d.Contains(kv));
            d.Add(kv);
            Assert.IsTrue(d.Contains(kv));

            KeyValuePair<int, string>[] kvs = new KeyValuePair<int, string>[2];
            d.CopyTo(kvs, 0);
            Assert.AreEqual(kvs[0].Key, 1);
            Assert.AreEqual(kvs[0].Value, "A");
            Assert.AreEqual(kvs[1].Key, 2);
            Assert.AreEqual(kvs[1].Value, "B");

            Assert.IsTrue(d.Remove(kv));
            Assert.IsFalse(d.Contains(kv));

            int[] keys = d.Keys as int[];
            string[] values = d.Values as string[];
            Assert.AreEqual(keys.Length, 1);
            Assert.AreEqual(keys[0], 1);
            Assert.AreEqual(values.Length, 1);
            Assert.AreEqual(values[0], "A");
        }
        private void Test2<T>()
             where T : IDictionary<int, string>, new()
        {
            T d = new T {
                { 1, "A"},
                { 2, "B"},
                { 3, "C"}
            };
            List<KeyValuePair<int, string>> resultList = new List<KeyValuePair<int, string>>();
            foreach (var kv in d)
            {
                resultList.Add(kv);
            }
            Assert.AreEqual(resultList.Count, 3);
            Assert.AreEqual(resultList[0].Key, 1);
            Assert.AreEqual(resultList[0].Value, "A");
            Assert.AreEqual(resultList[1].Key, 2);
            Assert.AreEqual(resultList[1].Value, "B");
            Assert.AreEqual(resultList[2].Key, 3);
            Assert.AreEqual(resultList[2].Value, "C");
        }
        protected void TestDictionary<T>()
            where T : IDictionary<int, string>, new()
        {
            Test1<T>();
            Test2<T>();
        }
    }
}

using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Test.Lib
{
    [TestClass]
    public class IDictionaryExtendTest : TestBase
    {
        [TestMethod]
        public void TestSets()
        {
            IDictionary<string, int> s1 = new Dictionary<string, int> {
                { "A", 1 },
                { "B", 2 },
            };
            IDictionary<string, int> d1 = new Dictionary<string, int> {
                { "B", 20 },
                { "C", 30 },
            };
            s1.Sets(d1);
            Assert.AreEqual(s1["B"], 20);
            Assert.AreEqual(s1["C"], 30);

            ListDictionary s2 = new ListDictionary {
                { "A", 1 },
                { "B", 2 },
            };
            ListDictionary d2 = new ListDictionary {
                { "B", 20 },
                { "C", 30 },
            };
            s2.Sets(d2);
            Assert.AreEqual(s1["B"], 20);
            Assert.AreEqual(s1["C"], 30);
        }
        [TestMethod]
        public void TestUnsets()
        {
            IDictionary<string, int> s1 = new Dictionary<string, int> {
                { "A", 1 },
                { "B", 2 },
            };
            IDictionary<string, int> d1 = new Dictionary<string, int> {
                { "B", 20 },
                { "C", 30 },
            };
            s1.Unsets(d1);
            Assert.IsTrue(s1.ContainsKey("A"));
            Assert.IsFalse(s1.ContainsKey("B"));
            Assert.IsFalse(s1.ContainsKey("C"));

            ListDictionary s2 = new ListDictionary {
                { "A", 1 },
                { "B", 2 },
            };
            ListDictionary d2 = new ListDictionary {
                { "B", 20 },
                { "C", 30 },
            };
            s2.Unsets(d2);
            Assert.IsTrue(s2.Contains("A"));
            Assert.IsFalse(s2.Contains("B"));
            Assert.IsFalse(s2.Contains("C"));
        }
        [TestMethod]
        public void TestGets()
        {
            IDictionary<string, int> s1 = new Dictionary<string, int> {
                { "A", 1 },
                { "B", 2 },
            };
            IDictionary<string, int> d1 = new Dictionary<string, int> {
                { "B", 20 },
                { "C", 30 },
            };
            s1.Gets(d1);
            Assert.IsFalse(d1.ContainsKey("A"));
            Assert.IsTrue(d1.ContainsKey("B"));
            Assert.IsTrue(d1.ContainsKey("C"));
            Assert.AreEqual(d1["B"], 2);
            Assert.AreEqual(d1["C"], 0);

            ListDictionary s2 = new ListDictionary {
                { "A", 1 },
                { "B", 2 },
            };
            ListDictionary d2 = new ListDictionary {
                { "B", 20 },
                { "C", 30 },
            };
            s2.Gets(d2);
            Assert.IsFalse(d2.Contains("A"));
            Assert.IsTrue(d2.Contains("B"));
            Assert.IsTrue(d2.Contains("C"));
            Assert.AreEqual(d2["B"], 2);
            Assert.AreEqual(d2["C"], default(object));
        }

        [TestMethod]
        public void TestX()
        {
            ListDictionary ld = new ListDictionary{
                {1, "1"}
            };
            foreach(var kv in ld.Generalize())
            {
                Assert.AreEqual(kv.Key, 1);
                Assert.AreEqual(kv.Value, "1");
            }
        }
        [TestMethod]
        public void TestAddHead()
        {
            object a = new object();
            ListDictionary ld;

            ld = new ListDictionary();
            ld.AddHead(1, a);
            Assert.AreEqual(a, ld.GetHead().Value);
            Assert.AreEqual(a, ld.GetHeadValue());

            ld = new ListDictionary { { 2, 3 } };
            ld.AddHead(1, a);
            Assert.AreEqual(a, ld.GetHead().Value);
            Assert.AreEqual(a, ld.GetHeadValue());
        }
        [TestMethod]
        public void TestGetHead()
        {
            object a = new object();
            Assert.AreEqual(default(object), (new ListDictionary()).GetHead().Value);
            Assert.AreEqual(a, (new ListDictionary { { 2, a }, { 1, 3 } }).GetHead().Value);
        }
        [TestMethod]
        public void TestGetHeadValue()
        {
            object a = new object();
            Assert.AreEqual(default(object), (new ListDictionary()).GetHeadValue());
            Assert.AreEqual(a, (new ListDictionary { { 2, a }, { 1, 3 } }).GetHeadValue());
        }
        [TestMethod]
        public void TestAddIf()
        {
            ListDictionary ld = new ListDictionary();
            ld.AddIf(0, 0, x => false, x => x.ToString());
            ld.AddIf(0, 0, x => true, x => x.ToString());

            ld.AddIf(1, "1", x => false);
            ld.AddIf(1, "1", x => true);

            ld.AddIf(2, default(string));
            ld.AddIf(2, "2");

            ld.AddIfNotEmpty(3, string.Empty);
            ld.AddIfNotEmpty(3, "3");

            ld.AddIfNotEmptyAnd(4, string.Empty, x => false);
            ld.AddIfNotEmptyAnd(4, string.Empty, x => true);
            ld.AddIfNotEmptyAnd(4, "4", x => false);
            ld.AddIfNotEmptyAnd(4, "4", x => true);

            ld.AddIfByte(5, "x");
            ld.AddIfByte(5, "5");

            ld.AddIfUshort(6, "x");
            ld.AddIfUshort(6, "6");

            ld.AddIfUint(7, "x");
            ld.AddIfUint(7, "7");

            ld.AddIfUlong(8, "x");
            ld.AddIfUlong(8, "8");

            ld.AddIfId(9, "x");
            ld.AddIfId(9, "9");

            ld.AddIfPositiveId(10, "x");
            ld.AddIfPositiveId(10, "10");

            Assert.AreEqual(ld[0], "0");
            Assert.AreEqual(ld[1], "1");
            Assert.AreEqual(ld[2], "2");
            Assert.AreEqual(ld[3], "3");
            Assert.AreEqual(ld[4], "4");
            Assert.AreEqual(ld[5], (byte)5);
            Assert.AreEqual(ld[6], (ushort)6);
            Assert.AreEqual(ld[7], 7u);
            Assert.AreEqual(ld[8], 8ul);
            Assert.AreEqual(ld[9], 9ul);
            Assert.AreEqual(ld[10], 10ul);
        }
    }
}
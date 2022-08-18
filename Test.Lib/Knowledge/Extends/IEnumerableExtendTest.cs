using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Test.Lib
{
    [TestClass]
    public class IEnumerableExtendTest : TestBase
    {
        [TestMethod]
        public void TestAll()
        {
            Assert.IsTrue(new int[] { }.All((x, i) => x > 0));
            Assert.IsTrue(new int[] { 1, 2, 3 }.All((x, i) => x > 0));
            Assert.IsFalse(new int[] { 1, 2, -1 }.All((x, i) => x > 0));
        }
        [TestMethod]
        public void TestAny()
        {
            Assert.IsFalse(new int[] { }.Any((x, i) => x > 0));
            Assert.IsFalse(new int[] { -1, -2, -3 }.Any((x, i) => x > 0));
            Assert.IsTrue(new int[] { 1, 2, -1 }.Any((x, i) => x > 0));
        }
        [TestMethod]
        public void TestOrder()
        {
            int[] source = new int[] {2,1,3};
            int[] result = default(int[]);

            Action assertAction = ()=>{
                Assert.AreEqual(result.Length, source.Length);
                Assert.AreEqual(result[0], 1);
                Assert.AreEqual(result[1], 2);
                Assert.AreEqual(result[2], 3);

            };
            Action assertDescAction = ()=>{
                Assert.AreEqual(result.Length, source.Length);
                Assert.AreEqual(result[0], 3);
                Assert.AreEqual(result[1], 2);
                Assert.AreEqual(result[2], 1);
            };
            #region Order
            result = source.Order().ToArray();
            assertAction();
            result = source.Order(Comparer<int>.Default).ToArray();
            assertAction();
            result = source.Order(false).ToArray();
            assertAction();
            result = source.Order(Comparer<int>.Default, false).ToArray();
            assertAction();

            result = source.OrderDescending().ToArray();
            assertDescAction();
            result = source.OrderDescending(Comparer<int>.Default).ToArray();
            assertDescAction();
            result = source.Order(true).ToArray();
            assertDescAction();
            result = source.Order(Comparer<int>.Default, true).ToArray();
            assertDescAction();
            #endregion

            #region OrderBy
            result = source.OrderBy(i=>i, false).ToArray();
            assertAction();
            result = source.OrderBy(i=>i, Comparer<int>.Default, false).ToArray();
            assertAction();

            result = source.OrderBy(i=>i, true).ToArray();
            assertDescAction();
            result = source.OrderBy(i=>i, Comparer<int>.Default, true).ToArray();
            assertDescAction();
            #endregion
        }
        [TestMethod]
        public void TestTop()
        {
            int[] ints = new int[] { 3, 4, 2, 1, 5 };
            Assert.AreEqual(5, ints.Top((x, y) => x > y));
            Assert.AreEqual(default(int), new int[0].Top((x, y) => x > y));
        }
        [TestMethod]
        public void TestOf()
        {
            string[] strs = new string[] { "3", "4", "2", "1", "5" };
            Assert.AreEqual("5", strs.Of(int.Parse, (x, y) => x > y));
        }
        [TestMethod]
        public void TestMaxOf()
        {
            string[] strs = new string[] { "3", "4", "2", "1", "5" };
            Assert.AreEqual("5", strs.MaxOf(int.Parse));
            Assert.AreEqual("5", strs.MaxOf(uint.Parse));
            Assert.AreEqual("5", strs.MaxOf(byte.Parse));
            Assert.AreEqual("5", strs.MaxOf(ulong.Parse));
        }
        [TestMethod]
        public void TestMinOf()
        {
            string[] strs = new string[] { "3", "4", "2", "1", "5" };
            Assert.AreEqual("1", strs.MinOf(int.Parse));
            Assert.AreEqual("1", strs.MinOf(uint.Parse));
            Assert.AreEqual("1", strs.MinOf(byte.Parse));
            Assert.AreEqual("1", strs.MinOf(ulong.Parse));
        }
        [TestMethod]
        public void TestForeach()
        {
            int f;
            byte[] ints = new byte[] { 1, 2, 3, 4 };

            f = 0;
            ints.Foreach((b) => {
                ++f;
            });
            Assert.AreEqual(4, f);

            f = 0;
            ints.Foreach((b, i) => {
                f += i;//0,1,2,3
            });
            Assert.AreEqual(6, f);
        }

        private class StringEqualityComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                return x.Length == y.Length;
            }
            public int GetHashCode(string obj)
            {
                return obj.GetHashCode();
            }
        }
        private class TestIsUniqueClass
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        private class TestIsUniqueClassEqualityComparer : IEqualityComparer<TestIsUniqueClass>
        {
            public bool Equals(TestIsUniqueClass x, TestIsUniqueClass y)
            {
                return x.X == y.X && x.Y == y.Y;
            }
            public int GetHashCode(TestIsUniqueClass obj)
            {
                return (obj.X << 32 | obj.Y);
            }
        }
        [TestMethod]
        public void TestIsUnique()
        {
            Assert.IsTrue(new int[] { 1, 2, 3 }.IsUnique());
            Assert.IsFalse(new int[] { 3, 2, 3 }.IsUnique());

            StringEqualityComparer stringEqualityComparer = new StringEqualityComparer();
            Assert.IsTrue(new string[]{
                "123", "ABC"
            }.IsUnique());
            Assert.IsFalse(new string[]{
                "123", "123"
            }.IsUnique());

            TestIsUniqueClassEqualityComparer testIsUniqueClassEqualityComparer = new TestIsUniqueClassEqualityComparer();
            Assert.IsTrue(new TestIsUniqueClass[] {
                new TestIsUniqueClass{
                    X = 1,
                    Y = 1
                }, new TestIsUniqueClass{
                    X = 2,
                    Y = 2
                }
            }.IsUnique(testIsUniqueClassEqualityComparer));
            Assert.IsFalse(new TestIsUniqueClass[] {
                new TestIsUniqueClass{
                    X = 1,
                    Y = 1
                }, new TestIsUniqueClass{
                    X = 1,
                    Y = 1
                }
            }.IsUnique(testIsUniqueClassEqualityComparer));
        }
        [TestMethod]
        public void TestSum()
        {
            Assert.AreEqual(new uint[] { 1u, 2u, 3u }.Sum(), 6u);
            Assert.AreEqual(new ulong[] { 1ul, 2ul, 3ul }.Sum(), 6ul);
        }
        [TestMethod]
        public void TestToDictionary()
        {
            KeyValuePair<int, uint>[] kvs = new KeyValuePair<int, uint>[] {
                KeyValuePairExtends.Create(1, 1u),
                KeyValuePairExtends.Create(2, 2u),
                KeyValuePairExtends.Create(3, 3u),
            };
            Dictionary<int, uint> dic = kvs.ToDictionary();
            Assert.AreEqual(dic.Count, 3);
            Assert.AreEqual(dic[1], 1u);
            Assert.AreEqual(dic[2], 2u);
            Assert.AreEqual(dic[3], 3u);
        }
        [TestMethod]
        public void TestToListDictionary()
        {
            int[] ints = new int[0];
            ListDictionary<int, int> dic1;
            ListDictionary<int, string> dic2;
            dic1 = ints.ToListDictionary(i=>i);
            Assert.AreEqual(dic1.Count, 0);
            dic2 = ints.ToListDictionary(i=>i, i=>i.ToString());
            Assert.AreEqual(dic2.Count, 0);

            ints = new int[] { 1, 2, 3 };
            dic1 = ints.ToListDictionary(i=>i);
            Assert.AreEqual(dic1.Count, 3);
            Assert.AreEqual(dic1[1], 1);
            Assert.AreEqual(dic1[2], 2);
            Assert.AreEqual(dic1[3], 3);
            dic2 = ints.ToListDictionary(i=>i, i=>i.ToString());
            Assert.AreEqual(dic2.Count, 3);
            Assert.AreEqual(dic2[1], "1");
            Assert.AreEqual(dic2[2], "2");
            Assert.AreEqual(dic2[3], "3");


            KeyValuePair<int, uint>[] kvs = new KeyValuePair<int, uint>[] {
                KeyValuePairExtends.Create(1, 1u),
                KeyValuePairExtends.Create(2, 2u),
                KeyValuePairExtends.Create(3, 3u),
            };
            ListDictionary<int, uint> dic = kvs.ToListDictionary();
            Assert.AreEqual(dic.Count, 3);
            Assert.AreEqual(dic[1], 1u);
            Assert.AreEqual(dic[2], 2u);
            Assert.AreEqual(dic[3], 3u);
        }
        [TestMethod]
        public void TestX()
        {
            IEnumerable es = new int[]{1};
            foreach(var x in es)
            {
                Assert.AreEqual(1, x);
            }
        }
    }
}
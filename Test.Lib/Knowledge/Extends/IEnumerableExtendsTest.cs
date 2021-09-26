using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Test.Lib
{
    [TestClass]
    public class IEnumerableExtendsTest : TestBase
    {
        [TestMethod]
        public void TestIsNullOrEmpty()
        {
            Assert.IsTrue(IEnumerableExtends.IsNullOrEmpty(default(string[])));
            Assert.IsTrue(IEnumerableExtends.IsNullOrEmpty(new string[0]));
            Assert.IsFalse(IEnumerableExtends.IsNullOrEmpty(new int[] { 1 }));
        }
        [TestMethod]
        public void TestContains()
        {
            Assert.IsFalse(IEnumerableExtends.Contains(default(string[]), default(string)));
            Assert.IsFalse(IEnumerableExtends.Contains(new string[0], default(string)));
            Assert.IsTrue(IEnumerableExtends.Contains(new int[] { 1 }, 1));
        }
        [TestMethod]
        public void TestConcat()
        {
            int[][] intss = new int[][]{
                new int[] { 1, 2 },
                new int[] {2, 3 }
            };
            int[] result = IEnumerableExtends.Concat(intss).ToArray();
            Assert.AreEqual(result.Length, 4);
            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 2);
            Assert.AreEqual(result[2], 2);
            Assert.AreEqual(result[3], 3);
        }
        [TestMethod]
        public void TestIntersect()
        {
            int[][] intss = new int[][]{
                new int[] { 1, 2 },
                new int[] { 2, 3 }
            };
            int[] result = IEnumerableExtends.Intersect(intss).ToArray();
            Assert.AreEqual(result.Length, 1);
            Assert.AreEqual(result[0], 2);
        }
        [TestMethod]
        public void TestUnion()
        {
            int[][] intss = new int[][]{
                new int[] { 1, 2 },
                new int[] {2, 3 }
            };
            int[] result = IEnumerableExtends.Union(intss).ToArray();
            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 2);
            Assert.AreEqual(result[2], 3);
        }
        public class TestEqualityComparer : IEqualityComparer<string>
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
        [TestMethod]
        public void TestSequenceEqual()
        {
            int[] ints1 = new int[] { 1, 2 };
            int[] ints2 = new int[] { 1, 2 };
            Assert.IsFalse(IEnumerableExtends.SequenceEqual(default(int[]), ints1));
            Assert.IsFalse(IEnumerableExtends.SequenceEqual(ints1, default(int[])));
            Assert.IsTrue(IEnumerableExtends.SequenceEqual(default(int[]), default(int[])));
            Assert.IsTrue(IEnumerableExtends.SequenceEqual(ints1, ints2));

            TestEqualityComparer testEqualityComparer = new TestEqualityComparer();
            string[] strs1 = new string[] { "ABC", "de" };
            string[] strs2 = new string[] { "123", "45" };
            Assert.IsFalse(IEnumerableExtends.SequenceEqual(default(string[]), strs1, testEqualityComparer));
            Assert.IsFalse(IEnumerableExtends.SequenceEqual(strs1, default(string[]), testEqualityComparer));
            Assert.IsTrue(IEnumerableExtends.SequenceEqual(default(string[]), default(string[]), testEqualityComparer));
            Assert.IsTrue(IEnumerableExtends.SequenceEqual(strs1, strs1, testEqualityComparer));
        }
    }
}
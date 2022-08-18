using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    public partial class IEnumerableExtendsTest
    {
        [TestMethod]
        public void TestEqualSplit()
        {
            int[] source;
            int[][] result;

            source = new int[0];
            result = source.EqualSplit();
            Assert.AreEqual(result.Length, 0);

            source = new int[] { 1 };
            result = source.EqualSplit();
            Assert.AreEqual(result.Length, 1);
            AssertExtends.AreSequenceEqual(result[0], new int[] { 1 });

            source = new int[] { 1,1 };
            result = source.EqualSplit();
            Assert.AreEqual(result.Length, 1);
            AssertExtends.AreSequenceEqual(result[0], new int[] { 1,1 });

            source = new int[] { 1,2 };
            result = source.EqualSplit();
            Assert.AreEqual(result.Length, 2);
            AssertExtends.AreSequenceEqual(result[0], new int[] { 1 });
            AssertExtends.AreSequenceEqual(result[1], new int[] { 2 });

            source = new int[] { 1,1,1,2,2,2 };
            result = source.EqualSplit();
            Assert.AreEqual(result.Length, 2);
            AssertExtends.AreSequenceEqual(result[0], new int[] { 1,1,1 });
            AssertExtends.AreSequenceEqual(result[1], new int[] { 2,2,2 });
        }
    }
}

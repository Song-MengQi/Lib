using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test.Lib
{
    public static class AssertExtends
    {
        public static void AreSequenceEqual<T>(IEnumerable<T> x, IEnumerable<T> y)
        {
            Assert.IsTrue(IEnumerableExtends.SequenceEqual(x, y));
        }
        public static void AreSequenceEqual<T>(IEnumerable<T> x, IEnumerable<T> y, IEqualityComparer<T> comparer)
        {
            Assert.IsTrue(IEnumerableExtends.SequenceEqual(x, y, comparer));
        }
        public static void AreNotSequenceEqual<T>(IEnumerable<T> x, IEnumerable<T> y)
        {
            Assert.IsFalse(IEnumerableExtends.SequenceEqual(x, y));
        }
        public static void AreNotSequenceEqual<T>(IEnumerable<T> x, IEnumerable<T> y, IEqualityComparer<T> comparer)
        {
            Assert.IsFalse(IEnumerableExtends.SequenceEqual(x, y, comparer));
        }
    }
}

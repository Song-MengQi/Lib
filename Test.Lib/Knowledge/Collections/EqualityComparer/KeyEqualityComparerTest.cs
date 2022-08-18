using System.Collections.Generic;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class KeyEqualityComparerTest
    {
        [TestMethod]
        public void Test()
        {
            IEqualityComparer<KeyValuePair<int, int>> keyEqualityComparer = KeyEqualityComparer<int, int>.Instance;

            Assert.IsTrue(keyEqualityComparer.Equals(new KeyValuePair<int, int>(default(int), 123), new KeyValuePair<int, int>(default(int), 456)));
            Assert.IsFalse(keyEqualityComparer.Equals(new KeyValuePair<int, int>(default(int), 123), new KeyValuePair<int, int>(1, 123)));

            Assert.AreEqual(keyEqualityComparer.GetHashCode(new KeyValuePair<int, int>(default(int), 123)), default(int));
            Assert.AreEqual(keyEqualityComparer.GetHashCode(new KeyValuePair<int, int>(1, 123)), (1 as object).GetHashCode());

            KeyEqualityComparer<int, int>.UnsetInstance();
        }
    }
}
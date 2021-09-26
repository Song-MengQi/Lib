using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Concurrent;
using Lib;

namespace Test.Lib
{
    [TestClass]
    public class ConcurrentQueueExtendsTest : TestBase
    {
        [TestMethod]
        public void TestClear()
        {
            ConcurrentQueue<int> cq = new ConcurrentQueue<int>();
            cq.Enqueue(123);
            Assert.IsFalse(cq.IsEmpty);
            cq.Clear();
            Assert.IsTrue(cq.IsEmpty);
        }
    }
}
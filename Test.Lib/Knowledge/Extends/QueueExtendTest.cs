using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using Lib;

namespace Test.Lib
{
    [TestClass]
    public class QueueExtendTest : TestBase
    {
        [TestMethod]
        public void TestIsEmptyObject()
        {
            Queue queue = new Queue();
            Assert.IsTrue(queue.IsEmpty());
            queue.Enqueue(default(Queue));
            Assert.IsFalse(queue.IsEmpty());
        }
        [TestMethod]
        public void TestTryPeekObject()
        {
            Queue queue = new Queue();
            object result;
            Assert.IsFalse(queue.TryPeek(out result));
            Assert.AreEqual(result, default(object));
            object value = new object();
            queue.Enqueue(value);
            Assert.IsTrue(queue.TryPeek(out result));
            Assert.AreEqual(result, value);
            Assert.IsFalse(queue.IsEmpty());
        }
        [TestMethod]
        public void TestTryDequeueObject()
        {
            Queue queue = new Queue();
            object result;
            Assert.IsFalse(queue.TryDequeue(out result));
            Assert.AreEqual(result, default(object));
            object value = new object();
            queue.Enqueue(value);
            Assert.IsTrue(queue.TryDequeue(out result));
            Assert.AreEqual(result, value);
            Assert.IsTrue(queue.IsEmpty());
        }

        [TestMethod]
        public void TestIsEmpty()
        {
            Queue<int> queue = new Queue<int>();
            Assert.IsTrue(queue.IsEmpty());
            queue.Enqueue(1);
            Assert.IsFalse(queue.IsEmpty());
        }
        [TestMethod]
        public void TestTryPeek()
        {
            Queue<string> queue = new Queue<string>();
            string result;
            Assert.IsFalse(queue.TryPeek(out result));
            Assert.AreEqual(result, default(string));
            string value = "123";
            queue.Enqueue(value);
            Assert.IsTrue(queue.TryPeek(out result));
            Assert.AreEqual(result, value);
            Assert.IsFalse(queue.IsEmpty());
        }
        [TestMethod]
        public void TestTryDequeue()
        {
            Queue<string> queue = new Queue<string>();
            string result;
            Assert.IsFalse(queue.TryDequeue(out result));
            Assert.AreEqual(result, default(string));
            string value = "123";
            queue.Enqueue(value);
            Assert.IsTrue(queue.TryDequeue(out result));
            Assert.AreEqual(result, value);
            Assert.IsTrue(queue.IsEmpty());
        }
    }
}

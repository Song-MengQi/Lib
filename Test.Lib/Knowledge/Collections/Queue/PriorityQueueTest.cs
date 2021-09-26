using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Lib;

namespace Test.Lib
{
    [TestClass]
    public class PriorityQueueTest
    {
        [TestMethod]
        public void TestIEnumerable()
        {
            PriorityQueue<string> priorityQueue = new PriorityQueue<string>(2);
            priorityQueue.Enqueue("a", 1);
            priorityQueue.Enqueue("b", 1);
            priorityQueue.Enqueue("A");

            List<string> resultList = new List<string>();
            foreach(string str in priorityQueue)
            {
                resultList.Add(str);
            }
            Assert.AreEqual(resultList.Count, 3);
            Assert.AreEqual(resultList[0], "A");
            Assert.AreEqual(resultList[1], "a");
            Assert.AreEqual(resultList[2], "b");
        }
        [TestMethod]
        public void TestICollection()
        {
            PriorityQueue<string> priorityQueue = new PriorityQueue<string>(2);
            Assert.IsNotNull(priorityQueue.SyncRoot);
            Assert.IsFalse(priorityQueue.IsSynchronized);

            priorityQueue.Enqueue("a", 1);
            priorityQueue.Enqueue("b", 1);
            priorityQueue.Enqueue("A");

            Array array = new string[3];
            priorityQueue.CopyTo(array);
            Assert.AreEqual(array.GetValue(0) as string, "A");
            Assert.AreEqual(array.GetValue(1) as string, "a");
            Assert.AreEqual(array.GetValue(2) as string, "b");

            string[] strs = new string[3];
            priorityQueue.CopyTo(strs);
            Assert.AreEqual(strs[0], "A");
            Assert.AreEqual(strs[1], "a");
            Assert.AreEqual(strs[2], "b");
        }
        [TestMethod]
        public void Tests()
        {
            PriorityQueue<string> priorityQueue = new PriorityQueue<string>(2);
            Assert.AreEqual(priorityQueue.Count, 0);
            Assert.IsTrue(priorityQueue.IsEmpty);
            Assert.IsFalse(priorityQueue.Contains(default(string)));
            Assert.IsFalse(priorityQueue.Contains(string.Empty));

            string str1 = "123";
            string str2 = "456";
            priorityQueue.Enqueue(str1);
            priorityQueue.Enqueue(str2);
            Assert.AreEqual(priorityQueue.Count, 2);
            Assert.IsFalse(priorityQueue.IsEmpty);
            Assert.IsTrue(priorityQueue.Contains(str1));
            Assert.IsTrue(priorityQueue.Contains(str2));

            Assert.AreEqual(str1, priorityQueue.Peek());
            Assert.AreEqual(priorityQueue.Count, 2);
            Assert.IsTrue(priorityQueue.Contains(str1));
            Assert.IsTrue(priorityQueue.Contains(str2));

            Assert.AreEqual(str1, priorityQueue.Dequeue());
            Assert.AreEqual(priorityQueue.Count, 1);
            Assert.IsFalse(priorityQueue.Contains(str1));
            Assert.IsTrue(priorityQueue.Contains(str2));

            priorityQueue.Clear();
            Assert.AreEqual(priorityQueue.Count, 0);
            Assert.IsFalse(priorityQueue.Contains(str1));
            Assert.IsFalse(priorityQueue.Contains(str2));

            priorityQueue.Enqueue("X", -1);
            priorityQueue.Enqueue("X", 100);
            foreach(var item in priorityQueue)
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void TestTryPeek()
        {
            PriorityQueue<string> priorityQueue = new PriorityQueue<string>();
            string result;
            Assert.IsFalse(priorityQueue.TryPeek(out result));
            Assert.AreEqual(result, default(string));
            string value = "123";
            priorityQueue.Enqueue(value);
            Assert.IsTrue(priorityQueue.TryPeek(out result));
            Assert.AreEqual(result, value);
            Assert.IsFalse(priorityQueue.IsEmpty);
        }
        [TestMethod]
        public void TestTryDequeue()
        {
            PriorityQueue<string> priorityQueue = new PriorityQueue<string>();
            string result;
            Assert.IsFalse(priorityQueue.TryDequeue(out result));
            Assert.AreEqual(result, default(string));
            string value = "123";
            priorityQueue.Enqueue(value);
            Assert.IsTrue(priorityQueue.TryDequeue(out result));
            Assert.AreEqual(result, value);
            Assert.IsTrue(priorityQueue.IsEmpty);
        }
    }
}
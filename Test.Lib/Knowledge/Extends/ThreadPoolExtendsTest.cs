using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test.Lib
{
    [TestClass]
    public class ThreadPoolExtendsTest : TestBase
    {
        [TestMethod]
        public void TestWorkerThreadCount()
        {
            //一开始是Environment.ProcessorCount
            Assert.AreEqual(ThreadPoolExtends.WorkerThreadCountMin, Environment.ProcessorCount);

            //改成8就是8
            ThreadPoolExtends.WorkerThreadCount = 8;
            Assert.AreEqual(ThreadPoolExtends.WorkerThreadCount, 8);

            //区间[Environment.ProcessorCount, short.MaxValue]，之外的会和谐
            ThreadPoolExtends.WorkerThreadCount = Environment.ProcessorCount - 1;
            Assert.AreEqual(ThreadPoolExtends.WorkerThreadCount, Environment.ProcessorCount);
            //最大值就不试了
            //ThreadPoolExtends.WorkerThreadCount = (int)short.MaxValue + 1;
            //Assert.AreEqual(ThreadPoolExtends.WorkerThreadCount, short.MaxValue);

            //再改回来
            ThreadPoolExtends.WorkerThreadCountMin = Environment.ProcessorCount;
            ThreadPoolExtends.WorkerThreadCountMax = (int)short.MaxValue;
            Assert.AreEqual(ThreadPoolExtends.WorkerThreadCount, Environment.ProcessorCount);
        }
        [TestMethod]
        public void TestWorkerThreadCountMin()
        {
            //一开始是Environment.ProcessorCount
            Assert.AreEqual(ThreadPoolExtends.WorkerThreadCountMin, Environment.ProcessorCount);

            //改成8就是8
            ThreadPoolExtends.WorkerThreadCountMin = 8;
            Assert.AreEqual(ThreadPoolExtends.WorkerThreadCountMin, 8);

            //区间[Environment.ProcessorCount, workerThreadsMax]，之外的会和谐
            ThreadPoolExtends.WorkerThreadCountMin = Environment.ProcessorCount - 1;
            Assert.AreEqual(ThreadPoolExtends.WorkerThreadCountMin, Environment.ProcessorCount);
            ThreadPoolExtends.WorkerThreadCountMin = ThreadPoolExtends.WorkerThreadCountMax + 1;
            Assert.AreEqual(ThreadPoolExtends.WorkerThreadCountMin, ThreadPoolExtends.WorkerThreadCountMax);

            //再改回来
            ThreadPoolExtends.WorkerThreadCountMin = Environment.ProcessorCount;
            Assert.AreEqual(ThreadPoolExtends.WorkerThreadCountMin, Environment.ProcessorCount);
        }
        [TestMethod]
        public void TestWorkerThreadCountMax()
        {
            //一开始是short.MaxValue
            Assert.AreEqual(ThreadPoolExtends.WorkerThreadCountMax, (int)short.MaxValue);

            //改成8就是8
            ThreadPoolExtends.WorkerThreadCountMax = 8;
            Assert.AreEqual(ThreadPoolExtends.WorkerThreadCountMax, 8);

            //区间[workerThreadsMin, short.MaxValue]，之外的会和谐
            ThreadPoolExtends.WorkerThreadCountMax = ThreadPoolExtends.WorkerThreadCountMin - 1;
            Assert.AreEqual(ThreadPoolExtends.WorkerThreadCountMax, ThreadPoolExtends.WorkerThreadCountMin);

            ThreadPoolExtends.WorkerThreadCountMax = (int)short.MaxValue + 1;
            Assert.AreEqual(ThreadPoolExtends.WorkerThreadCountMax, (int)short.MaxValue);

            //再改回来
            ThreadPoolExtends.WorkerThreadCountMax = (int)short.MaxValue;
            Assert.AreEqual(ThreadPoolExtends.WorkerThreadCountMax, (int)short.MaxValue);
        }
    }
}

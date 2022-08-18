using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Concurrent;

namespace Test.Lib
{
    [TestClass]
    public class ParallelExtendsTest : TestBase
    {
        [TestMethod]
        public void TestForEach()
        {
            ConcurrentBag<int> concurrentBag = new ConcurrentBag<int>();
            int[] items = new int[] { 1, 2, 3 };
            ParallelExtends.ForEach(items, item=>concurrentBag.Add(item));
            Assert.AreEqual(concurrentBag.Count, items.Length);

            concurrentBag = new ConcurrentBag<int>();
            ParallelExtends.ForEach(items, (item, i)=>concurrentBag.Add(i));
            Assert.AreEqual(concurrentBag.Count, items.Length);
        }
        [TestMethod]
        public void TestSelect()
        {
            int[] items = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            AssertExtends.AreSequenceEqual(ParallelExtends.Select(items, item=>item), items);
            AssertExtends.AreSequenceEqual(ParallelExtends.Select(items, (item, i)=>i), ArrayExtends.GetArray(items.Length, i=>i));
        }
        [TestMethod]
        public void TestFor()
        {
            int from = 1;
            int to = 2;
            ConcurrentBag<int> concurrentBag = new ConcurrentBag<int>();
            ParallelExtends.For(from, to, i=>concurrentBag.Add(i));
            Assert.AreEqual(concurrentBag.Count, to - from);

            from = 10;
            to = 20;
            int[] ints = ParallelExtends.For(from, to, i=>i);
            Assert.AreEqual(ints.Length, to - from);
            for (int i=from; i<to;++i)
            {
                Assert.AreEqual(ints[i-from], i);
            }
        }
        [TestMethod]
        public void TestCheck()
        {
            Assert.AreEqual(ResultState.Success, ParallelExtends.Check(()=>ResultState.Success));
            Assert.AreEqual(ResultState.Fail, ParallelExtends.Check(()=>ResultState.Success, ()=>ResultState.Fail));
        }
        [TestMethod]
        public void TestGetResult()
        {
            Assert.AreEqual(ResultState.Success, ParallelExtends.GetResult(()=>new Result()).State);
            Assert.AreEqual(ResultState.Fail, ParallelExtends.GetResult(()=>new Result(), ()=>new Result(ResultState.Fail)).State);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;
using Lib;

namespace Test.Lib
{
    [TestClass]
    public class PrioritySerialQueueTest : SerialQueueTestBase<PrioritySerialQueue>
    {
        protected override PrioritySerialQueue CreateInstance() { return new PrioritySerialQueue(3); }
        #region 附加测试特性
        //在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext) { }

        //在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup() { }

        //在运行每个测试之前，使用 TestInitialize 来运行代码
        [TestInitialize()]
        public void MyTestInitialize()
        {
            Instance.Clear();
        }

        //在每个测试运行完之后，使用 TestCleanup 来运行代码
        //[TestCleanup()]
        //public void MyTestCleanup() { }
        #endregion
        [TestMethod]
        public void TestPrioritySerialQueue()
        {
            Assert.IsFalse(Instance.IsRunning);

            ManualResetEvent mre1 = new ManualResetEvent(false);
            ManualResetEvent mre2 = new ManualResetEvent(false);
            ManualResetEvent mre3 = new ManualResetEvent(false);

            int i, x1, x2, x3;
            mre1.Reset(); mre2.Reset(); mre3.Reset();
            i = x1 = x2 = x3 = 0;
            Instance.Assign(new RunnableAction(() => { x1 = ++i; mre1.Set(); }));
            Instance.Assign(new RunnableAction(() => { mre2.WaitOne(); x2 = ++i; mre3.Set(); }));
            Instance.Run();
            mre1.WaitOne();
            Assert.AreEqual(x1, 1);
            mre2.Set();
            mre3.WaitOne();
            Assert.AreEqual(x2, 2);

            mre1.Reset(); mre2.Reset(); mre3.Reset();
            i = x1 = x2 = x3 = 0;
            Instance.Assign(new RunnableAction(() => { x1 = ++i; mre1.Set(); }));
            Task<int> task = new Task<int>(() => { mre2.WaitOne(); x2 = ++i; mre3.Set(); return x2; });
            Instance.Assign(new RunnableTask(task));
            Instance.Run();
            mre1.WaitOne();
            Assert.AreEqual(x1, 1);
            Assert.AreEqual(x2, 0);
            mre2.Set();
            mre3.WaitOne();
            Assert.AreEqual(x1, 1);
            Assert.AreEqual(x2, 2);

            ManualResetEvent mre4 = new ManualResetEvent(false);
            ManualResetEvent mre5 = new ManualResetEvent(false);
            ManualResetEvent mre6 = new ManualResetEvent(false);
            mre1.Reset(); mre2.Reset(); mre3.Reset(); mre4.Reset(); mre5.Reset(); mre6.Reset();
            i = x1 = x2 = x3 = 0;
            Instance.Assign(new RunnableAction(() => { x1 = ++i; mre1.Set(); mre4.WaitOne(); }), 1);
            Instance.Assign(new RunnableAction(() => { x2 = ++i; mre2.Set(); mre5.WaitOne(); }), 2);
            Instance.Assign(new RunnableAction(() => { x3 = ++i; mre3.Set(); mre6.WaitOne(); }), 0);
            Instance.Run();
            mre3.WaitOne();
            Assert.AreEqual(x1, 0);
            Assert.AreEqual(x2, 0);
            Assert.AreEqual(x3, 1);
            mre6.Set();
            mre1.WaitOne();
            Assert.AreEqual(x1, 2);
            Assert.AreEqual(x2, 0);
            Assert.AreEqual(x3, 1);
            mre4.Set();
            mre2.WaitOne();
            Assert.AreEqual(x1, 2);
            Assert.AreEqual(x2, 3);
            Assert.AreEqual(x3, 1);
            mre5.Set();

            Instance.Assign(default(IRunnable), 0);
            Instance.Assign(new RunnableAction(()=>{}), -1);
            Instance.Assign(new RunnableAction(()=>{}), 100);
        }
        [TestMethod]
        public override void TestIsEmptyAndClear()
        {
            base.TestIsEmptyAndClear();
        }
    }
}
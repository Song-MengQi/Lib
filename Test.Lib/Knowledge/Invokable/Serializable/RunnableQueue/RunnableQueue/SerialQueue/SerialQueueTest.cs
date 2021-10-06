using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace Test.Lib
{
    [TestClass]
    public class SerialQueueTest : SerialQueueTestBase<SerialQueue>
    {
        protected override SerialQueue CreateInstance() { return new SerialQueue(); }
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
        public void TestSerialQueue()
        {
            Assert.IsFalse(Instance.IsRunning);

            ManualResetEvent mre1 = new ManualResetEvent(false);
            ManualResetEvent mre2 = new ManualResetEvent(false);
            ManualResetEvent mre3 = new ManualResetEvent(false);

            int i, x1, x2;
            mre1.Reset(); mre2.Reset(); mre3.Reset();
            i = x1 = x2 = 0;
            Instance.Assign(new RunnableAction(() => { x1 = ++i; mre1.Set(); }));
            Instance.Assign(new RunnableAction(() => { mre2.WaitOne(); x2 = ++i; mre3.Set(); }));
            Instance.Run();
            mre1.WaitOne();
            Assert.AreEqual(x1, 1);
            Assert.AreEqual(x2, 0);
            mre2.Set();
            mre3.WaitOne();
            Assert.AreEqual(x1, 1);
            Assert.AreEqual(x2, 2);

            mre1.Reset(); mre2.Reset(); mre3.Reset();
            i = x1 = x2 = 0;
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
            Assert.AreEqual(task.Result, 2);

            Instance.Assign(default(IRunnable));
        }
        [TestMethod]
        public override void TestIsEmptyAndClear()
        {
            base.TestIsEmptyAndClear();
        }
    }
}
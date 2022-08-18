using Lib.Timer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace Test.Lib.Timer
{
    [TestClass]
    public class TotalTimerTest : TestBase
    {
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
            TotalTimer.UnsetInstance();
            Config.Instance.PeriodDuration = TimeSpan.FromMilliseconds(100);
        }

        //在每个测试运行完之后，使用 TestCleanup 来运行代码
        [TestCleanup()]
        public void MyTestCleanup()
        {
            Config.UnsetInstance();
            TotalTimer.UnsetInstance();
        }
        #endregion
        [TestMethod]
        public void TestOnce()
        {
            int x = 0;
            AutoResetEvent are = new AutoResetEvent(false);
            TotalTimer instance = new TotalTimer();

            instance.RegisterOnce(() => {
                x++;
                are.Set();
            }, 1);
            Assert.AreEqual(x, 0);
            are.WaitOne();
            Assert.AreEqual(x, 1);
            Thread.Sleep(TimeSpan.FromMilliseconds(200));
            Assert.AreEqual(x, 1);

            ulong key = instance.RegisterOnce(() => { x++; }, 1);
            instance.UnRegisterOnce(key);
            Thread.Sleep(TimeSpan.FromMilliseconds(200));
            Assert.AreEqual(x, 1);


            instance.UnRegisterOnce(instance.RegisterOnce(default(Action), 1));

            instance.Dispose();
            are.Dispose();
        }
        [TestMethod]
        public void TestRepeat()
        {
            int x = 0;
            AutoResetEvent are = new AutoResetEvent(false);
            TotalTimer instance = new TotalTimer();

            ulong key = instance.RegisterRepeat(() => {
                x++;
                are.Set();
            }, 1);
            Assert.AreEqual(x, 0);
            are.WaitOne();
            Assert.AreEqual(x, 1);
            are.WaitOne();
            Assert.AreEqual(x, 2);
            instance.UnRegisterRepeat(key);

            Thread.Sleep(TimeSpan.FromMilliseconds(200));
            Assert.AreEqual(x, 2);

            instance.Dispose();
            are.Dispose();
        }
    }
}

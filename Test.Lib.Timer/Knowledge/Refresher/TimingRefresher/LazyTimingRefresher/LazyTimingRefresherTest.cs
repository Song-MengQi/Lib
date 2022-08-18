using Lib.Timer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test.Lib.Timer
{
    [TestClass]
    public class LazyTimingRefresherTest
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
        public void Test()
        {
            int x = 0;
            LazyTimingRefresher<int> lazyTimingRefresher = new LazyTimingRefresher<int>(()=>{
                return x++;
            });

            Assert.AreEqual(lazyTimingRefresher.Get(), 0);
            Assert.AreEqual(lazyTimingRefresher.Get(), 0);
            lazyTimingRefresher.Refresh();
            Assert.AreEqual(lazyTimingRefresher.Get(), 1);
            Assert.AreEqual(lazyTimingRefresher.Get(), 1);
        }
    }
}
using Test.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using Lib.Timer;

namespace Test.Lib.Timer
{
    [TestClass]
    public class TotalTimerTest : TestBase
    {
        [TestMethod]
        public void TestOnce()
        {
            int x = 0;
            AutoResetEvent are = new AutoResetEvent(false);
            Config.Instance.PeriodDuration = TimeSpan.FromMilliseconds(100);
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
        }
        [TestMethod]
        public void TestRepeat()
        {
            int x = 0;
            AutoResetEvent are = new AutoResetEvent(false);
            Config.Instance.PeriodDuration = TimeSpan.FromMilliseconds(100);
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
        }
    }
}

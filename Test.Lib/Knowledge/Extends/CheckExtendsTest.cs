using System;
using System.Threading;
using System.Threading.Tasks;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class CheckExtendsTest : TestBase
    {
        [TestMethod]
        public void Test()
        {
            int x;
            ManualResetEventSlim manualResetEventSlim = default(ManualResetEventSlim);
            bool isRunning = true;
            Task.Run(()=>{
                while (isRunning)
                {
                    ManualResetEventSlimExtends.Set(manualResetEventSlim);
                    Thread.Sleep(10);
                }
            });

            x = 0;
            CheckExtends.CheckWait(() => x > 0, () => ++x);
            x = 0;
            CheckExtends.CheckWait(() => x++ > 0, 1);
            x = 0;
            CheckExtends.CheckWait(() => x++ > 0, 1, default(Action<ManualResetEventSlim>));
            x = 0;
            CheckExtends.CheckWait(() => x++ > 0, 1, slim=>manualResetEventSlim = slim);

            x = 0;
            Assert.IsTrue(CheckExtends.CheckTimeout(() => x > 1, Timeout.Infinite, duration => { ++x; return true; }));
            Assert.IsTrue(CheckExtends.CheckTimeout(() => x > 1, Timeout.Infinite, duration => { ++x; return true; }));
            x = 0;
            Assert.IsTrue(CheckExtends.CheckTimeout(() => x++ > 1, Timeout.Infinite));
            x = 0;
            Assert.IsFalse(CheckExtends.CheckTimeout(() => x > 0, 1, duration => { ++x; return false; }));
            x = 0;
            Assert.IsTrue(CheckExtends.CheckTimeout(() => x++ > 1, Timeout.Infinite, 1));
            x = 0;
            Assert.IsTrue(CheckExtends.CheckTimeout(() => x++ > 1, Timeout.Infinite, 1, default(Action<ManualResetEventSlim>)));
            x = 0;
            Assert.IsTrue(CheckExtends.CheckTimeout(() => x++ > 1, Timeout.Infinite, 1, slim => manualResetEventSlim = slim));
            isRunning = false;
        }
    }
}

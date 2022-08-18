using System.Threading;
using System.Threading.Tasks;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class InvokableWithRunningTest : TestBase
    {
        [TestMethod]
        public void Test()
        {
            IInvokableWithRunning instance = new InvokableWithRunning();
            int x = 0;
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);
            
            Assert.IsFalse(instance.IsRunning);
            
            Task.Run(()=>instance.Invoke(()=>{
                autoResetEvent.Set();
                Thread.Sleep(10);
                ++x;
                autoResetEvent.Set();
            }));

            autoResetEvent.WaitOne();
            Assert.IsTrue(instance.IsRunning);

            autoResetEvent.WaitOne();
            Thread.Sleep(10);
            Assert.IsFalse(instance.IsRunning);
            Assert.AreEqual(x, 1);

            Assert.AreEqual(instance.Invoke(() => ++x), 2);

            autoResetEvent.Dispose();
        }
    }
}
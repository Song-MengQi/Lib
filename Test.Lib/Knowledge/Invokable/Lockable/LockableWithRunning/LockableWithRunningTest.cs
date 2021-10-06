using System.Threading;
using System.Threading.Tasks;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class LockableWithRunningTest : TestBase
    {
        [TestMethod]
        public void Test()
        {
            ILockableWithRunning instance = new LockableWithRunning();
            int x = 0;
            int row = 10, col = 4;
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);

            Assert.IsFalse(instance.IsRunning);

            Task[] tasks = (ArrayExtends.GetArray(row, i => Task.Run(()=>{
                instance.Invoke(()=>{
                    autoResetEvent.Set();
                    int y = x;
                    for (int j = 0; j < col; ++j)
                    {
                        x++;
                        Thread.Sleep(10);
                    }
                    Assert.AreEqual(x, y + col);
                });
            })));
            autoResetEvent.WaitOne();
            Thread.Sleep(10);
            Assert.IsTrue(instance.IsRunning);

            Task.WaitAll(tasks);
            Assert.IsFalse(instance.IsRunning);
            Assert.AreEqual(instance.Invoke(()=>x), row * col);
        }
    }
}
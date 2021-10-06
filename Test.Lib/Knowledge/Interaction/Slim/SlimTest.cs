using System.Threading;
using System.Threading.Tasks;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class SlimTest : TestBase
    {
        [TestMethod]
        public void TestSlim()
        {
            Slim slim = new Slim();

            //创建一个等待者
            ManualResetEventSlim manualResetEventSlim = slim.Add();
            //应该没有等到结果
            Assert.IsFalse(manualResetEventSlim.IsSet);

            //结果来了
            slim.Arrival();
            //等到了
            manualResetEventSlim.Wait();

            //再加一次
            slim.Add(manualResetEventSlim);
            //继续等
            Assert.IsFalse(manualResetEventSlim.IsSet);

            #region NoUse
            ////线程1、2、3分别加入新的等待者
            //Task task1 = Task.Run(()=>{
            //    slim.AddResetWaitRemove();
            //});
            //Task task2 = Task.Run(()=>{
            //    slim.AddResetWaitRemove(10);
            //});
            //Task task3 = Task.Run(()=>{
            //    slim.AddResetWaitRemove(TimeSpan.FromMilliseconds(10));
            //});

            ////Sleep10ms，保证上面三个Task都在等了
            //Thread.Sleep(10);
            ////结果来了
            //slim.Arrival();

            ////都能等到结果
            //task1.Wait();
            //task2.Wait();
            //task3.Wait();
            //manualResetEventSlim.Wait();
            #endregion

            slim.Remove(manualResetEventSlim);

            //销毁
            manualResetEventSlim.Dispose();
            slim.Dispose();
        }
        [TestMethod]
        public void TestCheckWait()
        {
            Slim slim = new Slim();
            Task waitTask;
            int x;

            #region 普通
            //x先=1
            x = 1;
            //等x=2
            waitTask = Task.Run(()=>slim.CheckWait(()=>x==2));
            //Sleep10ms，保证上面Task在等了
            Thread.Sleep(10);
            //它来了
            slim.Arrival(()=>x=2);
            //能等到
            waitTask.Wait();

            //x先=1
            x = 1;
            //等x=2
            waitTask = Task.Run(() => slim.CheckWait(()=>false, () => x == 2));
            waitTask = Task.Run(() => slim.CheckWait(()=>true, () => x == 2));
            //Sleep10ms，保证上面Task在等了
            Thread.Sleep(10);
            //它来了
            slim.Arrival(() => x = 2);
            //能等到
            waitTask.Wait();
            #endregion


            #region Abort
            bool isAborted = false;
            ManualResetEventSlim manualResetEventSlim = default(ManualResetEventSlim);
            //x先=1
            x = 1;
            //等x=2或isAborted
            waitTask = Task.Run(()=>slim.CheckWait(()=>x==2||isAborted, s=>manualResetEventSlim=s));
            //Sleep10ms，保证上面Task在等了
            Thread.Sleep(10);
            //它不来了
            //slim.Arrival(()=>x=2);
            //不等了
            isAborted = true;
            ManualResetEventSlimExtends.Set(manualResetEventSlim);
            //能正常结束
            waitTask.Wait();
            #endregion

            //销毁
            IDisposableExtends.Dispose(manualResetEventSlim);
            slim.Dispose();
        }
        [TestMethod]
        public void TestCheckTimeout()
        {
            Slim slim = new Slim();
            Task<bool> waitTask;
            int x;

            #region 普通
            //x先=1
            x = 1;
            //等x=2
            waitTask = Task.Run(()=>slim.CheckTimeout(()=>x==2, 1000));
            //Sleep10ms，保证上面Task在等了
            Thread.Sleep(10);
            //它来了
            slim.Arrival(()=>x=2);
            //能等到
            Assert.IsTrue(waitTask.Result);

            //x先=1
            x = 1;
            //等x=2
            waitTask = Task.Run(()=>slim.CheckTimeout(()=>false, ()=>x==2, 1000));
            waitTask = Task.Run(()=>slim.CheckTimeout(()=>true, ()=>x==2, 1000));
            //Sleep10ms，保证上面Task在等了
            Thread.Sleep(10);
            //它来了
            slim.Arrival(()=>x=2);
            //能等到
            Assert.IsTrue(waitTask.Result);
            #endregion

            #region Abort
            bool isAborted = false;
            ManualResetEventSlim manualResetEventSlim = default(ManualResetEventSlim);
            //x先=1
            x = 1;
            //等x=2或isAborted，100ms后超时
            waitTask = Task.Run(()=>slim.CheckTimeout(()=>x==2||isAborted, 100, s=>manualResetEventSlim=s));
            //它不来了
            //slim.Arrival(()=>x=2);
            //不等了
            isAborted = true;
            ManualResetEventSlimExtends.Set(manualResetEventSlim);
            //也算等到结果
            Assert.IsTrue(waitTask.Result);
            #endregion

            //销毁
            IDisposableExtends.Dispose(manualResetEventSlim);
            slim.Dispose();
        }
    }
}
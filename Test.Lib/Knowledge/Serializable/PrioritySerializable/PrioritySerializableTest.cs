using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;
using Lib;
using System;

namespace Test.Lib
{
    [TestClass]
    public class PrioritySerializableTest : TestBase
    {
        [TestMethod]
        public void TestSerializable()
        {
            PrioritySerializable instance = new PrioritySerializable(4);
            Assert.IsFalse(instance.IsRunning);
            ManualResetEvent mre = new ManualResetEvent(false);

            int i, x1, x2, x3, x4;
            mre.Reset();
            i = x1 = x2 = x3 = x4 = 0;
            instance.InvokeBackground(() => { mre.WaitOne(); i++; }, 0);
            Task<int> task2 = instance.InvokeAsync<int>(() => { return x2 = i++; }, 2);
            Task task1 = instance.InvokeAsync(() => { x1 = i++; }, 1);
            mre.Set();//已经在执行0了
            x4 = instance.Invoke<int>(() => { return x3 = i++; }, 3);
            
            Assert.AreEqual(i, 4);
            Assert.AreEqual(x1, 1);
            Assert.AreEqual(x2, 2);
            Assert.AreEqual(x3, 3);
            Assert.AreEqual(x4, 3);
            Assert.AreEqual(task2.Result, 2);


            instance.InvokeBackground(default(Action));
            instance.InvokeAsync(default(Action));
            instance.InvokeAsync(default(Func<int>));
            instance.Invoke(default(Action));
            instance.Invoke(default(Func<int>));
            instance.Invoke(()=>{});
        }
        [TestMethod]
        public void TestIsEmptyAndClear()
        {
            PrioritySerializable instance = new PrioritySerializable(2);

            ManualResetEvent mre1 = new ManualResetEvent(false);
            ManualResetEvent mre2 = new ManualResetEvent(false);
            ManualResetEvent mre3 = new ManualResetEvent(false);

            int i = 0;
            mre1.Reset();mre2.Reset();mre3.Reset();
            i = 0;
            Assert.IsTrue(instance.IsEmpty);
            instance.InvokeBackground(() => {
                mre1.Set();
                mre2.WaitOne();
                ++i;
                mre3.Set();
            }, 1);
            mre1.WaitOne();//等开始执行
            instance.InvokeBackground(() => i += 2, 0);
            Assert.IsFalse(instance.IsEmpty);
            instance.Clear();
            Assert.IsFalse(instance.IsEmpty);
            mre2.Set();//继续执行
            mre3.WaitOne();//等执行完
            
            Thread.Sleep(100);
            Assert.IsTrue(instance.IsEmpty);

            Assert.AreEqual(1, i);//自动执行了第一个
        }
    }
}
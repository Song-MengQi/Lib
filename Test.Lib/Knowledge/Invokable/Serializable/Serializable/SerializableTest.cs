using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test.Lib
{
    [TestClass]
    public class SerializableTest : TestBase
    {
        [TestMethod]
        public void TestSerializable()
        {
            Serializable instance = new Serializable();
            Assert.IsFalse(instance.IsRunning);

            int i, x1, x2, x3, x4;
            i = x1 = x2 = x3 = 0;
            instance.InvokeBackground(() => { i++;});
            var ttt = instance.InvokeAsync(() => { x1 = i++; });
            Task<int> task = instance.InvokeAsync<int>(() => { return x2 = i++; });
            x4 = instance.Invoke<int>(() => { return x3 = i++; });

            Assert.AreEqual(i, 4);
            Assert.AreEqual(x1, 1);
            Assert.AreEqual(x2, 2);
            Assert.AreEqual(x3, 3);

            Assert.AreEqual(task.Result, 2);
            Assert.AreEqual(x4, 3);

            instance.InvokeBackground(default(Action));
            instance.InvokeAsync(default(Action));
            instance.InvokeAsync(default(Func<int>));
            instance.Invoke(default(Action));
            instance.Invoke(default(Func<int>));
            instance.Invoke(() => { });
        }
        [TestMethod]
        public void TestIsEmptyAndClear()
        {
            Serializable instance = new Serializable();

            ManualResetEvent mre1 = new ManualResetEvent(false);
            ManualResetEvent mre2 = new ManualResetEvent(false);
            ManualResetEvent mre3 = new ManualResetEvent(false);

            int i = 0;
            mre1.Reset(); mre2.Reset(); mre3.Reset();
            i = 0;
            Assert.IsTrue(instance.IsEmpty);
            instance.InvokeBackground(() => {
                mre1.Set();
                mre2.WaitOne();
                ++i;
                mre3.Set();
            });
            instance.InvokeBackground(() => i+=2);
            mre1.WaitOne();//等开始执行
            Assert.IsFalse(instance.IsEmpty);
            instance.Clear();
            Assert.IsFalse(instance.IsEmpty);//虽然没有了正在排队的，但是还有正在执行的
            mre2.Set();//继续执行
            mre3.WaitOne();//等执行完

            Thread.Sleep(100);
            Assert.IsTrue(instance.IsEmpty);

            Assert.AreEqual(1, i);//自动执行了一个
        }
    }
}
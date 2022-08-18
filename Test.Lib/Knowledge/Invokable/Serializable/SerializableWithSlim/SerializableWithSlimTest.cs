using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test.Lib
{
    [TestClass]
    public class SerializableWithSlimTest : TestBase
    {
        [TestMethod]
        public void Test()
        {
            SerializableWithSlim instance = new SerializableWithSlim();
            Assert.IsFalse(instance.IsRunning);
            Assert.IsTrue(instance.IsEmpty);

            int i, x1, x2, x3, x4;
            i = x1 = x2 = x3 = 0;
            instance.InvokeBackground(() => { i++; });
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
            instance.Invoke(()=>{});


            instance.Pause();
            instance.Continue();
            instance.WaitForRun();
            instance.Clear();
            instance.Dispose();
        }
    }
}

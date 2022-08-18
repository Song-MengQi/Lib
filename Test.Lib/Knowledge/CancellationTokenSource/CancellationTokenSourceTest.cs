using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CTS = Lib.CancellationTokenSource;

namespace Test.Lib
{
    [TestClass]
    public class CancellationTokenSourceTest
    {
        [TestMethod]
        public void Test()
        {
            CTS cts = new CTS();
            TimeSpan longTime = TimeSpan.FromSeconds(5d);
            TimeSpan shortTime = TimeSpan.FromSeconds(0.1d);
            Task task = Task.Run(()=>{
                Thread.Sleep(longTime);
            });
            Task.Run(()=>{
                Thread.Sleep(shortTime);
                cts.CancelAndReset();
            });

            Stopwatch stopwatch = Stopwatch.StartNew();
            try { task.Wait(cts.Token); }
            catch (OperationCanceledException) { }
            //catch (TaskCanceledException) { }
            
            Assert.IsTrue(stopwatch.Elapsed < longTime);

            cts.Dispose();
        }
    }
}
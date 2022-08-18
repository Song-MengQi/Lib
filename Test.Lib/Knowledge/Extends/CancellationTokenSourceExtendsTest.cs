using System;
using System.Threading;
using System.Threading.Tasks;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class CancellationTokenSourceExtendsTest
    {
        [TestMethod]
        public void Test()
        {
            using (ManualResetEventSlim slim = new ManualResetEventSlim(false),
                slim2 = new ManualResetEventSlim(false))
            {
                slim.Reset();
                slim2.Reset();
                CancellationTokenSourceExtends.Invoke(1, ct=>{
                    ct.Register(()=>{ slim2.Set(); });
                    try { slim.Wait(ct); }//应该能够正常等完
                    catch (OperationCanceledException) { }//并且捕捉到这个异常
                });
                slim2.Wait();

                slim.Reset();
                Assert.AreEqual(CancellationTokenSourceExtends.Invoke(0, ct=>{
                    try { slim.Wait(ct); }//应该能够正常等完
                    catch (OperationCanceledException) { return 2; }//并且捕捉到这个异常
                    return 1;
                }), 2);


                CancellationTokenSourceExtends.InvokeAsync(0, ct=>Task.Run(()=>{
                    try { slim.Wait(ct); }//应该能够正常等完
                    catch (OperationCanceledException) { }//并且捕捉到这个异常
                })).Wait();
            }
        }
    }
}
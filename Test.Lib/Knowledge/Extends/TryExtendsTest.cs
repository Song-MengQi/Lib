using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test.Lib
{
    [TestClass]
    public class TryExtendsTest : TestBase
    {
        [TestMethod]
        public void TestTry()
        {
            int x = 0;
            int y = 0;
            //到第三次才会成功
            Action action = () => {
                if (++x < 3) throw new Exception();
            };
            Action<Exception> catchAction = exception => ++y;

            x = y = 0;
            //试1次会失败
            Assert.IsFalse(TryExtends.Try(action, 1));
            Assert.AreEqual(x, 1);

            x = y = 0;
            //试2次都失败
            Assert.IsFalse(TryExtends.Try(action, new TryOptions {
                Times = 2,
                CatchAction = catchAction
            }));
            Assert.AreEqual(x, 2);
            Assert.AreEqual(y, 2);

            x = y = 0;
            //试3次正好成功
            Assert.IsTrue(TryExtends.Try(action, new TryOptions {
                Times = 3,
                CatchAction = catchAction
            }));
            Assert.AreEqual(x, 3);
            Assert.AreEqual(y, 2);

            x = y = 0;
            //试再多次也只执行3次
            Assert.IsTrue(TryExtends.Try(action, new TryOptions {
                Times = 100,
                CatchAction = catchAction
            }));
            Assert.AreEqual(x, 3);
            Assert.AreEqual(y, 2);


            x = 0;
            //对于一次就能成功的直接过
            Assert.IsTrue(TryExtends.Try(()=>{ ++x; }, 1));
            Assert.AreEqual(x, 1);


            x = 0;
            //无限次重试，在首次成功后通过
            Assert.IsTrue(TryExtends.Try(()=>{ ++x; }, -1));
            Assert.AreEqual(x, 1);


            x = y = 0;
            Assert.IsTrue(TryExtends.Try(()=>++x, out y, 1));
            Assert.AreEqual(x, 1);
            Assert.AreEqual(y, 1);


            x = y = 0;
            Assert.IsTrue(TryExtends.Try(()=>++x, out y));
            Assert.AreEqual(x, 1);
            Assert.AreEqual(y, 1);

            //这个执行不完
            //TryExtends.Try(()=>{
            //    throw new Exception();
            //}, new TryOptions {
            //    Times = -1,
            //    CatchAction = exception => {
            //        System.Console.WriteLine(1);
            //        System.Threading.Thread.Sleep(1000);
            //    }
            //});
        }
        [TestMethod]
        public void TestInvoke()
        {
            int x = 0;
            TryExtends.Invoke(()=>{ x = 1; }, 1);
            Assert.AreEqual(x, 1);

            Assert.AreEqual(TryExtends.Invoke(() => 1, 1), 1);
            Assert.AreEqual(TryExtends.Invoke(
                ()=>{
                    throw new Exception();
                },
                new TryOptions<int> {
                    Times = 1,
                    DefaultFunc = ()=>2
                }), 2);
        }
    }
}

using Lib.Timer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace Test.Lib.Timer
{
    [TestClass]
    public class TotalTimerExtendsTest
    {
        #region 附加测试特性
        //在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext) { }

        //在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup() { }

        //在运行每个测试之前，使用 TestInitialize 来运行代码
        [TestInitialize()]
        public void MyTestInitialize()
        {
            TotalTimer.UnsetInstance();
            Config.Instance.PeriodDuration = TimeSpan.FromMilliseconds(100);
        }

        //在每个测试运行完之后，使用 TestCleanup 来运行代码
        [TestCleanup()]
        public void MyTestCleanup()
        {
            Config.UnsetInstance();
            TotalTimer.UnsetInstance();
        }
        #endregion
        [TestMethod]
        public void Test()
        {
            Action action = () => { };
            ulong key = 0ul;

            TotalTimerExtends.UnRegisterRepeat(ref key);
            TotalTimerExtends.RegisterRepeat(ref key, action, 1);
            TotalTimerExtends.RegisterRepeat(ref key, action, 1);
            Assert.AreNotEqual(key, 0ul);
            TotalTimerExtends.UnRegisterRepeat(ref key);
            Assert.AreEqual(key, 0ul);

            TotalTimerExtends.UnRegisterOnce(ref key);
            TotalTimerExtends.RegisterOnce(ref key, action, 1);
            TotalTimerExtends.RegisterOnce(ref key, action, 1);
            Assert.AreNotEqual(key, 0ul);
            TotalTimerExtends.UnRegisterOnce(ref key);
            Assert.AreEqual(key, 0ul);
        }
        [TestMethod]
        public void TestWhen()
        {
            ulong key = 0ul;
            AutoResetEvent are = new AutoResetEvent(false);
            bool flag = true;
            Func<bool> boolFunc = ()=>flag=!flag;

            TotalTimerExtends.RegisterWhen(ref key, ()=>{
                are.Set();
            }, 1, now=>boolFunc());
            are.WaitOne();
            TotalTimerExtends.UnRegisterRepeat(ref key);

            //没用了
            //TotalTimerExtends.RegisterWhen(ref key, ()=>{
            //    are.Set();
            //}, 1, new TimingOptions {
            //    Second = DateTime.Now.AddSeconds(0.2).Second
            //});
            //are.WaitOne();
            //TotalTimerExtends.UnRegisterRepeat(ref key);

            TotalTimerExtends.RegisterWhenLast(ref key, ()=>{
                are.Set();
            }, 1, last=>boolFunc());
            are.WaitOne();
            TotalTimerExtends.UnRegisterRepeat(ref key);

            TotalTimerExtends.RegisterWhen(ref key, ()=>{
                are.Set();
            }, 1, (last, now)=>boolFunc());
            are.WaitOne();
            TotalTimerExtends.UnRegisterRepeat(ref key);

            TotalTimerExtends.RegisterWhen(ref key, ()=>{
                are.Set();
            }, new TimingOptions());
            are.WaitOne();
            TotalTimerExtends.UnRegisterRepeat(ref key);

            ////验证coolingTime保证不会重入
            //int i = 0;
            //TotalTimerExtends.RegisterWhen(ref key, ()=>{
            //    Console.WriteLine(DateTime.Now.ToString());
            //    if (i++==2) are.Set();
            //}, new TimingOptions {
            //    Second = 1
            //});
            //are.WaitOne();
            //TotalTimerExtends.UnRegisterRepeat(ref key);
        }
    }
}
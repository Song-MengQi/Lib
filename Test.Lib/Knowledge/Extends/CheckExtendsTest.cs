using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test.Lib
{
    [TestClass]
    public class CheckExtendsTest : TestBase
    {
        private enum TestEnum
        {
            A,B
        }
        [TestMethod]
        public void TestCheck()
        {
            Assert.AreEqual(CheckExtends.Check(true, 1), 0);
            Assert.AreEqual(CheckExtends.Check(false, 1), 1);

            Assert.AreEqual(CheckExtends.CheckNot(false, 1), 0);
            Assert.AreEqual(CheckExtends.CheckNot(true, 1), 1);

            Assert.AreEqual(CheckExtends.Check(new object(), 1), 0);
            Assert.AreEqual(CheckExtends.Check(default(object), 1), 1);

            Assert.AreEqual(CheckExtends.CheckObject(new object(), 1), 0);
            Assert.AreEqual(CheckExtends.CheckObject(default(object), 1), 1);

            Assert.AreEqual(CheckExtends.CheckObjects(new object[] { new object() }, 1), 0);
            Assert.AreEqual(CheckExtends.CheckObjects(default(object[]), 1), 1);
            Assert.AreEqual(CheckExtends.CheckObjects(new object[] { default(object) }, 1), 1);

            Assert.AreEqual(CheckExtends.CheckString(default(string), str=>true, 1), 0);
            Assert.AreEqual(CheckExtends.CheckString(default(string), str=>false, 1), 1);

            Assert.AreEqual(CheckExtends.CheckStrings(new string[] { default(string) }, str => true, 1), 0);
            Assert.AreEqual(CheckExtends.CheckStrings(new string[] { default(string) }, str => false, 1), 1);
            Assert.AreEqual(CheckExtends.CheckStrings(default(string[]), str => true, 1), 1);

            Assert.AreEqual(CheckExtends.CheckStrings(string.Empty, str => true, 1), 0);
            Assert.AreEqual(CheckExtends.CheckStrings("1,2", str => true, 1), 0);
            Assert.AreEqual(CheckExtends.CheckStrings(default(string), str => true, 1), 1);
            Assert.AreEqual(CheckExtends.CheckStrings("1,2", str => false, 1), 1);

            Assert.AreEqual(CheckExtends.CheckEnum<TestEnum>("0", 1), 0);
            Assert.AreEqual(CheckExtends.CheckEnum<TestEnum>("10000", 1), 1);
        }

        [TestMethod]
        public void TestWaitAndTimeout()
        {
            if (PrincipalExtends.InAdministrator()) Assert.AreEqual(CheckExtends.CheckNoRight(), ResultState.Success);
            else Assert.AreEqual(CheckExtends.CheckNoRight(), ResultState.NoRight);

            int x;
            ManualResetEventSlim manualResetEventSlim = default(ManualResetEventSlim);
            bool isRunning = true;
            Task.Run(()=>{
                while (isRunning)
                {
                    ManualResetEventSlimExtends.Set(manualResetEventSlim);
                    Thread.Sleep(10);
                }
            });

            x = 0;
            CheckExtends.CheckWait(() => x > 0, () => ++x);
            x = 0;
            CheckExtends.CheckWait(() => x++ > 0, 1);
            x = 0;
            CheckExtends.CheckWait(() => x++ > 0, 1, default(Action<ManualResetEventSlim>));
            x = 0;
            CheckExtends.CheckWait(() => x++ > 0, 1, slim=>manualResetEventSlim = slim);

            x = 0;
            Assert.IsTrue(CheckExtends.CheckTimeout(() => x > 1, Timeout.Infinite, duration => { ++x; return true; }));
            Assert.IsTrue(CheckExtends.CheckTimeout(() => x > 1, Timeout.Infinite, duration => { ++x; return true; }));
            x = 0;
            Assert.IsTrue(CheckExtends.CheckTimeout(() => x++ > 1, Timeout.Infinite));
            x = 0;
            Assert.IsFalse(CheckExtends.CheckTimeout(() => x > 0, 1, duration => { ++x; return false; }));
            x = 0;
            Assert.IsTrue(CheckExtends.CheckTimeout(() => x++ > 1, Timeout.Infinite, 1));
            x = 0;
            Assert.IsTrue(CheckExtends.CheckTimeout(() => x++ > 1, Timeout.Infinite, 1, default(Action<ManualResetEventSlim>)));
            x = 0;
            Assert.IsTrue(CheckExtends.CheckTimeout(() => x++ > 1, Timeout.Infinite, 1, slim => manualResetEventSlim = slim));
            isRunning = false;
        }
    }
}

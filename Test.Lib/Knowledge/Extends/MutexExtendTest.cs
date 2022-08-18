using System;
using System.Threading;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class MutexExtendTest
    {
        [TestMethod]
        public void Test()
        {
            Mutex mutex = new Mutex(false, GetType().FullName);

            Assert.IsTrue(mutex.WaitOneOrAbandoned());
            Assert.IsTrue(mutex.WaitOneOrAbandoned(1000));
            Assert.IsTrue(mutex.WaitOneOrAbandoned(TimeSpan.FromSeconds(1)));

            mutex.ReleaseMutex();

            Assert.IsTrue(mutex.WaitOneOrAbandoned());
        }
    }
}
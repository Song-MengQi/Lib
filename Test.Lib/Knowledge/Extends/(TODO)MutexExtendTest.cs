//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Threading;
//using System.Threading.Tasks;
//using Lib;
//using System;

//namespace Test.Lib
//{
//    [TestClass]
//    public class MutexExtendTest : TestBase
//    {
//        private void TestWaitOne(Func<Mutex, bool> func)
//        {
//            string mutexName = "MutexName";
//            Mutex mutex = new Mutex(false, mutexName);
//            mutex.WaitOne();
//            Task<bool> task1 = Task.Run(()=>func(new Mutex(false, mutexName)));
//            mutex.ReleaseMutex();
//            Assert.IsTrue(task1.Result);
//        }
//        private void TestAbandoned(Func<Mutex, bool> func)
//        {
//            string mutexName = "MutexName";
//            Mutex mutex = new Mutex(false, mutexName);
//            mutex.WaitOne();
//            Task<bool> task1 = Task.Run(()=>func(new Mutex(false, mutexName)));
//            mutex.Dispose();
//            GC.Collect();
//            //mutex.Close();
//            Assert.IsTrue(task1.Result);
//        }
//        [TestMethod]
//        public void Test()
//        {
//            TestWaitOne(mutex=>mutex.WaitOneOrAbandoned());
//            TestWaitOne(mutex=>mutex.WaitOneOrAbandoned(-1));
//            TestWaitOne(mutex=>mutex.WaitOneOrAbandoned(TimeSpan.FromSeconds(1d)));
//            //TestAbandoned(mutex=>mutex.WaitOneOrAbandoned());
//            //TestAbandoned(mutex=>mutex.WaitOneOrAbandoned(-1));
//            //TestAbandoned(mutex=>mutex.WaitOneOrAbandoned(TimeSpan.FromSeconds(1d)));
//        }
//    }
//}

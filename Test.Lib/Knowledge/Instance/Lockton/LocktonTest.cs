using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class LocktonTest : TestBase
    {
        private void Test<T, TT>(T t)
            where TT : T, new()
        {
            Lockton<T> lockton = new Lockton<T>();

            Assert.IsFalse(lockton.Exist);

            lockton.Instance = t;
            Assert.AreEqual(lockton.Instance, t);
            Assert.IsTrue(lockton.Exist);

            lockton.Instance = default(T);
            Assert.AreEqual(lockton.Instance, default(T));
            Assert.IsFalse(lockton.Exist);



            lockton.SetInstance(()=>t);
            Assert.AreEqual(lockton.Instance, t);
            Assert.AreEqual(lockton.GetInstance(()=>default(T)), t);
            Assert.IsTrue(lockton.Exist);

            lockton.SetInstance(()=>default(T));
            Assert.AreEqual(lockton.Instance, default(T));
            Assert.IsFalse(lockton.Exist);
            Assert.AreEqual(lockton.GetInstance(() => t), t);
            Assert.IsTrue(lockton.Exist);


            lockton.UnsetInstance();
            Assert.IsFalse(lockton.Exist);

            lockton.SetInstance<TT>();
            Assert.IsTrue(lockton.Exist);

            lockton.UnsetInstance();
            Assert.IsFalse(lockton.Exist);

            Assert.AreNotEqual(lockton.GetInstance<TT>(), default(T));
            Assert.IsTrue(lockton.Exist);

            lockton.UnsetInstance();
            Assert.IsFalse(lockton.Exist);
        }
        private class LocktonTestClassA
        {
        }
        private class LocktonTestClassB : LocktonTestClassA
        {
        }
        private interface ILocktonTestStruct
        {
        }
        private struct LocktonTestStruct : ILocktonTestStruct
        {
        }
        [TestMethod]
        public void Test()
        {
            Test<LocktonTestClassA, LocktonTestClassB>(new LocktonTestClassA());
            Test<ILocktonTestStruct, LocktonTestStruct>(new LocktonTestStruct());
        }
    }
}
using System;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class ObjectExtendTest
    {
        public class TestClass
        {
            public int A()
            {
                return 1;
            }
            public int A<T>()
            {
                return 2;
            }
            public T A<T>(T t)
            {
                return t;
            }
        }
        [TestMethod]
        public void TestInvoke()
        {
            TestClass testClass = new TestClass();
            Assert.AreEqual(1, testClass.InvokeMethod("A"));
            Assert.AreEqual(2, testClass.InvokeGenericMethod("A", typeof(int)));
            Assert.AreEqual(3, testClass.InvokeGenericMethod("A", new Type[] { typeof(int) }, new object[] { 3 }));
        }
    }
}

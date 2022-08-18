using System;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class TypeExtendTest : TestBase
    {
        private class TestSingleton
        {
            public string Key { get { return IoCManager<TestSingleton>.GetKey(this); } }

            public static TestSingleton Instance
            {
                get { return IoC<TestSingleton>.GetInstance<TestSingleton>(); }
                set { IoC<TestSingleton>.Instance = value; }
            }
            public static void UnsetInstance() { IoC<TestSingleton>.UnsetInstance(); }
            public static bool Exist() { return IoC<TestSingleton>.Exist; }

            public static TestSingleton GetInstance(string key) { return IoCManager<TestSingleton>.GetInstance(key, ()=>{
                PathManager.DirectoryChangedAction += () => UnsetInstance(key);
                return new TestSingleton();
            }); }
            public static void SetInstance(string key, TestSingleton value) { IoCManager<TestSingleton>.SetInstance(key, value); }
            public static void UnsetInstance(string key) { IoCManager<TestSingleton>.UnsetInstance(key); }
            public static bool Exist(string key) { return IoCManager<TestSingleton>.Exist(key); }


            public static void Test<T>() { }
            public static void Test<T>(T t) { }
        }

        [TestMethod]
        public void Test()
        {
            Type type = typeof(TestSingleton);
            TestSingleton value = new TestSingleton();


            Assert.IsFalse(type.Exist());
            Assert.IsNotNull(type.GetInstance<TestSingleton>());
            Assert.IsNotNull(type.GetInstance());
            Assert.IsTrue(type.Exist());

            type.SetInstance(value);
            Assert.AreEqual(type.GetInstance(), value);

            type.UnsetInstance();
            Assert.IsFalse(type.Exist());


            string key = "key";
            Assert.IsFalse(type.Exist(key));
            Assert.IsNotNull(type.GetInstance<TestSingleton>(key));
            Assert.IsNotNull(type.GetInstance(key));
            Assert.IsTrue(type.Exist(key));

            type.SetInstance(key, value);
            Assert.AreEqual(type.GetInstance(key), value);

            type.UnsetInstance(key);
            Assert.IsFalse(type.Exist(key));



            type.InvokeGenericMethod("Test", typeof(int));
            //type.InvokeGenericMethod("Test", typeof(int), 123);
            type.InvokeGenericMethod("Test", new Type[] { typeof(int) }, 123);
        }
    }
    [TestClass]
    public class TypeExtend2Test : TestBase
    {
        private class TestSingleton
        {
            public static TestSingleton GetInstance() { return IoC<TestSingleton>.GetInstance<TestSingleton>(); }
            public static void SetInstance(TestSingleton value) { IoC<TestSingleton>.Instance = value; }
            public static void UnsetInstance() { IoC<TestSingleton>.UnsetInstance(); }
            public static bool Exist() { return IoC<TestSingleton>.Exist; }
        }
        [TestMethod]
        public void Test()
        {
            Type type = typeof(TestSingleton);
            TestSingleton value = new TestSingleton();


            Assert.IsFalse(type.Exist());
            Assert.IsNotNull(type.GetInstance());
            Assert.IsTrue(type.Exist());

            type.SetInstance(value);
            Assert.AreEqual(type.GetInstance(), value);

            type.UnsetInstance();
            Assert.IsFalse(type.Exist());
        }
    }
}

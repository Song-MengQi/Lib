using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class SingletonBaseTest : TestBase
    {
        private class TestASingleton : SingletonBase<TestASingleton>
        {
            public int X = 1;
        }
        private class TestBSingleton : SingletonBase<TestBSingleton>
        {
            public int X = 2;
        }
        private interface ITestSingleton
        {
            int GetX();
        }
        private class TestCSingleton : SingletonBase<TestCSingleton, ITestSingleton>, ITestSingleton
        {
            public int GetX() { return 3; }
        }
        private class TestDSingleton : SingletonBase<TestDSingleton, ITestSingleton>, ITestSingleton
        {
            public int GetX() { return 4; }
        }
        [TestMethod]
        public void Test()
        {
            Assert.IsFalse(TestASingleton.Exist);
            Assert.IsFalse(TestBSingleton.Exist);
            Assert.IsFalse(TestCSingleton.Exist);
            Assert.IsFalse(TestDSingleton.Exist);

            Assert.AreEqual(1, TestASingleton.Instance.X);
            Assert.AreEqual(2, TestBSingleton.Instance.X);
            Assert.AreEqual(3, TestCSingleton.Instance.GetX());
            Assert.AreEqual(4, TestDSingleton.Instance.GetX());

            Assert.IsTrue(TestASingleton.Exist);
            Assert.IsTrue(TestBSingleton.Exist);
            Assert.IsTrue(TestCSingleton.Exist);
            Assert.IsTrue(TestDSingleton.Exist);

            TestASingleton.Instance = TestASingleton.Instance;

            TestCSingleton.Instance = TestDSingleton.Instance;
            Assert.AreEqual(4, TestCSingleton.Instance.GetX());

            TestASingleton.UnsetInstance();
            TestBSingleton.UnsetInstance();
            TestCSingleton.UnsetInstance();
            TestDSingleton.UnsetInstance();

            Assert.IsFalse(TestASingleton.Exist);
            Assert.IsFalse(TestBSingleton.Exist);
            Assert.IsFalse(TestCSingleton.Exist);
            Assert.IsFalse(TestDSingleton.Exist);




            Assert.AreEqual(100, TestASingleton.GetInstance(()=>new TestASingleton{
                X = 100
            }).X);
            TestASingleton.SetInstance(()=>new TestASingleton{
                X = 200
            });
            Assert.AreEqual(200, TestASingleton.Instance.X);

            Assert.AreEqual(4, TestCSingleton.GetInstance(()=>new TestDSingleton()).GetX());
            TestCSingleton.SetInstance(()=>new TestCSingleton());
            Assert.AreEqual(3, TestCSingleton.Instance.GetX());

            TestASingleton.UnsetInstance();
            TestCSingleton.UnsetInstance();

            Assert.IsFalse(TestASingleton.Exist);
            Assert.IsFalse(TestCSingleton.Exist);
        }
    }
}

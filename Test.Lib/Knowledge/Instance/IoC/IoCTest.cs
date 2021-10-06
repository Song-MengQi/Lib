using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class IoCTest : TestBase
    {
        private interface ITestIoC
        {
        }
        private class TestIoC : ITestIoC
        {
            public TestIoC() { }
        }

        [TestMethod]
        public void Test()
        {
            ITestIoC t = new TestIoC();

            Assert.IsFalse(IoC<ITestIoC>.Exist);
            Assert.AreEqual(IoC<ITestIoC>.Instance, default(ITestIoC));

            IoC<ITestIoC>.Instance = t;
            Assert.IsTrue(IoC<ITestIoC>.Exist);
            Assert.AreEqual(IoC<ITestIoC>.Instance, t);

            IoC<ITestIoC>.UnsetInstance();
            Assert.AreEqual(IoC<ITestIoC>.Instance, default(ITestIoC));

            Assert.AreEqual(IoC<ITestIoC>.GetInstance(() => t), t);
            IoC<ITestIoC>.UnsetInstance();

            IoC<ITestIoC>.SetInstance(()=>t);
            Assert.AreEqual(IoC<ITestIoC>.Instance, t);
            IoC<ITestIoC>.UnsetInstance();

            IoC<ITestIoC>.SetInstance<TestIoC>();
            Assert.AreNotEqual(IoC<ITestIoC>.Instance, default(ITestIoC));
            IoC<ITestIoC>.UnsetInstance();

            Assert.AreNotEqual(IoC<ITestIoC>.GetInstance<TestIoC>(), default(ITestIoC));
            IoC<ITestIoC>.UnsetInstance();
        }
    }
}

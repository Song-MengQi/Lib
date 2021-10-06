using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    public interface IIoCManagerTestClass
    {
    }
    public class IoCManagerTestClass : IIoCManagerTestClass
    {
        public IoCManagerTestClass() { }
    }

    [TestClass]
    public class IoCManagerTest : TestBase
    {
        private readonly IIoCManagerTestClass t1;
        private readonly IIoCManagerTestClass t2;
        private string key1;
        private string key2;
        private string defaultKey;
        public IoCManagerTest() : base()
        {
            t1 = new IoCManagerTestClass();
            t2 = new IoCManagerTestClass();
            key1 = "1";
            key2 = "2";
            defaultKey = typeof(IIoCManagerTestClass).GetHashCode().ToString();
        }
        #region 附加测试特性
        //在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext) { }

        //在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup() { }

        //在运行每个测试之前，使用 TestInitialize 来运行代码
        //[TestInitialize()]
        //public void MyTestInitialize() { }

        //在每个测试运行完之后，使用 TestCleanup 来运行代码
        [TestCleanup()]
        public void MyTestCleanup()
        {
            IoCManager<IIoCManagerTestClass>.UnsetInstance(key1);
            IoCManager<IIoCManagerTestClass>.UnsetInstance(key2);
            IoCManager<IIoCManagerTestClass>.UnsetInstance(defaultKey);
            IoCManager<IIoCManagerTestClass>.UnsetInstance();
        }
        #endregion
        [TestMethod]
        public void TestIoCManager()
        {
            #region Key
            Assert.IsFalse(IoCManager<IIoCManagerTestClass>.Exist(key1));
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(key1), default(IIoCManagerTestClass));

            IoCManager<IIoCManagerTestClass>.SetInstance(key1, t1);
            Assert.IsTrue(IoCManager<IIoCManagerTestClass>.Exist(key1));
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(key1), t1);
            
            IoCManager<IIoCManagerTestClass>.SetInstance(key1, default(IIoCManagerTestClass));
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(key1), default(IIoCManagerTestClass));

            IoCManager<IIoCManagerTestClass>.SetInstance(key1, t1);
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(key1), t1);

            IoCManager<IIoCManagerTestClass>.UnsetInstance(key1);
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(key1), default(IIoCManagerTestClass));

            IoCManager<IIoCManagerTestClass>.SetInstance(key1, ()=>t1);
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(key1), t1);

            IoCManager<IIoCManagerTestClass>.UnsetInstance(key1);
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(key1), default(IIoCManagerTestClass));
            #endregion

            #region DefaultKey
            Assert.IsFalse(IoCManager<IIoCManagerTestClass>.Exist());
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(), default(IIoCManagerTestClass));

            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(() => t1), t1);
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(() => t2), t1);
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(), t1);
            Assert.IsTrue(IoCManager<IIoCManagerTestClass>.Exist());

            IoCManager<IIoCManagerTestClass>.SetInstance(default(IIoCManagerTestClass));
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(), default(IIoCManagerTestClass));

            IoCManager<IIoCManagerTestClass>.SetInstance(t1);
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(), t1);

            IoCManager<IIoCManagerTestClass>.SetInstance(()=>t2);
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(), t2);

            IoCManager<IIoCManagerTestClass>.UnsetInstance();
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(), default(IIoCManagerTestClass));


            IoCManager<IIoCManagerTestClass>.UnsetInstance();



            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(defaultKey), default(IIoCManagerTestClass));
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(defaultKey, () => t1), t1);
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(defaultKey), t1);

            IoCManager<IIoCManagerTestClass>.SetInstance(defaultKey, default(IIoCManagerTestClass));
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(defaultKey), default(IIoCManagerTestClass));

            IoCManager<IIoCManagerTestClass>.SetInstance(defaultKey, t1);
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(defaultKey), t1);

            IoCManager<IIoCManagerTestClass>.SetInstance(defaultKey, ()=>t2);
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(defaultKey), t2);

            IoCManager<IIoCManagerTestClass>.UnsetInstance(defaultKey);
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(defaultKey), default(IIoCManagerTestClass));
            #endregion

            #region Coustom
            IIoCManagerTestClass t = IoCManager<IIoCManagerTestClass>.GetInstance(key1, () => new IoCManagerTestClass());
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(key1, () => new IoCManagerTestClass()), t);
            Assert.AreNotEqual(IoCManager<IIoCManagerTestClass>.GetInstance(key2, () => new IoCManagerTestClass()), t);

            IoCManager<IIoCManagerTestClass>.SetInstance(key2, t);
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(key2, () => new IoCManagerTestClass()), t);
            IoCManager<IIoCManagerTestClass>.SetInstance(key2, () => new IoCManagerTestClass());
            Assert.AreNotEqual(IoCManager<IIoCManagerTestClass>.GetInstance(key2), t);

            IoCManager<IIoCManagerTestClass>.UnsetInstance(key1);
            IoCManager<IIoCManagerTestClass>.UnsetInstance(key2);
            #endregion
        }
        [TestMethod]
        public void TestNPCIoCManager()
        {
            #region Key
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(key1), default(IIoCManagerTestClass));

            IoCManager<IIoCManagerTestClass>.SetInstance<IoCManagerTestClass>(key1);
            Assert.AreNotEqual(IoCManager<IIoCManagerTestClass>.GetInstance(key1), default(IIoCManagerTestClass));

            IoCManager<IIoCManagerTestClass>.SetInstance(key1, default(IIoCManagerTestClass));
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(key1), default(IIoCManagerTestClass));

            Assert.AreNotEqual(IoCManager<IIoCManagerTestClass>.GetInstance<IoCManagerTestClass>(key1), default(IIoCManagerTestClass));
            Assert.AreNotEqual(IoCManager<IIoCManagerTestClass>.GetInstance(key1), default(IIoCManagerTestClass));

            IoCManager<IIoCManagerTestClass>.UnsetInstance(key1);
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(key1), default(IIoCManagerTestClass));
            #endregion

            #region DefaultKey
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(), default(IIoCManagerTestClass));

            IoCManager<IIoCManagerTestClass>.SetInstance<IoCManagerTestClass>();
            Assert.AreNotEqual(IoCManager<IIoCManagerTestClass>.GetInstance(), default(IIoCManagerTestClass));

            IoCManager<IIoCManagerTestClass>.SetInstance(default(IIoCManagerTestClass));
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(), default(IIoCManagerTestClass));

            Assert.AreNotEqual(IoCManager<IIoCManagerTestClass>.GetInstance<IoCManagerTestClass>(), default(IIoCManagerTestClass));
            Assert.AreNotEqual(IoCManager<IIoCManagerTestClass>.GetInstance(), default(IIoCManagerTestClass));

            IoCManager<IIoCManagerTestClass>.UnsetInstance();
            Assert.AreEqual(IoCManager<IIoCManagerTestClass>.GetInstance(), default(IIoCManagerTestClass));
            #endregion
        }
    }
}
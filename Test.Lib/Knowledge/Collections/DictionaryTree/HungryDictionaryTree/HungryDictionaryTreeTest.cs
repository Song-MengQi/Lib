using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class HungryDictionaryTreeTest : DictionaryTreeTestBase<HungryDictionaryTree<string,string>>
    {
        protected override HungryDictionaryTree<string, string> CreateInstance()
        {
            return new HungryDictionaryTree<string, string>(default(string), getTestData());
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
        //[TestCleanup()]
        //public void MyTestCleanup() { }
        #endregion

        [TestMethod]
        public override void TestValue()
        {
            base.TestValue();
        }
        [TestMethod]
        public override void TestChildrenDic()
        {
            base.TestChildrenDic();
        }
        [TestMethod]
        public override void TestCount()
        {
            base.TestCount();
        }
        [TestMethod]
        public override void TestContainsKey()
        {
            base.TestContainsKey();
        }
        [TestMethod]
        public override void TestGetChildValue()
        {
            base.TestGetChildValue();
        }
        [TestMethod]
        public override void TestGetChildrenValueDic()
        {
            base.TestGetChildrenValueDic();
        }
        [TestMethod]
        public override void TestGetChildrenValues()
        {
            base.TestGetChildrenValues();
        }
        [TestMethod]
        public override void TestGetChild()
        {
            base.TestGetChild();
        }
        [TestMethod]
        public override void TestGetChildren()
        {
            base.TestGetChildren();
        }
    }
}
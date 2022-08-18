using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    public interface ITestLog : ILog { }
    public class TestLog : LogBase, ITestLog
    {
        protected override string FileName { get { return "Test.log"; } }
    }
    [TestClass]
    public class LogTest : LogTestBase<TestLog, ITestLog>
    {
        #region 附加测试特性
        //在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext) { }

        //在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            TestBase.DeleteData();
        }

        //在运行每个测试之前，使用 TestInitialize 来运行代码
        //[TestInitialize()]
        //public void MyTestInitialize() { }

        //在每个测试运行完之后，使用 TestCleanup 来运行代码
        //[TestCleanup()]
        //public void MyTestCleanup() {}
        #endregion
    }
}

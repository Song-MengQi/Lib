using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class ChecksTest : TestBase
    {
        private enum TestEnum
        {
            A,B
        }
        [TestMethod]
        public void TestCheck()
        {
            Assert.AreEqual(CheckExtends.Check(true, 1), 0);
            Assert.AreEqual(CheckExtends.Check(false, 1), 1);

            Assert.AreEqual(CheckExtends.CheckNot(false, 1), 0);
            Assert.AreEqual(CheckExtends.CheckNot(true, 1), 1);

            Assert.AreEqual(CheckExtends.Check(new object(), 1), 0);
            Assert.AreEqual(CheckExtends.Check(default(object), 1), 1);

            Assert.AreEqual(CheckExtends.CheckObject(new object(), 1), 0);
            Assert.AreEqual(CheckExtends.CheckObject(default(object), 1), 1);

            Assert.AreEqual(CheckExtends.CheckObjects(new object[] { new object() }, 1), 0);
            Assert.AreEqual(CheckExtends.CheckObjects(default(object[]), 1), 1);
            Assert.AreEqual(CheckExtends.CheckObjects(new object[] { default(object) }, 1), 1);

            Assert.AreEqual(CheckExtends.CheckString(default(string), str=>true, 1), 0);
            Assert.AreEqual(CheckExtends.CheckString(default(string), str=>false, 1), 1);

            Assert.AreEqual(CheckExtends.CheckStrings(new string[] { default(string) }, str => true, 1), 0);
            Assert.AreEqual(CheckExtends.CheckStrings(new string[] { default(string) }, str => false, 1), 1);
            Assert.AreEqual(CheckExtends.CheckStrings(default(string[]), str => true, 1), 1);

            Assert.AreEqual(CheckExtends.CheckStrings(string.Empty, str => true, 1), 0);
            Assert.AreEqual(CheckExtends.CheckStrings("1,2", str => true, 1), 0);
            Assert.AreEqual(CheckExtends.CheckStrings(default(string), str => true, 1), 1);
            Assert.AreEqual(CheckExtends.CheckStrings("1,2", str => false, 1), 1);

            Assert.AreEqual(CheckExtends.CheckEnum<TestEnum>("0", 1), 0);
            Assert.AreEqual(CheckExtends.CheckEnum<TestEnum>("10000", 1), 1);
        }
    }
}
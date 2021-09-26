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
            Assert.AreEqual(Checks.Check(true, 1), 0);
            Assert.AreEqual(Checks.Check(false, 1), 1);

            Assert.AreEqual(Checks.CheckNot(false, 1), 0);
            Assert.AreEqual(Checks.CheckNot(true, 1), 1);

            Assert.AreEqual(Checks.Check(new object(), 1), 0);
            Assert.AreEqual(Checks.Check(default(object), 1), 1);

            Assert.AreEqual(Checks.CheckObject(new object(), 1), 0);
            Assert.AreEqual(Checks.CheckObject(default(object), 1), 1);

            Assert.AreEqual(Checks.CheckObjects(new object[] { new object() }, 1), 0);
            Assert.AreEqual(Checks.CheckObjects(default(object[]), 1), 1);
            Assert.AreEqual(Checks.CheckObjects(new object[] { default(object) }, 1), 1);

            Assert.AreEqual(Checks.CheckString(default(string), str=>true, 1), 0);
            Assert.AreEqual(Checks.CheckString(default(string), str=>false, 1), 1);

            Assert.AreEqual(Checks.CheckStrings(new string[] { default(string) }, str => true, 1), 0);
            Assert.AreEqual(Checks.CheckStrings(new string[] { default(string) }, str => false, 1), 1);
            Assert.AreEqual(Checks.CheckStrings(default(string[]), str => true, 1), 1);

            Assert.AreEqual(Checks.CheckStrings(string.Empty, str => true, 1), 0);
            Assert.AreEqual(Checks.CheckStrings("1,2", str => true, 1), 0);
            Assert.AreEqual(Checks.CheckStrings(default(string), str => true, 1), 1);
            Assert.AreEqual(Checks.CheckStrings("1,2", str => false, 1), 1);

            Assert.AreEqual(Checks.CheckEnum<TestEnum>("0", 1), 0);
            Assert.AreEqual(Checks.CheckEnum<TestEnum>("10000", 1), 1);
        }
    }
}
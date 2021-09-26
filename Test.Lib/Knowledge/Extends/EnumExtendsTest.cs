using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class EnumExtendsTest : TestBase
    {
        private enum TestEnum
        {
            Aa,
            Bb,
            Cc
        }
        [TestMethod]
        public void TestParse()
        {
            Assert.AreEqual(EnumExtends.Parse<TestEnum>(null), default(TestEnum));
            Assert.AreEqual(EnumExtends.Parse<TestEnum>(""), default(TestEnum));
            Assert.AreEqual(EnumExtends.Parse<TestEnum>("bA"), TestEnum.Aa);
            Assert.AreEqual(EnumExtends.Parse<TestEnum>("bb"), TestEnum.Bb);
            Assert.AreEqual(EnumExtends.Parse<TestEnum>("Bb"), TestEnum.Bb);
        }
        [TestMethod]
        public void TestToObject()
        {
            Assert.AreEqual(EnumExtends.ToObject<TestEnum>(null), default(TestEnum));
            Assert.AreEqual(EnumExtends.ToObject<TestEnum>(""), default(TestEnum));
            Assert.AreEqual(EnumExtends.ToObject<TestEnum>("1"), TestEnum.Bb);
            Assert.AreEqual(EnumExtends.ToObject<TestEnum>(1), TestEnum.Bb);
            byte byte1 = 1;
            Assert.AreEqual(EnumExtends.ToObject<TestEnum>(byte1), TestEnum.Bb);
            Assert.AreEqual(EnumExtends.ToObject<TestEnum>(999), default(TestEnum));
        }
        [TestMethod]
        public void TestIsDefined()
        {
            Assert.IsTrue(EnumExtends.IsDefined<TestEnum>(0));
            Assert.IsFalse(EnumExtends.IsDefined<TestEnum>(-1));

            Assert.IsFalse(EnumExtends.IsDefined<TestEnum>("asd"));
            Assert.IsTrue(EnumExtends.IsDefined<TestEnum>("0"));
            Assert.IsFalse(EnumExtends.IsDefined<TestEnum>("987"));
        }
    }
}
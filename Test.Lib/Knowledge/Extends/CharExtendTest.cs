using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class CharExtendTest : TestBase
    {
        [TestMethod]
        public void TestIsAscii()
        {
            Assert.IsTrue('1'.IsAscii());
            Assert.IsFalse('一'.IsAscii());
        }
        [TestMethod]
        public void TestIs_zh()
        {
            Assert.IsTrue('一'.Is_zh());
            Assert.IsFalse('1'.Is_zh());
        }
        [TestMethod]
        public void TestIs_ja()
        {
            Assert.IsTrue(((char)(0x3040)).Is_ja());
            Assert.IsFalse('1'.Is_ja());
        }
        [TestMethod]
        public void TestIs_ko()
        {
            Assert.IsTrue(((char)(0x1100)).Is_ko());
            Assert.IsTrue(((char)(0xac00)).Is_ko());
            Assert.IsTrue(((char)(0x3130)).Is_ko());
            Assert.IsFalse('1'.Is_ko());
        }
        [TestMethod]
        public void TestIs_th()
        {
            Assert.IsTrue(((char)(0x0e00)).Is_th());
            Assert.IsFalse('1'.Is_th());
        }
        [TestMethod]
        public void TestIsDigit()
        {
            Assert.IsFalse('一'.IsDigit());
            Assert.IsTrue('1'.IsDigit());
        }
        [TestMethod]
        public void TestIsLowerLetter()
        {
            Assert.IsFalse('A'.IsLowerLetter());
            Assert.IsTrue('a'.IsLowerLetter());
        }
        [TestMethod]
        public void TestIsUpperLetter()
        {
            Assert.IsFalse('a'.IsUpperLetter());
            Assert.IsTrue('A'.IsUpperLetter());
        }
        [TestMethod]
        public void TestIsLetter()
        {
            Assert.IsFalse('1'.IsLetter());
            Assert.IsTrue('A'.IsLetter());
        }
        [TestMethod]
        public void TestIsSimpleChar()
        {
            Assert.IsTrue('1'.IsSimpleChar());
            Assert.IsTrue('A'.IsSimpleChar());
            Assert.IsFalse('+'.IsSimpleChar());
        }
        [TestMethod]
        public void TestIsHexNumber()
        {
            Assert.IsTrue('1'.IsHexNumber());
            Assert.IsTrue('A'.IsHexNumber());
            Assert.IsTrue('f'.IsHexNumber());
            Assert.IsFalse('g'.IsHexNumber());
            Assert.IsFalse('+'.IsHexNumber());
        }
    }
}
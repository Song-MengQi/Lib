using System;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class BitConverterExtendsTest : TestBase
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(BitConverterExtends.ToBool(BitConverterExtends.ToBytes(true)));
            Assert.IsTrue(BitConverterExtends.ToBool(BitConverterExtends.ToBytes(true, false), false));
            Assert.AreEqual(BitConverterExtends.ToChar(BitConverterExtends.ToBytes('A')), 'A');
            Assert.AreEqual(BitConverterExtends.ToShort(BitConverterExtends.ToBytes((short)123)), (short)123);
            Assert.AreEqual(BitConverterExtends.ToUshort(BitConverterExtends.ToBytes((ushort)123)), (ushort)123);
            Assert.AreEqual(BitConverterExtends.ToInt(BitConverterExtends.ToBytes(123)), 123);
            Assert.AreEqual(BitConverterExtends.ToUint(BitConverterExtends.ToBytes(123u)), 123u);
            Assert.AreEqual(BitConverterExtends.ToLong(BitConverterExtends.ToBytes(123L)), 123L);
            Assert.AreEqual(BitConverterExtends.ToUlong(BitConverterExtends.ToBytes(123ul)), 123ul);
            Assert.AreEqual(BitConverterExtends.ToFloat(BitConverterExtends.ToBytes(12.3f)), 12.3f);
            Assert.AreEqual(BitConverterExtends.ToDouble(BitConverterExtends.ToBytes(12.3d)), 12.3d);
        }
    }
}
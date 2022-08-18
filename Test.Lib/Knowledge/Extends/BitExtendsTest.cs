using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class BitExtendsTest : TestBase
    {
        [TestMethod]
        public void TestBit()
        {
            byte b1 = 0;
            BitExtends.SetBit(ref b1, 3);
            Assert.IsTrue(BitExtends.GetBit(b1, 3));
            Assert.IsFalse(BitExtends.GetBit(b1, 4));
            Assert.IsFalse(BitExtends.GetBit(b1, 100));
            Assert.IsFalse(BitExtends.GetBit(b1, -100));
            BitExtends.UnsetBit(ref b1, 3);
            Assert.IsFalse(BitExtends.GetBit(b1, 3));

            BitExtends.SetBit(ref b1, 100);
            BitExtends.SetBit(ref b1, -100);
            BitExtends.UnsetBit(ref b1, 100);
            BitExtends.UnsetBit(ref b1, -100);


            byte[] b2 = new byte[4];
            BitExtends.SetBit(b2, 23);
            Assert.IsTrue(BitExtends.GetBit(b2, 23));
            Assert.IsFalse(BitExtends.GetBit(b2, 24));
            Assert.IsFalse(BitExtends.GetBit(b2, 100));
            Assert.IsFalse(BitExtends.GetBit(b2, -100));
            BitExtends.UnsetBit(b2, 23);
            Assert.IsFalse(BitExtends.GetBit(b2, 23));

            BitExtends.SetBit(b2, 100);
            BitExtends.SetBit(b2, -100);
            BitExtends.UnsetBit(b2, -100);
            BitExtends.UnsetBit(b2, 100);
        }
        [TestMethod]
        public void TestGetBitLength()
        {
            Assert.AreEqual(BitExtends.GetBitLength(0ul, 64ul), 0);
            Assert.AreEqual(BitExtends.GetBitLength(1ul, 64ul), 1);

            Assert.AreEqual(BitExtends.GetBitLength(63ul, 64ul), 1);
            Assert.AreEqual(BitExtends.GetBitLength(64ul, 64ul), 1);
            Assert.AreEqual(BitExtends.GetBitLength(65ul, 64ul), 2);
            Assert.AreEqual(BitExtends.GetBitLength(ulong.MaxValue, 64ul), 11);
        }
        [TestMethod]
        public void TestGetHexLength()
        {
            Assert.AreEqual(BitExtends.GetHexLength(0), 0);
            Assert.AreEqual(BitExtends.GetHexLength(1), 1);

            Assert.AreEqual(BitExtends.GetHexLength(256), 2);
            Assert.AreEqual(BitExtends.GetHexLength(255), 2);
            Assert.AreEqual(BitExtends.GetHexLength(257), 3);
        }
        [TestMethod]
        public void TestDigit()
        {
            byte[] bytes = new byte[8];//总数据
            uint value = 123;//一个32bit的数字
            ushort[] bits = ArrayExtends.GetArray(32, i => (ushort)(32 + i));//一个32bit的地址
            BitExtends.SetDigit(bytes, value, bits);
            Assert.AreEqual(BitExtends.GetDigit<uint>(bytes, bits), value);
        }
    }
}
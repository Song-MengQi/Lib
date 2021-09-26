using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class BitExtendsTest : TestBase
    {
        [TestMethod]
        public void Test()
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
        public void TestGetHexLength()
        {
            Assert.AreEqual(BitExtends.GetHexLength(0), 0);
            Assert.AreEqual(BitExtends.GetHexLength(1), 1);

            Assert.AreEqual(BitExtends.GetHexLength(256), 2);
            Assert.AreEqual(BitExtends.GetHexLength(255), 2);
            Assert.AreEqual(BitExtends.GetHexLength(257), 3);
        }
    }
}
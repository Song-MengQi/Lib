using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test.Lib
{
    [TestClass]
    public class ConvertExtendsTest
    {
        [TestMethod]
        public void TestChangeType()
        {
            Assert.AreEqual(ConvertExtends.ChangeType<int>((object)1), 1);
        }
        [TestMethod]
        public void TestNegate()
        {
            Assert.AreEqual(ConvertExtends.Negate((sbyte)1), (sbyte)-1);
            Assert.AreEqual(ConvertExtends.Negate((short)1), (short)-1);
            Assert.AreEqual(ConvertExtends.Negate(1), -1);
            Assert.AreEqual(ConvertExtends.Negate(1L), -1L);
            Assert.AreEqual(ConvertExtends.Negate(1f), -1f);
            Assert.AreEqual(ConvertExtends.Negate(1d), -1d);
            Assert.AreEqual(ConvertExtends.Negate(1m), -1m);
            Assert.AreEqual(ConvertExtends.Negate(new object()), default(object));
        }
        [TestMethod]
        public void TestAdd()
        {
            Assert.AreEqual(ConvertExtends.Add((byte)1, (byte)2), (byte)3);
            Assert.AreEqual(ConvertExtends.Add((sbyte)1, (sbyte)2), (sbyte)3);
            Assert.AreEqual(ConvertExtends.Add((ushort)1, (ushort)2), (ushort)3);
            Assert.AreEqual(ConvertExtends.Add((short)1, (short)2), (short)3);
            Assert.AreEqual(ConvertExtends.Add(1u, 2u), 3u);
            Assert.AreEqual(ConvertExtends.Add(1, 2), 3);
            Assert.AreEqual(ConvertExtends.Add(1ul, 2ul), 3ul);
            Assert.AreEqual(ConvertExtends.Add(1L, 2L), 3L);
            Assert.AreEqual(ConvertExtends.Add(1f, 2f), 3f);
            Assert.AreEqual(ConvertExtends.Add(1d, 2d), 3d);
            Assert.AreEqual(ConvertExtends.Add(1m, 2m), 3m);
            Assert.AreEqual(ConvertExtends.Add(new object(), new object()), default(object));
        }
        [TestMethod]
        public void TestSubtract()
        {
            Assert.AreEqual(ConvertExtends.Subtract((byte)3, (byte)2), (byte)1);
            Assert.AreEqual(ConvertExtends.Subtract((sbyte)3, (sbyte)2), (sbyte)1);
            Assert.AreEqual(ConvertExtends.Subtract((ushort)3, (ushort)2), (ushort)1);
            Assert.AreEqual(ConvertExtends.Subtract((short)3, (short)2), (short)1);
            Assert.AreEqual(ConvertExtends.Subtract(3u, 2u), 1u);
            Assert.AreEqual(ConvertExtends.Subtract(3, 2), 1);
            Assert.AreEqual(ConvertExtends.Subtract(3ul, 2ul), 1ul);
            Assert.AreEqual(ConvertExtends.Subtract(3L, 2L), 1L);
            Assert.AreEqual(ConvertExtends.Subtract(3f, 2f), 1f);
            Assert.AreEqual(ConvertExtends.Subtract(3d, 2d), 1d);
            Assert.AreEqual(ConvertExtends.Subtract(3m, 2m), 1m);
            Assert.AreEqual(ConvertExtends.Subtract(new object(), new object()), default(object));
        }
        [TestMethod]
        public void TestMultiply()
        {
            Assert.AreEqual(ConvertExtends.Multiply((byte)3, 2d), (byte)6);
            Assert.AreEqual(ConvertExtends.Multiply((sbyte)3, 2d), (sbyte)6);
            Assert.AreEqual(ConvertExtends.Multiply((ushort)3, 2d), (ushort)6);
            Assert.AreEqual(ConvertExtends.Multiply((short)3, 2d), (short)6);
            Assert.AreEqual(ConvertExtends.Multiply(3u, 2d), 6u);
            Assert.AreEqual(ConvertExtends.Multiply(3, 2d), 6);
            Assert.AreEqual(ConvertExtends.Multiply(3ul, 2d), 6ul);
            Assert.AreEqual(ConvertExtends.Multiply(3L, 2d), 6L);
            Assert.AreEqual(ConvertExtends.Multiply(3f, 2d), 6f);
            Assert.AreEqual(ConvertExtends.Multiply(3d, 2d), 6d);
            Assert.AreEqual(ConvertExtends.Multiply(3m, 2d), 6m);

            Assert.AreEqual(ConvertExtends.Multiply((byte)3, 2m), (byte)6);
            Assert.AreEqual(ConvertExtends.Multiply((sbyte)3, 2m), (sbyte)6);
            Assert.AreEqual(ConvertExtends.Multiply((ushort)3, 2m), (ushort)6);
            Assert.AreEqual(ConvertExtends.Multiply((short)3, 2m), (short)6);
            Assert.AreEqual(ConvertExtends.Multiply(3u, 2m), 6u);
            Assert.AreEqual(ConvertExtends.Multiply(3, 2m), 6);
            Assert.AreEqual(ConvertExtends.Multiply(3ul, 2m), 6ul);
            Assert.AreEqual(ConvertExtends.Multiply(3L, 2m), 6L);
            Assert.AreEqual(ConvertExtends.Multiply(3f, 2m), 6f);
            Assert.AreEqual(ConvertExtends.Multiply(3d, 2m), 6d);
            Assert.AreEqual(ConvertExtends.Multiply(3m, 2m), 6m);
        }
        [TestMethod]
        public void TestDivide()
        {
            Assert.AreEqual(ConvertExtends.Divide((byte)3, 1d), (byte)3);
            Assert.AreEqual(ConvertExtends.Divide((sbyte)3, 1d), (sbyte)3);
            Assert.AreEqual(ConvertExtends.Divide((ushort)3, 1d), (ushort)3);
            Assert.AreEqual(ConvertExtends.Divide((short)3, 1d), (short)3);
            Assert.AreEqual(ConvertExtends.Divide(3u, 1d), 3u);
            Assert.AreEqual(ConvertExtends.Divide(3, 1d), 3);
            Assert.AreEqual(ConvertExtends.Divide(3ul, 1d), 3ul);
            Assert.AreEqual(ConvertExtends.Divide(3L, 1d), 3L);
            Assert.AreEqual(ConvertExtends.Divide(3f, 1d), 3f);
            Assert.AreEqual(ConvertExtends.Divide(3d, 1d), 3d);
            Assert.AreEqual(ConvertExtends.Divide(3m, 1d), 3m);

            Assert.AreEqual(ConvertExtends.Divide((byte)3, 1m), (byte)3);
            Assert.AreEqual(ConvertExtends.Divide((sbyte)3, 1m), (sbyte)3);
            Assert.AreEqual(ConvertExtends.Divide((ushort)3, 1m), (ushort)3);
            Assert.AreEqual(ConvertExtends.Divide((short)3, 1m), (short)3);
            Assert.AreEqual(ConvertExtends.Divide(3u, 1m), 3u);
            Assert.AreEqual(ConvertExtends.Divide(3, 1m), 3);
            Assert.AreEqual(ConvertExtends.Divide(3ul, 1m), 3ul);
            Assert.AreEqual(ConvertExtends.Divide(3L, 1m), 3L);
            Assert.AreEqual(ConvertExtends.Divide(3f, 1m), 3f);
            Assert.AreEqual(ConvertExtends.Divide(3d, 1m), 3d);
            Assert.AreEqual(ConvertExtends.Divide(3m, 1m), 3m);
        }
        [TestMethod]
        public void TestConvertStateToResult()
        {
            Assert.AreEqual(ConvertExtends.ConvertStateToResult(123).State, 123);
            Assert.AreEqual(ConvertExtends.ConvertStateToResult(() => 123)().State, 123);
            Assert.IsNull(ConvertExtends.ConvertStateToResult(default(Func<int>)));
        }

        [TestMethod]
        public void TestBase64()
        {
            byte[] bytes = new byte[] { 0, 1, 2, 3, 4};
            string base64 = ConvertExtends.ToBase64String(bytes);
            byte[] result = ConvertExtends.FromBase64String(base64);
            AssertExtends.AreSequenceEqual(bytes, result);
        }
    }
}

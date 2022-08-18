using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices;

namespace Test.Lib
{
    [TestClass]
    public class BitConverterExtendsTest : TestBase
    {
        #region old
        //[StructLayout(LayoutKind.Explicit)]
        //private struct TestAStruct
        //{
        //    [FieldOffset(0)]
        //    public bool X;
        //    [FieldOffset(2)]
        //    public uint Y;
        //    [FieldOffset(6)]
        //    public ushort Z;
        //}
        //https://docs.microsoft.com/zh-cn/visualstudio/code-quality/ca1900
        //小于 8 个字节的所有字段的偏移量必须是其大小的倍数，而大于或等于 8 个字节的字段的偏移量必须是 8 的倍数。 另一种解决方案是使用 LayoutKind.Sequential 而不是 LayoutKind.Explicit（如果合理）。
        #endregion
        [StructLayout(LayoutKind.Explicit)]
        private struct TestAStruct
        {
            [FieldOffset(0)]
            public bool X;
            [FieldOffset(4)]
            public uint Y;
            [FieldOffset(8)]
            public ushort Z;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct TestBStruct
        {
            [MarshalAs(UnmanagedType.Bool)]
            public bool X;
            [MarshalAs(UnmanagedType.U4)]
            public uint Y;
            [MarshalAs(UnmanagedType.U2)]
            public ushort Z;
        }
        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(BitConverterExtends.ToBool(BitConverterExtends.ToBytes(true, false), false));

            Assert.IsTrue(BitConverterExtends.ToBool(BitConverterExtends.ToBytes(true)));
            Assert.AreEqual(BitConverterExtends.ToChar(BitConverterExtends.ToBytes('A')), 'A');
            Assert.AreEqual(BitConverterExtends.ToSbyte(BitConverterExtends.ToBytes((sbyte)123)), (sbyte)123);
            Assert.AreEqual(BitConverterExtends.ToByte(BitConverterExtends.ToBytes((byte)123)), (byte)123);
            Assert.AreEqual(BitConverterExtends.ToShort(BitConverterExtends.ToBytes((short)123)), (short)123);
            Assert.AreEqual(BitConverterExtends.ToUshort(BitConverterExtends.ToBytes((ushort)123)), (ushort)123);
            Assert.AreEqual(BitConverterExtends.ToInt(BitConverterExtends.ToBytes(123)), 123);
            Assert.AreEqual(BitConverterExtends.ToUint(BitConverterExtends.ToBytes(123u)), 123u);
            Assert.AreEqual(BitConverterExtends.ToLong(BitConverterExtends.ToBytes(123L)), 123L);
            Assert.AreEqual(BitConverterExtends.ToUlong(BitConverterExtends.ToBytes(123ul)), 123ul);
            Assert.AreEqual(BitConverterExtends.ToFloat(BitConverterExtends.ToBytes(12.3f)), 12.3f);
            Assert.AreEqual(BitConverterExtends.ToDouble(BitConverterExtends.ToBytes(12.3d)), 12.3d);
            Assert.AreEqual(BitConverterExtends.ToDecimal(BitConverterExtends.ToBytes(123m)), 123m);

            Test(true);
            Test('A');
            Test((sbyte)123);
            Test((byte)123);
            Test((short)123);
            Test((ushort)123);
            Test(123);
            Test(123u);
            Test(123L);
            Test(123ul);
            Test(123f);
            Test(123d);
            Test(123m);

            Test(new TestAStruct {
                X = true,
                Y = 123,
                Z = 456
            });
            Test(new TestBStruct {
                X = true,
                Y = 123,
                Z = 456
            });

            Assert.IsNull(BitConverterExtends.To<object>(null));
            Assert.IsNull(BitConverterExtends.ToBytes(default(object)));
        }
        private void Test<T>(T t)
        {
            Assert.AreEqual(BitConverterExtends.To<T>(BitConverterExtends.ToBytes(t)), t);
        }
    }
}
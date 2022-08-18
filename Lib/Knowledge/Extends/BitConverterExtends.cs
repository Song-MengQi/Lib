using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lib
{
    public static class BitConverterExtends
    {
        #region BigEndian & LittleEndian
        public static byte[] EnsureEndian(this byte[] bytes, bool isLittleEndian)
        {
            return BitConverter.IsLittleEndian == isLittleEndian
                ? bytes
                : bytes.Reverse().ToArray();
        }
        #endregion
        #region FromBytes
        public static bool ToBool(this byte[] bytes, bool isLittleEndian = true)
        {
            return BitConverter.ToBoolean(EnsureEndian(bytes, isLittleEndian), 0);
        }
        public static char ToChar(this byte[] bytes, bool isLittleEndian = true)
        {
            return BitConverter.ToChar(EnsureEndian(bytes, isLittleEndian), 0);
        }
        public static sbyte ToSbyte(this byte[] bytes, bool isLittleEndian = true)
        {
            return (sbyte)bytes[0];
        }
        public static byte ToByte(this byte[] bytes, bool isLittleEndian = true)
        {
            return bytes[0];
        }
        public static short ToShort(this byte[] bytes, bool isLittleEndian = true)
        {
            return BitConverter.ToInt16(EnsureEndian(bytes, isLittleEndian), 0);
        }
        public static ushort ToUshort(this byte[] bytes, bool isLittleEndian = true)
        {
            return BitConverter.ToUInt16(EnsureEndian(bytes, isLittleEndian), 0);
        }
        public static int ToInt(this byte[] bytes, bool isLittleEndian = true)
        {
            return BitConverter.ToInt32(EnsureEndian(bytes, isLittleEndian), 0);
        }
        public static uint ToUint(this byte[] bytes, bool isLittleEndian = true)
        {
            return BitConverter.ToUInt32(EnsureEndian(bytes, isLittleEndian), 0);
        }
        public static long ToLong(this byte[] bytes, bool isLittleEndian = true)
        {
            return BitConverter.ToInt64(EnsureEndian(bytes, isLittleEndian), 0);
        }
        public static ulong ToUlong(this byte[] bytes, bool isLittleEndian = true)
        {
            return BitConverter.ToUInt64(EnsureEndian(bytes, isLittleEndian), 0);
        }
        public static float ToFloat(this byte[] bytes, bool isLittleEndian = true)
        {
            return BitConverter.ToSingle(EnsureEndian(bytes, isLittleEndian), 0);
        }
        public static double ToDouble(this byte[] bytes, bool isLittleEndian = true)
        {
            return BitConverter.ToDouble(EnsureEndian(bytes, isLittleEndian), 0);
        }
        public static decimal ToDecimal(this byte[] bytes, bool isLittleEndian = true)
        {
            bytes = EnsureEndian(bytes, isLittleEndian);
            int intSize = sizeof(int);
            //decimal里的4个int是小端
            return new decimal(ArrayExtends.GetArray(bytes.Length / intSize, i=>ToInt(bytes.Skip(i * intSize).Take(intSize).ToArray())));
        }
        private static object ToStructure(byte[] bytes, Type type, bool isLittleEndian = true)
        {
            IntPtr intPtr = MarshalExtends.BytesToIntPtr(EnsureEndian(bytes, isLittleEndian));
            object value = Marshal.PtrToStructure(intPtr, type);
            Marshal.FreeHGlobal(intPtr);
            return value;
        }
        public static object To(this byte[] bytes, Type type, bool isLittleEndian = true)
        {
            if (typeof(bool) == type) return ToBool(bytes, isLittleEndian);
            if (typeof(char) == type) return ToChar(bytes, isLittleEndian);

            if (typeof(sbyte) == type) return ToSbyte(bytes, isLittleEndian);
            if (typeof(byte) == type) return ToByte(bytes, isLittleEndian);
            if (typeof(short) == type) return ToShort(bytes, isLittleEndian);
            if (typeof(ushort) == type) return ToUshort(bytes, isLittleEndian);
            if (typeof(int) == type) return ToInt(bytes, isLittleEndian);
            if (typeof(uint) == type) return ToUint(bytes, isLittleEndian);
            if (typeof(long) == type) return ToLong(bytes, isLittleEndian);
            if (typeof(ulong) == type) return ToUlong(bytes, isLittleEndian);

            if (typeof(float) == type) return ToFloat(bytes, isLittleEndian);
            if (typeof(double) == type) return ToDouble(bytes, isLittleEndian);
            if (typeof(decimal) == type) return ToDecimal(bytes, isLittleEndian);

            if (false == type.IsClass) return ToStructure(bytes, type, isLittleEndian);

            return default(object);
        }
        public static T To<T>(this byte[] bytes, bool isLittleEndian = true)
        {
            return (T)bytes.To(typeof(T), isLittleEndian);
        }
        #endregion
        #region ToBytes
        public static byte[] ToBytes(this bool value, bool isLittleEndian = true)
        {
            return EnsureEndian(BitConverter.GetBytes(value), isLittleEndian);
        }
        public static byte[] ToBytes(this char value, bool isLittleEndian = true)
        {
            return EnsureEndian(BitConverter.GetBytes(value), isLittleEndian);
        }
        public static byte[] ToBytes(this sbyte value, bool isLittleEndian = true)
        {
            return EnsureEndian(ArrayExtends.Create((byte)value), isLittleEndian);
        }
        public static byte[] ToBytes(this byte value, bool isLittleEndian = true)
        {
            return EnsureEndian(ArrayExtends.Create(value), isLittleEndian);
        }
        public static byte[] ToBytes(this short value, bool isLittleEndian = true)
        {
            return EnsureEndian(BitConverter.GetBytes(value), isLittleEndian);
        }
        public static byte[] ToBytes(this ushort value, bool isLittleEndian = true)
        {
            return EnsureEndian(BitConverter.GetBytes(value), isLittleEndian);
        }
        public static byte[] ToBytes(this int value, bool isLittleEndian = true)
        {
            return EnsureEndian(BitConverter.GetBytes(value), isLittleEndian);
        }
        public static byte[] ToBytes(this uint value, bool isLittleEndian = true)
        {
            return EnsureEndian(BitConverter.GetBytes(value), isLittleEndian);
        }
        public static byte[] ToBytes(this long value, bool isLittleEndian = true)
        {
            return EnsureEndian(BitConverter.GetBytes(value), isLittleEndian);
        }
        public static byte[] ToBytes(this ulong value, bool isLittleEndian = true)
        {
            return EnsureEndian(BitConverter.GetBytes(value), isLittleEndian);
        }
        public static byte[] ToBytes(this float value, bool isLittleEndian = true)
        {
            return EnsureEndian(BitConverter.GetBytes(value), isLittleEndian);
        }
        public static byte[] ToBytes(this double value, bool isLittleEndian = true)
        {
            return EnsureEndian(BitConverter.GetBytes(value), isLittleEndian);
        }
        public static byte[] ToBytes(this decimal value, bool isLittleEndian = true)
        {
            //decimal里的4个int是小端
            return EnsureEndian(decimal.GetBits(value).SelectMany(BitConverter.GetBytes).ToArray(), isLittleEndian);
        }
        private static byte[] StructureToBytes(object value, Type type, bool isLittleEndian = true)
        {
            int size = Marshal.SizeOf(type);
            IntPtr intPtr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(value, intPtr, false);
            byte[] bytes = MarshalExtends.IntPtrToBytes(intPtr, size);
            Marshal.FreeHGlobal(intPtr);
            return EnsureEndian(bytes, isLittleEndian);
        }
        public static byte[] ToBytes(object value, Type type, bool isLittleEndian = true)
        {
            if (typeof(bool) == type) return ConvertExtends.ChangeType<bool>(value).ToBytes(isLittleEndian);
            if (typeof(char) == type) return ConvertExtends.ChangeType<char>(value).ToBytes(isLittleEndian);

            if (typeof(sbyte) == type) return ConvertExtends.ChangeType<sbyte>(value).ToBytes(isLittleEndian);
            if (typeof(byte) == type) return ConvertExtends.ChangeType<byte>(value).ToBytes(isLittleEndian);
            if (typeof(short) == type) return ConvertExtends.ChangeType<short>(value).ToBytes(isLittleEndian);
            if (typeof(ushort) == type) return ConvertExtends.ChangeType<ushort>(value).ToBytes(isLittleEndian);
            if (typeof(int) == type) return ConvertExtends.ChangeType<int>(value).ToBytes(isLittleEndian);
            if (typeof(uint) == type) return ConvertExtends.ChangeType<uint>(value).ToBytes(isLittleEndian);
            if (typeof(long) == type) return ConvertExtends.ChangeType<long>(value).ToBytes(isLittleEndian);
            if (typeof(ulong) == type) return ConvertExtends.ChangeType<ulong>(value).ToBytes(isLittleEndian);

            if (typeof(float) == type) return ConvertExtends.ChangeType<float>(value).ToBytes(isLittleEndian);
            if (typeof(double) == type) return ConvertExtends.ChangeType<double>(value).ToBytes(isLittleEndian);
            if (typeof(decimal) == type) return ConvertExtends.ChangeType<decimal>(value).ToBytes(isLittleEndian);

            if (false == type.IsClass) return StructureToBytes(value, type, isLittleEndian);

            return default(byte[]);
        }
        #region ToBytes这个名可能会污染一些类，比如MemoryStream : Stream，还是不要this了
        public static byte[] ToBytes<T>(T value, bool isLittleEndian = true)
        {
            return ToBytes(value, typeof(T), isLittleEndian);
        }
        #endregion
        #endregion
    }
}
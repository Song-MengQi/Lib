using System;
using System.Linq;

namespace Lib
{
    public static class BitConverterExtends
    {
        //private static object To(byte[] bytes, Type type)
        //{
        //    if (typeof(bool) == type) return BitConverter.ToBoolean(bytes, 0);
        //    if (typeof(char) == type) return BitConverter.ToChar(bytes, 0);

        //    if (typeof(short) == type) return BitConverter.ToInt16(bytes, 0);
        //    if (typeof(ushort) == type) return BitConverter.ToUInt16(bytes, 0);
        //    if (typeof(int) == type) return BitConverter.ToInt32(bytes, 0);
        //    if (typeof(uint) == type) return BitConverter.ToUInt32(bytes, 0);
        //    if (typeof(long) == type) return BitConverter.ToInt64(bytes, 0);
        //    if (typeof(ulong) == type) return BitConverter.ToUInt64(bytes, 0);

        //    if (typeof(float) == type) return BitConverter.ToSingle(bytes, 0);
        //    if (typeof(double) == type) return BitConverter.ToDouble(bytes, 0);

        //    return default(object);
        //}
        //public static T To<T>(byte[] bytes)
        //    where T : struct
        //{
        //    return (T)To(bytes, typeof(T));
        //}
        //以上写法无效
        #region BigEndian & LittleEndian
        private static byte[] EnsureEndian(byte[] bytes, bool isLittleEndian)
        {
            return BitConverter.IsLittleEndian == isLittleEndian
                ? bytes
                : bytes.Reverse().ToArray();
        }
        #endregion
        #region FromBytes
        public static bool ToBool(byte[] bytes, bool isLittleEndian = true)
        {
            return BitConverter.ToBoolean(EnsureEndian(bytes, isLittleEndian), 0);
        }
        public static char ToChar(byte[] bytes, bool isLittleEndian = true)
        {
            return BitConverter.ToChar(EnsureEndian(bytes, isLittleEndian), 0);
        }
        public static short ToShort(byte[] bytes, bool isLittleEndian = true)
        {
            return BitConverter.ToInt16(EnsureEndian(bytes, isLittleEndian), 0);
        }
        public static ushort ToUshort(byte[] bytes, bool isLittleEndian = true)
        {
            return BitConverter.ToUInt16(EnsureEndian(bytes, isLittleEndian), 0);
        }
        public static int ToInt(byte[] bytes, bool isLittleEndian = true)
        {
            return BitConverter.ToInt32(EnsureEndian(bytes, isLittleEndian), 0);
        }
        public static uint ToUint(byte[] bytes, bool isLittleEndian = true)
        {
            return BitConverter.ToUInt32(EnsureEndian(bytes, isLittleEndian), 0);
        }
        public static long ToLong(byte[] bytes, bool isLittleEndian = true)
        {
            return BitConverter.ToInt64(EnsureEndian(bytes, isLittleEndian), 0);
        }
        public static ulong ToUlong(byte[] bytes, bool isLittleEndian = true)
        {
            return BitConverter.ToUInt64(EnsureEndian(bytes, isLittleEndian), 0);
        }
        public static float ToFloat(byte[] bytes, bool isLittleEndian = true)
        {
            return BitConverter.ToSingle(EnsureEndian(bytes, isLittleEndian), 0);
        }
        public static double ToDouble(byte[] bytes, bool isLittleEndian = true)
        {
            return BitConverter.ToDouble(EnsureEndian(bytes, isLittleEndian), 0);
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
        #endregion
    }
}
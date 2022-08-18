using System;

namespace Lib
{
    public static class BitExtends
    {
        public static bool GetBit(byte b, int index)
        {
            if (index < 0 || index >> 3 > 0) return false;
            return (b & (1 << index)) > 0;
        }
        public static void SetBit(ref byte b, int index)
        {
            if (index < 0 || index >> 3 > 0) return;
            b |= (byte)(1 << index);
        }
        public static void UnsetBit(ref byte b, int index)
        {
            if (index < 0 || index >> 3 > 0) return;
            b &= (byte)~(1 << index);
        }

        private static int GetMasterIndex(int index) { return index >> 3; }
        private static int GetSlaveIndex(int index) { return index & (~(~0 << 3)); }//index & 0b111;
        public static bool GetBit(byte[] bytes, int index)
        {
            if (index < 0 || index >= (bytes.Length << 3)) return false;
            return GetBit(bytes[GetMasterIndex(index)], GetSlaveIndex(index));
        }
        public static void SetBit(byte[] bytes, int index)
        {
            if (index < 0 || index >= (bytes.Length << 3)) return;
            SetBit(ref bytes[GetMasterIndex(index)], GetSlaveIndex(index));
        }
        public static void UnsetBit(byte[] bytes, int index)
        {
            if (index < 0 || index >= (bytes.Length << 3)) return;
            UnsetBit(ref bytes[GetMasterIndex(index)], GetSlaveIndex(index));
        }
        private static int GetBitLength(ulong count, Func<ulong, ulong> func)
        {
            //count是信号的数量
            if (count > 1) --count;
            int length = 0;//位数
            while (count > 0)
            {
                count = func(count);
                //count /= baseCount;
                ++length;
            }
            return length;
        }
        public static int GetBitLength(ulong count, ulong baseCount)
        {
            return GetBitLength(count, c=>c/baseCount);
        }
        public static int GetHexLength(ulong count)
        {
            return GetBitLength(count, c=>c>>4);
        }
        #region 小端数字
        public static void SetDigit(byte[] bytes, long d, params ushort[] bits)
        {
            int length = Math.Min(sizeof(long) << 3, bits.Length);
            for(int i = 0; i < length; ++i)
            {
                if (1 == (d & 1)) SetBit(bytes, bits[i]);
                else UnsetBit(bytes, bits[i]);
                d >>= 1;
            }
        }
        public static long GetDigit(byte[] bytes, params ushort[] bits)
        {
            long d = 0;
            int length = Math.Min(sizeof(long) << 3, bits.Length);
            for (int i = 0; i < length; ++i)
            {
                if (GetBit(bytes, bits[i])) d |= (1L << i);
            }
            return d;
        }
        public static void SetDigit<TDigit>(byte[] bytes, TDigit d, params ushort[] bits)
        {
            SetDigit(bytes, Convert.ToInt64(d), bits);
        }
        public static TDigit GetDigit<TDigit>(byte[] bytes, params ushort[] bits)
        {
            return ConvertExtends.ChangeType<TDigit>(GetDigit(bytes, bits));
        }
        #endregion
    }
}
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
        public static int GetHexLength(int count)
        {
            //count是点表里点位的数量，hexLength是十六进制的位数
            if (count > 1) --count;
            int hexLength = 0;
            while (count > 0)
            {
                count >>= 4;
                ++hexLength;
            }
            return hexLength;
        }
    }
}
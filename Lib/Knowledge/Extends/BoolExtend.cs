namespace Lib
{
    public static class BoolExtend
    {
        public static byte ToByte(this bool b)
        {
            return (byte)(b ? 1 : 0);
        }
        public static string ToByteString(this bool b)
        {
            return ToByte(b).ToString();
        }
    }
}
using System.IO;

namespace Lib
{
    public static class StreamExtend
    {
        public static byte[] ToBytes(this Stream stream)
        {
            int length = (int)stream.Length;
            byte[] bytes = new byte[length];
            stream.Read(bytes, 0, length);
            return bytes;
        }
    }
}
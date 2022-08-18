using System.IO;
using System.IO.Compression;

namespace Lib
{
    public static class CompressionExtends
    {
        public static byte[] Compress(byte[] bytes)
        {
            #region CA2202
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    using (DeflateStream ds = new DeflateStream(ms, CompressionMode.Compress))
            //    {
            //        ds.Write(bytes, 0, bytes.Length);
            //    }
            //    return ms.ToArray();
            //}
            #endregion
            MemoryStream ms = new MemoryStream();
            try
            {
                using (DeflateStream ds = new DeflateStream(ms, CompressionMode.Compress))
                {
                    ds.Write(bytes, 0, bytes.Length);
                }
                return ms.ToArray();
            }
            finally { IDisposableExtends.Dispose(ms); }
        }
        public static byte[] Decompress(byte[] bytes)
        {
            #region CA2202
            //using (MemoryStream ms = new MemoryStream(bytes))
            //{
            //    using (DeflateStream ds = new DeflateStream(ms, CompressionMode.Decompress))
            //    {
            //        using (MemoryStream resultMemoryStream = new MemoryStream())
            //        {
            //            ds.CopyTo(resultMemoryStream);
            //            return resultMemoryStream.ToArray();
            //        }
            //    }
            //}
            #endregion
            MemoryStream ms = new MemoryStream(bytes);
            try
            {
                using (DeflateStream ds = new DeflateStream(ms, CompressionMode.Decompress))
                {
                    using (MemoryStream resultMemoryStream = new MemoryStream())
                    {
                        ds.CopyTo(resultMemoryStream);
                        return resultMemoryStream.ToArray();
                    }
                }
            }
            finally { IDisposableExtends.Dispose(ms); }
        }
    }
}

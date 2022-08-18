using System.Text;

namespace Lib
{
    public static class Encodings
    {
        #region 不要BOM
        private static volatile Encoding utf8;
        private static volatile Encoding utf32;
        private static volatile Encoding unicode;
        private static volatile Encoding bigEndianUnicode;
        public static Encoding UTF8 { get { return utf8 ?? (utf8 = new UTF8Encoding(false)); } }
        public static Encoding UTF32 { get { return utf32 ?? (utf32 = new UTF32Encoding(false, false)); } }
        public static Encoding Unicode { get { return unicode ?? (unicode = new UnicodeEncoding(false, false)); } }
        public static Encoding BigEndianUnicode { get { return bigEndianUnicode ?? (bigEndianUnicode = new UnicodeEncoding(true, false)); } }
        #endregion
    }
}
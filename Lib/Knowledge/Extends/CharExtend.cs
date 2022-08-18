namespace Lib
{
    public static class CharExtend
    {
        public static bool IsAscii(this char ch)
        {
            return ch <= '\x007f';
        }
        public static bool Is_zh(this char ch)
        {
            ushort us = (ushort)ch;
            return 0x4e00<=us && us<=0x9fa5;
        }
        public static bool Is_ja(this char ch)
        {
            ushort us = (ushort)ch;
            return 0x3040 <= us && us <= 0x31ff;
        }
        public static bool Is_ko(this char ch)
        {
            ushort us = (ushort)ch;
            return 0x1100 <= us && us <= 0x11ff || 0xac00 <= us && us <= 0xd7af || 0x3130 <= us && us <= 0x318f;
        }
        public static bool Is_th(this char ch)
        {
            ushort us = (ushort)ch;
            return 0x0e00 <= us && us <= 0x0e7e;
        }
        public static bool IsDigit(this char ch)
        {
            return '0' <= ch && ch <= '9';
        }
        public static bool IsLowerLetter(this char ch)
        {
            return 'a' <= ch && ch <= 'z';
        }
        public static bool IsUpperLetter(this char ch)
        {
            return 'A' <= ch && ch <= 'Z';
        }
        public static bool IsLetter(this char ch)
        {
            return ch.IsLowerLetter() || ch.IsUpperLetter();
        }
        public static bool IsSimpleChar(this char ch)
        {
            return ch.IsDigit() || ch.IsLetter();
        }
        public static bool IsHexNumber(this char ch)
        {
            return ch.IsDigit() || 'A' <= ch && ch <= 'F' || 'a' <= ch && ch <= 'f';
        }
    }
}
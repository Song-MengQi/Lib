namespace Lib.UI
{
    public struct RGB
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public RGB(byte r, byte g, byte b) : this()
        {
            R = r;
            G = g;
            B = b;
        }
    }
}
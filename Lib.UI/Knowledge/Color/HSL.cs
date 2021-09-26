namespace Lib.UI
{
    public struct HSL
    {
        public double Hue { get; set; }
        public double Lightness { get; set; }
        public double Saturation { get; set; }
        public HSL(double hue, double lightness, double saturation) : this()
        {
            Hue = hue;
            Lightness = lightness;
            Saturation = saturation;
        }
    }
}

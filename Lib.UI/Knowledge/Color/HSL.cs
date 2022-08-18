namespace Lib.UI
{
    public struct HSL
    {
        public double H { get; set; }//Hue
        public double S { get; set; }//Saturation
        public double L { get; set; }//Lightness
        public HSL(double h, double s, double l)
            : this()
        {
            H = h;
            S = s;
            L = l;
        }
    }
}

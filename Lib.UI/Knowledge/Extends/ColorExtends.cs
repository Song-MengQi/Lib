using System.Windows.Media;

namespace Lib.UI
{
    public static class ColorExtends
    {
        public static RGB ColorToRGB(Color color) { return new RGB(color.R, color.G, color.B); }
        public static Color RGBToColor(RGB rgb) { return Color.FromRgb(rgb.R, rgb.G, rgb.B); }
        
        public static HSL RGBToHSL(RGB rgb)
        {
            HSL hsl = new HSL();
            byte max = MathExtends.Max(rgb.R, rgb.G, rgb.B);
            byte min = MathExtends.Min(rgb.R, rgb.G, rgb.B);
            double s = (max + min) / 255d;
            hsl.L = s / 2;
            if (max == min)
            {
                hsl.H = hsl.S = 0d;
            }
            else
            {
                double diff = max - min;
                hsl.S = diff / 255d / (s > 1 ? (2 - s) : s);
                if (max == rgb.R) hsl.H = (rgb.G - rgb.B) / diff + (rgb.G < rgb.B ? 6d : 0d);
                else if (max == rgb.G) hsl.H = (rgb.B - rgb.R) / diff + 2d;
                else if (max == rgb.B) hsl.H = (rgb.R - rgb.G) / diff + 4d;
                //hsl.H /= 6d;
                hsl.H *= 60d;
            }
            return hsl;
        }
        public static RGB HSLToRGB(HSL hsl)
        {
            double h = hsl.H/360d;
            RGB rgb = new RGB();
            if (0d == hsl.S)
            {
                rgb.R = rgb.G = rgb.B = (byte)(hsl.L * 255);
            }
            else
            {
                double q = hsl.L < 0.5
                    ? hsl.L * (1 + hsl.S)
                    : (hsl.L + hsl.S - hsl.L * hsl.S);
                double p = 2d * hsl.L - q;
                rgb.R = (byte)(HueToRGB(p, q, h + 1d / 3d) * 255);
                rgb.G = (byte)(HueToRGB(p, q, h) * 255);
                rgb.B = (byte)(HueToRGB(p, q, h - 1d / 3d) * 255);
            }
            return rgb;
        }
        private static double HueToRGB(double p, double q, double t)
        {
            if (t < 0d) t += 1d;
            if (t > 1d) t -= 1d;
            if (t * 6d < 1d) return p + (q - p) * 6d * t;
            if (t * 2d < 1d) return q;
            if (t * 3d < 2d) return p + (q - p) * 6d * (2d / 3d - t);
            return p;
        }
    }
}

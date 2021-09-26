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
            hsl.Lightness = s / 2;
            if (max == min)
            {
                hsl.Hue = hsl.Saturation = 0d;
            }
            else
            {
                double diff = max - min;
                hsl.Saturation = diff / 255d / (s > 1 ? (2 - s) : s);
                if (max == rgb.R) hsl.Hue = (rgb.G - rgb.B) / diff + (rgb.G < rgb.B ? 6d : 0d);
                else if (max == rgb.G) hsl.Hue = (rgb.B - rgb.R) / diff + 2d;
                else if (max == rgb.B) hsl.Hue = (rgb.R - rgb.G) / diff + 4d;
                hsl.Hue /= 6d;
            }
            return hsl;
        }
        public static RGB HSLToRGB(HSL hsl)
        {
            RGB rgb = new RGB();
            if (0d == hsl.Saturation)
            {
                rgb.R = rgb.G = rgb.B = (byte)(hsl.Lightness * 255);
            }
            else
            {
                double q = hsl.Lightness < 0.5
                    ? hsl.Lightness * (1 + hsl.Saturation)
                    : (hsl.Lightness + hsl.Saturation - hsl.Lightness * hsl.Saturation);
                double p = 2d * hsl.Lightness - q;
                rgb.R = (byte)(HueToRGB(p, q, hsl.Hue + 1d / 3d) * 255);
                rgb.G = (byte)(HueToRGB(p, q, hsl.Hue) * 255);
                rgb.B = (byte)(HueToRGB(p, q, hsl.Hue - 1d / 3d) * 255);
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

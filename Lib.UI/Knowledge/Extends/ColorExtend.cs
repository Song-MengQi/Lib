using System;
using System.Windows.Media;

namespace Lib.UI
{
    public static class ColorExtend
    {
        public static HSL ColorToHSL(Color color)
        {
            return ColorExtends.RGBToHSL(ColorExtends.ColorToRGB(color));
        }
        public static Color HSLToColor(HSL hsl)
        {
            return ColorExtends.RGBToColor(ColorExtends.HSLToRGB(hsl));
        }
        public static Color Transform(this Color color, Func<HSL, HSL> func)
        {
            return HSLToColor(func(ColorToHSL(color)));
        }
        public static Color Saturate(this Color color, double saturation)
        {
            return color.Transform(hsl=>hsl.Saturate(saturation));
        }
        public static Color Desaturate(this Color color, double saturation)
        {
            return color.Transform(hsl=>hsl.Desaturate(saturation));
        }
        public static Color Lighten(this Color color, double lightness)
        {
            return color.Transform(hsl=>hsl.Lighten(lightness));
        }
        public static Color Darken(this Color color, double lightness)
        {
            return color.Transform(hsl=>hsl.Darken(lightness));
        }
        public static Color Deepen(this Color color, double saturation, double lightness)
        {
            return color.Transform(hsl=>hsl.Desaturate(saturation).Darken(lightness));
        }
        public static Color Shallow(this Color color, double saturation, double lightness)
        {
            return color.Transform(hsl => hsl.Lighten(saturation).Saturate(lightness));
        }
    }
}
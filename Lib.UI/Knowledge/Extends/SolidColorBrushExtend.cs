using System.Windows.Media;

namespace Lib.UI
{
    public static class SolidColorBrushExtend
    {
        public static SolidColorBrush Saturate(this SolidColorBrush solidColorBrush, double saturation)
        {
            return new SolidColorBrush(solidColorBrush.Color.Saturate(saturation));
        }
        public static SolidColorBrush Desaturate(this SolidColorBrush solidColorBrush, double saturation)
        {
            return new SolidColorBrush(solidColorBrush.Color.Desaturate(saturation));
        }
        public static SolidColorBrush Lighten(this SolidColorBrush solidColorBrush, double lightness)
        {
            return new SolidColorBrush(solidColorBrush.Color.Lighten(lightness));
        }
        public static SolidColorBrush Darken(this SolidColorBrush solidColorBrush, double lightness)
        {
            return new SolidColorBrush(solidColorBrush.Color.Darken(lightness));
        }
        public static SolidColorBrush Deepen(this SolidColorBrush solidColorBrush, double saturation, double lightness)
        {
            return new SolidColorBrush(solidColorBrush.Color.Deepen(saturation, lightness));
        }
        public static SolidColorBrush Shallow(this SolidColorBrush solidColorBrush, double saturation, double lightness)
        {
            return new SolidColorBrush(solidColorBrush.Color.Shallow(saturation, lightness));
        }
    }
}
namespace Lib.UI
{
    public static class HSLExtend
    {
        private static double JustifySaturation(double amount)
        {
            if (amount < 0d) return 0d;
            if (amount > 1d) return 1d;
            return amount;
        }
        public static HSL Saturate(this HSL hsl, double amount)
        {
            hsl.S = JustifySaturation(hsl.S + amount);
            return hsl;
        }
        public static HSL Desaturate(this HSL hsl, double amount)
        {
            hsl.S = JustifySaturation(hsl.S - amount);
            return hsl;
        }
        private static double JustifyLightness(double amount)
        {
            if (amount < 0d) return 0d;
            if (amount > 1d) return 1d;
            return amount;
        }
        public static HSL Lighten(this HSL hsl, double amount)
        {
            hsl.L = JustifyLightness(hsl.L + amount);
            return hsl;
        }
        public static HSL Darken(this HSL hsl, double amount)
        {
            hsl.L = JustifyLightness(hsl.L - amount);
            return hsl;
        }
    }
}

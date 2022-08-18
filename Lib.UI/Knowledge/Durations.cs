using System;
using System.Windows;
using System.Windows.Controls;

namespace Lib.UI
{
    public static class Durations
    {
        public static readonly Duration Zero = new Duration(TimeSpan.Zero);
        public static readonly Duration XS = new Duration(TimeSpan.FromSeconds(0.2d));
        public static readonly Duration S = new Duration(TimeSpan.FromSeconds(0.4d));
        public static readonly Duration M = new Duration(TimeSpan.FromSeconds(0.8d));
        public static readonly Duration L = new Duration(TimeSpan.FromSeconds(1.6d));
        public static readonly Duration XL = new Duration(TimeSpan.FromSeconds(3.2d));
    }
}
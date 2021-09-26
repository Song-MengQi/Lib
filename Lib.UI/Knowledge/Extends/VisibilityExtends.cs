using System.Windows;

namespace Lib.UI
{
    public static class VisibilityExtends
    {
        public static Visibility VisibleOrCollapsed(bool isVisible)
        {
            return isVisible ? Visibility.Visible : Visibility.Collapsed;
        }
        public static Visibility VisibleOrHidden(bool isVisible)
        {
            return isVisible ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
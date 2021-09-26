using System.Windows;

namespace Lib.UI
{
    public static class StyleExtends
    {
        public static Style GetButtonStyle(bool isActive)
        {
            return Application.Current.FindResource(isActive ? "btn-primary" : "btn-default") as Style;
        }
    }
}
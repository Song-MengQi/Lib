using System.Reflection;

namespace Lib.UI
{
    public static class IconExtend
    {
        public static string GetValueString(this Icon icon)
        {
            return typeof(Icon).GetField(icon.ToString())
                .GetCustomAttribute<IconAttribute>()
                .Value
                .ToString();
        }
    }
}
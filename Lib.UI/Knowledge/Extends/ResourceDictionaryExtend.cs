using System.Windows;

namespace Lib.UI
{
    public static class ResourceDictionaryExtend
    {
        public static void Add(this ResourceDictionary resources, Style style) { resources.Add(style.TargetType, style); }
    }
}

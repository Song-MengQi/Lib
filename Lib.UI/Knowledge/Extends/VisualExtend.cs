using System.Windows.Media;

namespace Lib.UI
{
    public static class VisualExtend
    {
        public static T GetVisualChild<T>(this Visual parent) where T : Visual
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                T child = ObjectExtends.DefaultThen(v as T, ()=>GetVisualChild<T>(v));
                if (ObjectExtends.NotEqualsDefault(child)) return child;
            }
            return default(T);
        }
    }
}
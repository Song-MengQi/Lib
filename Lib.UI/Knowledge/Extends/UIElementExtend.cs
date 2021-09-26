using System.Windows;
using System.Windows.Media.Animation;

namespace Lib.UI
{
    public static class UIElementExtend
    {
        public static void ApplyAnimationClock(this UIElement uiElement, DependencyProperty dp, AnimationTimeline timeline)
        {
            uiElement.ApplyAnimationClock(dp, timeline.CreateClock());
        }
    }
}
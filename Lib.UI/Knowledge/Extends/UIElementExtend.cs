using System.Windows;
using System.Windows.Media.Animation;

namespace Lib.UI
{
    public static class UIElementExtend
    {
        //public static void LoadViewFromUri(this UIElement uiElement, string baseUri)
        //{
        //    Uri uri = new Uri(baseUri, UriKind.Relative);
        //    typeof(XamlReader)
        //        .GetMethod("LoadBaml", BindingFlags.NonPublic | BindingFlags.Static)
        //        .Invoke(null, new object[] {
        //            ((PackagePart)typeof(Application).GetMethod("GetResourceOrContentPart", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, new object[] { uri })).GetStream(),
        //            new ParserContext {
        //                BaseUri = new Uri((Uri)typeof(BaseUriHelper).GetProperty("PackAppBaseUri", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null, null), uri)
        //            },
        //            uiElement,
        //            true
        //        });
        //}
        public static void ApplyAnimationClock(this UIElement uiElement, DependencyProperty dp, AnimationTimeline timeline)
        {
            uiElement.ApplyAnimationClock(dp, timeline.CreateClock());
        }
    }
}
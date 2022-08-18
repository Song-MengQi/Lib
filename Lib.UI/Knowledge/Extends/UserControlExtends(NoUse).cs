//using System;
//using System.IO.Packaging;
//using System.Reflection;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Markup;
//using System.Windows.Navigation;

//namespace Lib.UI
//{
//    public static class UserControlExtends
//    {
//        public static void LoadViewFromUri(this UserControl userControl, string baseUri)
//        {
//            Uri resourceLocater = new Uri(baseUri, UriKind.Relative);
//            typeof(XamlReader).GetMethod("LoadBaml", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, new object[] {
//                ((PackagePart)typeof(Application).GetMethod("GetResourceOrContentPart", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, new object[] { resourceLocater })).GetStream(),
//                new ParserContext {
//                    BaseUri = new Uri((Uri)typeof(BaseUriHelper).GetProperty("PackAppBaseUri", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null, null), resourceLocater)
//                },
//                userControl,
//                true
//            });
//        }
//    }
//}
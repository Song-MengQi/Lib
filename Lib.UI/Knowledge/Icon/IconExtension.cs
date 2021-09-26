using System;
using System.Windows.Markup;

namespace Lib.UI
{
    public class IconExtension : MarkupExtension
    {
        public Icon Icon { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Icon.GetValueString();
        }
    }
}
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Lib.UI
{
    public class LanguageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return XmlLanguage.GetLanguage(value as string);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as XmlLanguage).IetfLanguageTag;
        }
    }
}
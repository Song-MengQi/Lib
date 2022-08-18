using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Lib.UI
{
    public class SumConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double p;
            double.TryParse(parameter as string, out p);
            return values.Select(value=>(double)value).Sum() + p;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            //不能反推
            return default(object[]);
        }
    }
}

using System.Globalization;
using System.Windows.Controls;

namespace Lib.UI
{
    public class SimpleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace(value as string) || false == StringExtends.AllSimpleChar(value as string)
                ? new ValidationResult(false, default(object))
                : ValidationResult.ValidResult;
        }
    }
}
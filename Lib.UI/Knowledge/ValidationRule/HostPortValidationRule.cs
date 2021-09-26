using System.Globalization;
using System.Windows.Controls;

namespace Lib.UI
{
    public class HostPortValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = value as string;
            if (default(string) == str) return new ValidationResult(false, default(object));

            string[] strs = str.Split(':');
            if (2 != strs.Length) return new ValidationResult(false, default(object));

            string host = strs[0].Replace(".", "");
            if (string.IsNullOrWhiteSpace(host) || false == StringExtends.AllSimpleChar(host)) return new ValidationResult(false, default(object));

            string port = strs[1];
            return port.IsUshort()
                ? ValidationResult.ValidResult
                : new ValidationResult(false, default(object));
        }
    }
}
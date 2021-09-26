using System.Globalization;
using System.Windows.Controls;

namespace Lib.UI
{
    public class RangeValidationRule : ValidationRule
    {
        public double Min { get; set; }
        public double Max { get; set; }
        public RangeValidationRule() : base()
        {
            Min = double.MinValue;
            Max = double.MaxValue;
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double number;
            if (false == double.TryParse(value as string, out number))
            {
                return new ValidationResult(false, default(object));
            }
            if (number > Max || number < Min)
            {
                //string.Format("Value should between [{0}, {1}]", Min, Max)
                return new ValidationResult(false, default(object));
            }
            return ValidationResult.ValidResult;
        }
    }
}
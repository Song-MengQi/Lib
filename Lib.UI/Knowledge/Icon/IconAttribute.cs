using System;

namespace Lib.UI
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class IconAttribute : Attribute
    {
        public char Value { get; private set; }
        public IconAttribute(char value)
        {
            Value = value;
        }
    }
}
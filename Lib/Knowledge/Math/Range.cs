using System;

namespace Lib
{
    public class Range<T>
        where T : IComparable<T>
    {
        public T Min { get; set; }
        public T Max { get; set; }
        public Range() { }
        public Range(T min, T max)
        {
            Min = min;
            Max = max;
        }
    }
}
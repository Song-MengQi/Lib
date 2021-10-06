using System;

namespace Lib.Timer
{
    public struct ObjectTicks<T>
    {
        public T Object { get; set; }
        public long Ticks { get; set; }
        public ObjectTicks(T t) : this()
        {
            Object = t;
            Ticks = DateTime.Now.Ticks;
        }
    }
}
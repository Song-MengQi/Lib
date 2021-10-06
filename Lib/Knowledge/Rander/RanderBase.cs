using System;

namespace Lib
{
    public abstract class RanderBase<T> : IRander<T>
    {
        protected static readonly Random random = new Random();
        public abstract T Next();
    }
}

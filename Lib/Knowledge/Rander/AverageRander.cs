namespace Lib
{
    public class AverageRander<T> : RanderBase<T>
    {
        private T[] ts;
        public AverageRander(T[] items)
        {
            ts = items;
        }
        public override T Next()
        {
            return ts[random.Next(ts.Length)];
        }
    }
}
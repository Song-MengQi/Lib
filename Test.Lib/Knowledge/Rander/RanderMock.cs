using Lib;

namespace Test.Lib
{
    public class RanderMock<T> : MockBase, IRander<T>
    {
        public T Next() { return GetValue<T>(); }
    }
}

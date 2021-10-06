
namespace Lib
{
    public static class IoCManagerExtend
    {
        public static string GetKey<T>(this T t)
        {
            return IoCManager<T>.GetKey(t);
        }
    }
}
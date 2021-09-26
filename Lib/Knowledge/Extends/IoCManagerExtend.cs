
namespace Lib
{
    public static class IoCManagerExtend
    {
        public static string GetKey<T>(this T t)
            where T : class
        {
            return IoCManager<T>.GetKey(t);
        }
    }
}
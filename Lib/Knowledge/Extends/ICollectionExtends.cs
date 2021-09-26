using System.Collections;

namespace Lib
{
    public static class ICollectionExtends
    {
        public static bool IsNullOrEmpty(ICollection collection)
        {
            return default(ICollection) == collection || 0 == collection.Count;
        }
        //public static bool IsNullOrEmpty<T>(ICollection<T> collection)
        //{
        //    return default(ICollection<T>) == collection || 0 == collection.Count;
        //}
    }
}
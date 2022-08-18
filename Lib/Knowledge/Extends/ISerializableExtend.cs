using System.Threading.Tasks;

namespace Lib
{
    public static class ISerializableExtend
    {
        #region Wait For Done
        public static void Wait(this ISerializable serializable)
        {
            serializable.Invoke(()=>{});
        }
        public static Task WaitAsync(this ISerializable serializable)
        {
            return serializable.InvokeAsync(()=>{});
        }
        #endregion
    }
}
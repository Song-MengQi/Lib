
namespace Lib
{
    public static class ILockableExtend
    {
        #region Wait For Done
        public static void Wait(this ILockable lockable)
        {
            lockable.Invoke(()=>{});
        }
        #endregion
    }
}
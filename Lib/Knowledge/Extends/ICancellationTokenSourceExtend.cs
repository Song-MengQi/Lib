
namespace Lib
{
    public static class ICancellationTokenSourceExtend
    {
        public static void CancelAndReset(this ICancellationTokenSource cancellationTokenSource)
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Reset();
        }
    }
}
using System.Threading;

namespace Lib
{
    public interface ICancellationTokenSource
    {
        bool IsCancellationRequested { get; }
        CancellationToken Token { get; }
        void Reset();
        void Cancel();
    }
}
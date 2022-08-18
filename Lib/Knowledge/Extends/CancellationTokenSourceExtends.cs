using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lib
{
    public static class CancellationTokenSourceExtends
    {
        public static void Invoke(TimeSpan timeout, Action<CancellationToken> action)
        {
            System.Threading.CancellationTokenSource cancellationTokenSource = new System.Threading.CancellationTokenSource(timeout);
            action(cancellationTokenSource.Token);
            cancellationTokenSource.Dispose();
        }
        public static void Invoke(int timeout, Action<CancellationToken> action)
        {
            Invoke(TimeSpan.FromMilliseconds(timeout), action);
        }
        public static T Invoke<T>(TimeSpan timeout, Func<CancellationToken, T> func)
        {
            T t = default(T);
            Invoke(timeout, token=>{ t = func(token); });
            return t;
        }
        public static T Invoke<T>(int timeout, Func<CancellationToken, T> func)
        {
            return Invoke(TimeSpan.FromMilliseconds(timeout), func);
        }
        public static TTask InvokeAsync<TTask>(TimeSpan timeout, Func<CancellationToken, TTask> func)
            where TTask : Task
        {
            System.Threading.CancellationTokenSource cancellationTokenSource = new System.Threading.CancellationTokenSource(timeout);
            TTask task = func(cancellationTokenSource.Token);
            task.ContinueWith(t=>cancellationTokenSource.Dispose());
            return task;
        }
        public static TTask InvokeAsync<TTask>(int timeout, Func<CancellationToken, TTask> func)
            where TTask : Task
        {
            return InvokeAsync(TimeSpan.FromMilliseconds(timeout), func);
        }
    }
}

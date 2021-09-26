using System;

namespace Lib
{
    public static class IDisposableExtends
    {
        public static void Dispose(IDisposable disposable)
        {
            if (default(IDisposable) != disposable) disposable.Dispose();
        }
        public static void Dispose(object obj)
        {
            if (obj is IDisposable) (obj as IDisposable).Dispose();
        }
    }
}
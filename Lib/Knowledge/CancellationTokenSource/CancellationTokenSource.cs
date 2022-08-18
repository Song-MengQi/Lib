using System;
using System.Threading;

namespace Lib
{
    public class CancellationTokenSource : ICancellationTokenSource, IDisposable
    {
        private readonly ILockable lockable = new Lockable();
        private System.Threading.CancellationTokenSource cancellationTokenSource = new System.Threading.CancellationTokenSource();
        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                cancellationTokenSource.Dispose();
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        public bool IsCancellationRequested { get { return lockable.Invoke(()=>cancellationTokenSource.IsCancellationRequested); } }
        public CancellationToken Token { get { return lockable.Invoke(()=>cancellationTokenSource.Token); } }
        public void Reset()
        {
            lockable.Invoke(()=>{
                cancellationTokenSource.Dispose();
                cancellationTokenSource = new System.Threading.CancellationTokenSource();
            });
        }
        public void Cancel()
        {
            lockable.Invoke(()=>cancellationTokenSource.Cancel());
        }
    }
}
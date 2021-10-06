using System;

namespace Lib.Timer
{
    public class TimingRefresher<T> : RefresherBase<T>, ITimingRefresher<T>, IDisposable
    {
        private ulong key;
        private uint period;
        public uint Period
        {
            get { return period; }
            set
            {
                if (period != value)
                {
                    period = value;
                    TotalTimerExtends.UnRegisterRepeat(ref key);
                    if (period > 0u)
                    {
                        TotalTimerExtends.RegisterRepeat(ref key, Refresh, Period);
                    }
                }
            }
        }
        public TimingRefresher(Func<T> getFunc, uint period = 60)
            : base(getFunc)
        {
            t = GetFunc();
            Period = period;
        }
        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                TotalTimerExtends.UnRegisterRepeat(ref key);
            }
        }
        #endregion
    }
}
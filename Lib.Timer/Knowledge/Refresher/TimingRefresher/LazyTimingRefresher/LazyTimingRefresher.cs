using System;

namespace Lib.Timer
{
    public class LazyTimingRefresher<T> : RefresherBase<T>, ILazyTimingRefresher<T>
    {
        protected long ticks = 0L;
        protected long Duration { get { return Period * Config.Instance.PeriodDuration.Ticks; } }
        protected long Deadline { get { return ticks + Duration; } }
        public uint Period { get; set; }
        private bool hasValue = false;
        private readonly ILockable lockable = new Lockable();
        public LazyTimingRefresher(Func<T> getFunc, uint period = 60)
            : base(getFunc)
        {
            Period = period;
        }
        public override void Refresh()
        {
            base.Refresh();
            ticks = DateTime.Now.Ticks;
            hasValue = true;
        }
        public override T Get()
        {
            #region EqualsDefault和HasValue不能混淆
            //if (Deadline < DateTime.Now.Ticks || ObjectExtends.EqualsDefault(t)) Refresh();
            #endregion
            lockable.Invoke(()=>{
                if (Deadline < DateTime.Now.Ticks || false == hasValue) Refresh();
            });
            return base.Get();
        }
    }
}

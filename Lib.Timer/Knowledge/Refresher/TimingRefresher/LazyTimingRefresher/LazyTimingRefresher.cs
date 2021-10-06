using System;

namespace Lib.Timer
{
    public class LazyTimingRefresher<T> : RefresherBase<T>, ILazyTimingRefresher<T>
    {
        protected long ticks = 0L;
        protected long Duration { get { return Period * Config.Instance.PeriodDuration.Ticks; } }
        protected long Deadline { get { return ticks + Duration; } }
        public uint Period { get; set; }
        public LazyTimingRefresher(Func<T> getFunc, uint period = 60)
            : base(getFunc)
        {
            Period = period;
        }
        public override void Refresh()
        {
            base.Refresh();
            ticks = DateTime.Now.Ticks;
        }
        public override T Get()
        {
            if (Deadline < DateTime.Now.Ticks || ObjectExtends.EqualsDefault(t)) Refresh();
            return base.Get();
        }
    }
}

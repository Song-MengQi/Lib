using System;

namespace Lib.Timer
{
    public class TimingAction
    {
        public Action Action { get; private set; }
        public uint Period { get; private set; }
        private uint now;
        public TimingAction(Action action, uint period)
        {
            this.Action = action;
            Period = period;
            now = 0u;
        }
        //返回是否执行了
        public bool Act()
        {
            if (0u == Period) return false;//0==Period，永不执行

            ++now;
            if (now < Period) return false;
            now = 0u;

            TryExtends.Try(Action);
            return true;
        }
    }
}
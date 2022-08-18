using System;

namespace Lib.Timer
{
    public static class TotalTimerExtends
    {
        private static readonly object lockable = new object();//全局锁
        public static void RegisterRepeat(ref ulong key, Action action, uint period)
        {
            lock (lockable)
            {
                if (0ul != key) return;
                key = TotalTimer.Instance.RegisterRepeat(action, period);
            }
        }
        public static void RegisterOnce(ref ulong key, Action action, uint period)
        {
            lock (lockable)
            {
                if (0ul != key) return;
                key = TotalTimer.Instance.RegisterOnce(action, period);
            }
        }
        public static void UnRegisterRepeat(ref ulong key)
        {
            lock (lockable)
            {
                if (0ul == key) return;
                TotalTimer.Instance.UnRegisterRepeat(key);
                key = 0ul;
            }
        }
        public static void UnRegisterOnce(ref ulong key)
        {
            lock (lockable)
            {
                if (0ul == key) return;
                TotalTimer.Instance.UnRegisterOnce(key);
                key = 0ul;
            }
        }

        #region When
        //一、周期=>Repeat
        //二、条件=>action里加condition，period只是检查周期
        //三、周期&条件<=>Repeat，action里加condition
        //四、周期&条件，条件与当前时间有关（比方说指定了时分秒）=>Repeat，action里加condition，condition里判断now<=>RegisterWhen
        //五、周期&条件，条件与上次时间有关（比方说冷却时间）=>Repeat，action里加condition，condition里判断lastDateTime（需要记录）<=>RegisterWhenLast
        //六、周期&条件，条件与当前时间和上次时间都有关（比方说相邻的两次周期都命中了指定时分，但希望有冷却间隔）=>Repeat，action里加condition，condition里判断lastDateTime（需要记录）、now<=>RegisterWhen
        //【四】
        public static void RegisterWhen(ref ulong key, Action action, uint period, Func<DateTime, bool> conditionFunc)
        {
            RegisterRepeat(ref key, ()=>{
                if (false==conditionFunc(DateTime.Now)) return;
                action();
            }, period);
        }
        //再三考虑，限定TimingOptions相当于也限定了CoolingTime
        //public static void RegisterWhen(ref ulong key, Action action, uint period, TimingOptions timingOptions)
        //{
        //    RegisterWhen(ref key, action, period, now=>timingOptions.Meet(now));
        //}
        //【五】
        public static void RegisterWhenLast(ref ulong key, Action action, uint period, Func<DateTime, bool> conditionFunc)
        {
            DateTime lastDateTime = default(DateTime);//相当于DateTime.MinValue
            RegisterRepeat(ref key, ()=>{
                if (false==conditionFunc(lastDateTime)) return;
                lastDateTime = DateTime.Now;
                action();
            }, period);
        }
        //【六】
        public static void RegisterWhen(ref ulong key, Action action, uint period, Func<DateTime, DateTime, bool> conditionFunc)
        {
            DateTime lastDateTime = default(DateTime);//相当于DateTime.MinValue
            RegisterRepeat(ref key, ()=>{
                DateTime now = DateTime.Now;
                if (false==conditionFunc(lastDateTime, now)) return;
                lastDateTime = now;
                action();
            }, period);
        }
        //限定了TimingOptions，也限定了CoolingTime和Period
        //既不能在相邻的两个检查周期重入=>CoolingTime
        //也不能错过任何一次=>Period
        public static void RegisterWhen(ref ulong key, Action action, TimingOptions timingOptions)
        {
            //coolingTime>>period>=Config.Instance.PeriodDuration
            TimeSpan coolingTime = timingOptions.GetCoolingTime();
            TimeSpan period = timingOptions.GetPeriod();
            TimeSpan dt = coolingTime - period;
            RegisterWhen(ref key,
                action,
                (uint)(period.TotalSeconds / Config.Instance.PeriodDuration.TotalSeconds),
                (last, now)=>timingOptions.Meet(now)&&now-last>dt);
        }
        #endregion
    }
}

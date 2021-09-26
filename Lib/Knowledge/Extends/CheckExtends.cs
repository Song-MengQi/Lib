using System;
using System.Threading;

namespace Lib
{
    public static class CheckExtends
    {
        public static void CheckWait(Func<bool> checkFunc, Action waitAction = default(Action))
        {
            while (false == checkFunc())
            {
                ActionExtends.Invoke(waitAction);
            }
        }
        public static bool CheckTimeout(Func<bool> checkFunc, int duration, Func<int, bool> waitFunc = default(Func<int, bool>))
        {
            #region Stopwatch计时法
            //if (checkFunc()) return true;
            //if (duration < 0) duration = int.MaxValue;
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //int gone = 0;
            //while (duration > gone)
            //{
            //    if (default(Func<int, bool>) == waitFunc || waitFunc(duration - gone))
            //    {
            //        if (checkFunc()) return true;
            //    }
            //    gone = (int)stopwatch.ElapsedMilliseconds;
            //}
            //return false;
            #endregion
            if (checkFunc()) return true;
            if (duration < 0) duration = int.MaxValue;
            while (duration > 0)
            {
                long start = DateTime.Now.GetMillisecond();
                if (default(Func<int, bool>) == waitFunc || waitFunc(duration))
                {
                    if (checkFunc()) return true;
                }
                duration -= (int)(DateTime.Now.GetMillisecond() - start);
            }
            return false;
        }
        
        public static void CheckWait(Func<bool> checkFunc, int period)
        {
            CheckWait(checkFunc, ()=>Thread.Sleep(period));
        }
        public static bool CheckTimeout(Func<bool> checkFunc, int duration, int period)
        {
            return CheckTimeout(checkFunc, duration, durationLeft=>{
                Thread.Sleep(Math.Min(period, durationLeft));
                return durationLeft >= period;
            });
        }

        public static void CheckWait(Func<bool> checkFunc, int period, Action<ManualResetEventSlim> setSlimAction)
        {
            if (default(Action<ManualResetEventSlim>) == setSlimAction)
            {
                CheckWait(checkFunc, period);
                return;
            }
            
            ManualResetEventSlim manualResetEventSlim = new ManualResetEventSlim();
            setSlimAction(manualResetEventSlim);
            CheckExtends.CheckWait(checkFunc, ()=>manualResetEventSlim.Wait(period));
            setSlimAction(default(ManualResetEventSlim));
        }
        public static bool CheckTimeout(Func<bool> checkFunc, int duration, int period, Action<ManualResetEventSlim> setSlimAction)
        {
            if (default(Action<ManualResetEventSlim>) == setSlimAction) return CheckTimeout(checkFunc, duration, period);

            ManualResetEventSlim manualResetEventSlim = new ManualResetEventSlim();
            setSlimAction(manualResetEventSlim);
            bool result = CheckExtends.CheckTimeout(checkFunc, duration, d=>{
                manualResetEventSlim.Wait(period);
                return true;
            });
            setSlimAction(default(ManualResetEventSlim));
            return result;
        }
    }
}
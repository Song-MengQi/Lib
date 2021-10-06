using System;

namespace Lib.Timer
{
    public class TotalTimerExtends
    {
        public static void RegisterRepeat(ref ulong key, Action action, uint period)
        {
            if (0ul != key) return;
            key = TotalTimer.Instance.RegisterRepeat(action, period);
        }
        public static void RegisterOnce(ref ulong key, Action action, uint period)
        {
            if (0ul != key) return;
            key = TotalTimer.Instance.RegisterOnce(action, period);
        }
        public static void UnRegisterRepeat(ref ulong key)
        {
            if (0ul == key) return;
            TotalTimer.Instance.UnRegisterRepeat(key);
            key = 0ul;
        }
        public static void UnRegisterOnce(ref ulong key)
        {
            if (0ul == key) return;
            TotalTimer.Instance.UnRegisterOnce(key);
            key = 0ul;
        }
    }
}

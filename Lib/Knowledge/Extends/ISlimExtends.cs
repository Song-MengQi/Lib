using System;
using System.Threading;

namespace Lib
{
    public static class ISlimExtends
    {
        public static void Arrival(this ISlim slim, Action dispatchAction = default(Action))
        {
            slim.Arrival(manualResetEventSlim=>manualResetEventSlim.Wait(), dispatchAction);
        }
        public static ManualResetEventSlim Add(this ISlim slim)
        {
            ManualResetEventSlim manualResetEventSlim = new ManualResetEventSlim(false);
            slim.Add(manualResetEventSlim);
            return manualResetEventSlim;
        }
        #region Version0 NoUse
        //public static bool AddResetWaitRemove(this ISlim slim, Func<ManualResetEventSlim, bool> waitFunc)
        //{
        //    ManualResetEventSlim manualResetEventSlim = slim.AddReset();
        //    bool result = FuncExtends.Invoke(waitFunc, manualResetEventSlim);
        //    slim.Remove(manualResetEventSlim);
        //    return result;
        //}
        //public static bool AddResetWaitRemove(this ISlim slim)
        //{
        //    return slim.AddResetWaitRemove(manualResetEventSlim=>{
        //        manualResetEventSlim.Wait();
        //        return true;
        //    });
        //}
        //public static bool AddResetWaitRemove(this ISlim slim, int millisecondsTimeout)
        //{
        //    return slim.AddResetWaitRemove(manualResetEventSlim=>manualResetEventSlim.Wait(millisecondsTimeout));
        //}
        //public static bool AddResetWaitRemove(this ISlim slim, TimeSpan timeout)
        //{
        //    return slim.AddResetWaitRemove(manualResetEventSlim=>manualResetEventSlim.Wait(timeout));
        //}
        #endregion
        #region Version1
        //public static void CheckWait(this ISlim slim, Func<bool> checkFunc, Action<ManualResetEventSlim> setSlimAction = default(Action<ManualResetEventSlim>))
        //{
        //    ManualResetEventSlim manualResetEventSlim = slim.AddSet();//为了防止遗漏在首次检查失败后等到结果，在首次检查之前就要加入等待
        //    ActionExtends.Invoke(setSlimAction, manualResetEventSlim);
        //    CheckExtends.CheckWait(() => {
        //        bool result = checkFunc();
        //        if (result)
        //        {
        //            ActionExtends.Invoke(setSlimAction, default(ManualResetEventSlim));//销毁之前告诉等待者
        //            slim.Remove(manualResetEventSlim);
        //        }
        //        else slim.Add(manualResetEventSlim);
        //        return result;
        //    }, manualResetEventSlim.Wait);
        //}
        //public static bool CheckTimeout(this ISlim slim, Func<bool> checkFunc, int duration, Action<ManualResetEventSlim> setSlimAction = default(Action<ManualResetEventSlim>))
        //{
        //    ManualResetEventSlim manualResetEventSlim = slim.AddSet();//为了防止遗漏在首次检查失败后等到结果，在首次检查之前就要加入等待
        //    ActionExtends.Invoke(setSlimAction, manualResetEventSlim);
        //    bool r = CheckExtends.CheckTimeout(() => {
        //        bool result = checkFunc();
        //        if (result)
        //        {
        //            ActionExtends.Invoke(setSlimAction, default(ManualResetEventSlim));
        //            slim.Remove(manualResetEventSlim);
        //        }
        //        else slim.Add(manualResetEventSlim);
        //        return result;
        //    }, duration, manualResetEventSlim.Wait);
        //    ActionExtends.Invoke(setSlimAction, default(ManualResetEventSlim));
        //    slim.Remove(manualResetEventSlim);
        //    return r;
        //}
        #endregion
        #region 检查不在锁里
        //为了防止Check(未成功)->Arrival->Add的情况，Check应该在锁里
        //private static bool Check(this ISlim slim, Func<bool> checkFunc, ManualResetEventSlim manualResetEventSlim)
        //{
        //    bool result = checkFunc();
        //    if (result) slim.Remove(manualResetEventSlim);
        //    else slim.Add(manualResetEventSlim);
        //    return result;
        //}
        #endregion
        #region 无用
        //提前加一个Set，是为了首次检查问题，但Receive与Check的时序却无法保证
        //顾此不带triggerFunc的方法仅用于持续性Receive的情况
        //public static void CheckWait(this ISlim slim, Func<bool> checkFunc, Action<ManualResetEventSlim> setSlimAction = default(Action<ManualResetEventSlim>))
        //{
        //    ManualResetEventSlim manualResetEventSlim = slim.Add();//为了防止遗漏在首次检查失败后等到结果，在首次检查之前就要加入等待
        //    ActionExtends.Invoke(setSlimAction, manualResetEventSlim);
        //    CheckExtends.CheckWait(()=>slim.Check(checkFunc, manualResetEventSlim), manualResetEventSlim.Wait);
        //    ActionExtends.Invoke(setSlimAction, default(ManualResetEventSlim));
        //}
        //public static bool CheckTimeout(this ISlim slim, Func<bool> checkFunc, int duration, Action<ManualResetEventSlim> setSlimAction = default(Action<ManualResetEventSlim>))
        //{
        //    ManualResetEventSlim manualResetEventSlim = slim.Add();//为了防止遗漏在首次检查失败后等到结果，在首次检查之前就要加入等待
        //    ActionExtends.Invoke(setSlimAction, manualResetEventSlim);
        //    bool result = CheckExtends.CheckTimeout(()=>slim.Check(checkFunc, manualResetEventSlim), duration, manualResetEventSlim.Wait);
        //    ActionExtends.Invoke(setSlimAction, default(ManualResetEventSlim));
        //    slim.Remove(manualResetEventSlim);
        //    return result;
        //}
        #endregion
        public static void CheckWait(this ISlim slim, Func<bool> checkFunc, Action<ManualResetEventSlim> setSlimAction = default(Action<ManualResetEventSlim>))
        {
            ManualResetEventSlim manualResetEventSlim = new ManualResetEventSlim();
            ActionExtends.Invoke(setSlimAction, manualResetEventSlim);
            CheckExtends.CheckWait(()=>slim.Check(checkFunc, manualResetEventSlim), manualResetEventSlim.Wait);
            ActionExtends.Invoke(setSlimAction, default(ManualResetEventSlim));
        }
        public static bool CheckTimeout(this ISlim slim, Func<bool> checkFunc, int duration, Action<ManualResetEventSlim> setSlimAction = default(Action<ManualResetEventSlim>))
        {
            ManualResetEventSlim manualResetEventSlim = new ManualResetEventSlim();
            ActionExtends.Invoke(setSlimAction, manualResetEventSlim);
            bool result = CheckExtends.CheckTimeout(()=>slim.Check(checkFunc, manualResetEventSlim), duration, manualResetEventSlim.Wait);
            ActionExtends.Invoke(setSlimAction, default(ManualResetEventSlim));
            slim.Remove(manualResetEventSlim);
            return result;
        }
        public static void CheckWait(this ISlim slim, Func<bool> triggerFunc, Func<bool> checkFunc, Action<ManualResetEventSlim> setSlimAction = default(Action<ManualResetEventSlim>))
        {
            ManualResetEventSlim manualResetEventSlim = slim.Add();//上来就开始等
            if (false == triggerFunc())//触发失败，永远等不到的
            {
                slim.Remove(manualResetEventSlim);
                return;
            }
            ActionExtends.Invoke(setSlimAction, manualResetEventSlim);
            CheckExtends.CheckWait(()=>slim.Check(checkFunc, manualResetEventSlim), manualResetEventSlim.Wait);
            ActionExtends.Invoke(setSlimAction, default(ManualResetEventSlim));
        }
        public static bool CheckTimeout(this ISlim slim, Func<bool> triggerFunc, Func<bool> checkFunc, int duration, Action<ManualResetEventSlim> setSlimAction = default(Action<ManualResetEventSlim>))
        {
            ManualResetEventSlim manualResetEventSlim = slim.Add();//上来就开始等
            if (false == triggerFunc())//触发失败，永远等不到的
            {
                slim.Remove(manualResetEventSlim);
                return false;
            }
            ActionExtends.Invoke(setSlimAction, manualResetEventSlim);
            bool result = CheckExtends.CheckTimeout(()=>slim.Check(checkFunc, manualResetEventSlim), duration, manualResetEventSlim.Wait);
            ActionExtends.Invoke(setSlimAction, default(ManualResetEventSlim));
            slim.Remove(manualResetEventSlim);
            return result;
        }
    }
}
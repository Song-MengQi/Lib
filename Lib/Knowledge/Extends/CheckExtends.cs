using System;
using System.Linq;
using System.Threading;

namespace Lib
{
    public static class CheckExtends
    {
        #region Checks
        public static int Check(bool b, int state)
        {
            return b ? ResultState.Success : state;
        }
        public static int CheckNot(bool b, int state)
        {
            return b ? state : ResultState.Success;
        }
        public static int Check<T>(T t, int state)
        {
            return CheckObject<T>(t, state);
        }
        public static int CheckObject<T>(T t, int state)
        {
            return CheckNot(ObjectExtends.EqualsDefault(t), state);
        }
        public static int CheckObjects<T>(T[] ts, int state)
        {
            return CheckNot(default(T[]) == ts || ts.Any(ObjectExtends.EqualsDefault), state);
        }
        public static int CheckString(string str, Func<string, bool> func, int state)
        {
            return Check(func(str), state);
        }
        public static int CheckStrings(string[] strs, Func<string, bool> func, int state)
        {
            return Check(default(string[]) != strs && strs.All(func), state);
        }
        public static int CheckStrings(string str, Func<string, bool> func, int state)
        {
            return CheckStrings(StringExtends.ToStrings(str), func, state);
        }
        //public static int CheckId(string id, int state)
        //{
        //    return CheckString(id, StringExtends.IsId, state);
        //}
        //public static int CheckId(string id)
        //{
        //    return CheckId(id, ResultState.IdInvalid);
        //}
        //public static int CheckIds(string ids, int state)
        //{
        //    return CheckStrings(ids, StringExtends.IsId, state);
        //}
        //public static int CheckIds(string ids)
        //{
        //    return CheckIds(ids, ResultState.IdsInvalid);
        //}
        //public static int CheckIds(string[] ids, int state)
        //{
        //    return CheckStrings(ids, StringExtends.IsId, state);
        //}
        //public static int CheckIds(string[] ids)
        //{
        //    return CheckIds(ids, ResultState.IdsInvalid);
        //}
        //public static int CheckPositiveId(string id, int state)
        //{
        //    return CheckString(id, StringExtends.IsPositiveId, state);
        //}
        //public static int CheckPositiveId(string id)
        //{
        //    return CheckPositiveId(id, ResultState.IdInvalid);
        //}
        //public static int CheckPositiveIds(string ids, int state)
        //{
        //    return CheckStrings(ids, StringExtends.IsPositiveId, state);
        //}
        //public static int CheckPositiveIds(string ids)
        //{
        //    return CheckPositiveIds(ids, ResultState.IdsInvalid);
        //}
        //public static int CheckPositiveIds(string[] ids, int state)
        //{
        //    return CheckStrings(ids, StringExtends.IsPositiveId, state);
        //}
        //public static int CheckPositiveIds(string[] ids)
        //{
        //    return CheckPositiveIds(ids, ResultState.IdsInvalid);
        //}

        //private static int checkPageId(string pageId)
        //{
        //    return CheckString(pageId, StringExtends.IsUint, ResultState.PageIdInvalid);
        //}
        //public static int CheckPageSize(string pageSize)
        //{
        //    return CheckString(pageSize, StringExtends.IsUint, ResultState.PageSizeInvalid);
        //}
        //public static int CheckPage(string pageId, string pageSize)
        //{
        //    return ResultExtends.Check(
        //        ()=>checkPageId(pageId),
        //        ()=>CheckPageSize(pageSize));
        //}
        public static int CheckEnum<TEnum>(string str, int state)
        {
            return CheckString(str, EnumExtends.IsDefined<TEnum>, state);
        }
        //public static int CheckTerminalType(string terminalType)
        //{
        //    return CheckEnum<TerminalType>(terminalType, ResultState.TerminalTypeInvalid);
        //}
        //public static int CheckDistrictCodes(string districtCodes)
        //{
        //    return CheckString(districtCodes, StringExtends.IsDistrictCodes, ResultState.DistrictCodesInvalid);
        //}
        //public static int CheckDateTime(string dateTimeString, ref string dateTimeFormatString)
        //{
        //    DateTime dateTime;
        //    if (DateTime.TryParse(dateTimeString, out dateTime))
        //    {
        //        dateTimeFormatString = dateTime.ToString(DateTimeExtends.DateTimeFormat);
        //        return ResultState.Success;
        //    }
        //    return ResultState.DateTimeInvalid;
        //}
        //public static int CheckDate(string dateString, ref string dateFormatString)
        //{
        //    DateTime dateTime;
        //    if (DateTime.TryParse(dateString, out dateTime))
        //    {
        //        dateFormatString = dateTime.ToString(DateTimeExtends.DateFormat);
        //        return ResultState.Success;
        //    }
        //    return ResultState.DateInvalid;
        //}
        #endregion
        public static int CheckNoRight()
        {
            return Check(PrincipalExtends.InAdministrator(), ResultState.NoRight);
        }
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

            using (ManualResetEventSlim manualResetEventSlim = new ManualResetEventSlim())
            {
                setSlimAction(manualResetEventSlim);
                CheckWait(checkFunc, ()=>manualResetEventSlim.Wait(period));
                setSlimAction(default(ManualResetEventSlim));
            }
        }
        public static bool CheckTimeout(Func<bool> checkFunc, int duration, int period, Action<ManualResetEventSlim> setSlimAction)
        {
            if (default(Action<ManualResetEventSlim>) == setSlimAction) return CheckTimeout(checkFunc, duration, period);

            using (ManualResetEventSlim manualResetEventSlim = new ManualResetEventSlim())
            {
                setSlimAction(manualResetEventSlim);
                bool result = CheckTimeout(checkFunc, duration, d=>{
                    manualResetEventSlim.Wait(period);
                    return true;
                });
                setSlimAction(default(ManualResetEventSlim));
                return result;
            }
        }
    }
}
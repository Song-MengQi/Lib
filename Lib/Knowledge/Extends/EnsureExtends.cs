using System;

namespace Lib
{
    public static class EnsureExtends
    {
        public static int Ensure(ref bool flag, Func<int> func)
        {
            //return flag
            //    ? ResultState.Success
            //    : ResultExtends.Check(
            //        func,
            //        ()=>{
            //            flag = true;
            //            return ResultState.Success;
            //        });
            if (flag) return ResultState.Success;
            int state = func();
            flag = ResultState.Success==state;
            return state;
        }
        public static int Ensure(ref State flag, Func<int> func)
        {
            if (State.Positive==flag) return ResultState.Success;
            int state = func();
            if (ResultState.Success==state) flag = State.Positive;
            return state;
        }
        public static int Ensure(Func<bool> getFlagFunc, Action setFlagAction, Func<int> func)
        {
            return getFlagFunc()
                ? ResultState.Success
                : ResultExtends.Check(
                    func,
                    ()=>{
                        setFlagAction();
                        return ResultState.Success;
                    });
        }
    }
}

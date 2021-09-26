using System;

namespace Lib
{
    public static class ResultExtend
    {
        public static T GetDataOrDefault<T>(this Result<T> result, T defaultData = default(T))
        {
            return ResultState.Success == result.State ? result.Data : defaultData;
        }
        public static T GetDataOrDefault<T>(this Result<T> result, Func<T> defaultDataFunc)
        {
            return ResultState.Success == result.State ? result.Data : FuncExtends.Invoke(defaultDataFunc);
        }

        public static State GetDataOrDefault(this Result<State> result)
        {
            return result.GetDataOrDefault(State.None);
        }
    }
}
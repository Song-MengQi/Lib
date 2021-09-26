using System;
using System.Threading.Tasks;

namespace Lib
{
    public static class TaskExtends
    {
        public static Task Run(Action action)
        {
            if (default(Action) == action) return RunEmpty();
            return Task.Run(action);
        }
        public static Task<T> Run<T>(Func<T> func)
        {
            if (default(Func<T>) == func) return RunEmpty<T>();
            return Task.Run(func);
        }
        public static Task RunLong(Action action)
        {
            if (default(Action) == action) return RunEmpty();
            Task task = new Task(action, TaskCreationOptions.LongRunning);
            task.Start();
            return task;
        }
        public static Task<T> RunLong<T>(Func<T> func)
        {
            if (default(Func<T>) == func) return RunEmpty<T>();
            Task<T> task = new Task<T>(func, TaskCreationOptions.LongRunning);
            task.Start();
            return task;
        }
        public static Task RunEmpty()
        {
            return Task.Run(() => { });
        }
        public static Task<T> RunEmpty<T>()
        {
            return Task.Run(() => default(T));
        }
        public static void Wait(Result<Task> result)
        {
            if (ResultState.Success == result.State) result.Data.Wait();
        }
        public static T Wait<T>(Result<Task<T>> result)
        {
            if (ResultState.Success == result.State) return result.Data.Result;
            return default(T);
        }
    }
}
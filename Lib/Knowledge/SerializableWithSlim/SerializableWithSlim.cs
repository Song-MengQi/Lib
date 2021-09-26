using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lib
{
    public class SerializableWithSlim : ISerializableWithSlim, IDisposable
    {
        protected readonly ISerializable serializable;
        protected readonly ManualResetEventSlim runSlim;
        public SerializableWithSlim()
        {
            serializable = new Serializable();
            runSlim = new ManualResetEventSlim(true);
        }
        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                runSlim.Dispose();
            }
        }
        #endregion
        public bool IsRunning { get { return serializable.IsRunning; } }
        public bool IsEmpty { get { return serializable.IsEmpty; } }
        public void Clear() { serializable.Clear(); }

        public void InvokeBackground(Action action)
        {
            serializable.InvokeBackground(action);
            serializable.InvokeBackground(runSlim.Wait);
        }
        #region 等到信号量才算完成
        //public Task InvokeAsync(Action action)
        //{
        //    serializable.InvokeBackground(action);
        //    return serializable.InvokeAsync(runSlim.Wait);
        //    //return task;
        //}
        //public void Invoke(Action action)
        //{
        //    serializable.Invoke(action);
        //    serializable.Invoke(runSlim.Wait);
        //}
        //public Task<T> InvokeAsync<T>(Func<T> func)
        //{
        //    Task<T> task = serializable.InvokeAsync(func);
        //    return serializable.InvokeAsync(runSlim.Wait).ContinueWith(t => task.Result);
        //}
        //public T Invoke<T>(Func<T> func)
        //{
        //    T t = serializable.Invoke(func);
        //    serializable.Invoke(runSlim.Wait);
        //    return t;
        //}
        #endregion
        #region 没等信号量就算完成 
        public Task InvokeAsync(Action action)
        {
            Task task = serializable.InvokeAsync(action);
            serializable.InvokeBackground(runSlim.Wait);
            return task;
        }
        public void Invoke(Action action)
        {
            serializable.Invoke(action);
            serializable.InvokeBackground(runSlim.Wait);
        }
        public Task<T> InvokeAsync<T>(Func<T> func)
        {
            Task<T> task = serializable.InvokeAsync(func);
            serializable.InvokeBackground(runSlim.Wait);
            return task;
        }
        public T Invoke<T>(Func<T> func)
        {
            T t = serializable.Invoke(func);
            serializable.InvokeBackground(runSlim.Wait);
            return t;
        }
        #endregion

        public void Pause()
        {
            runSlim.Reset();
        }
        public void Continue()
        {
            runSlim.Set();
        }
        public void Wait()
        {
            runSlim.Wait();
        }
    }
}
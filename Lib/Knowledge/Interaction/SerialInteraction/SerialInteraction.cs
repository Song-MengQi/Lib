using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lib
{
    public class SerialInteraction<TRequest, TResponse, TInternalRequest, TInternalResponse> : ISerialInteraction<TRequest, TResponse, TInternalRequest, TInternalResponse>, IDisposable
    {
        private readonly ISerializable serializable = new Serializable();
        private readonly AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        private TInternalResponse responseCache;
        public Func<TInternalRequest, int> SendFunc { get; set; }
        public Func<TRequest, TInternalRequest> RequestConvertFunc { get; set; }
        public Func<TInternalResponse, TResponse> ResponseConvertFunc { get; set; }
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
                autoResetEvent.Dispose();
            }
        }
        #endregion
        #region ArrivalArrival
        public void Arrive(TInternalResponse response)
        {
            responseCache = response;
            autoResetEvent.Set();
        }
        #endregion
        #region Send
        public Result Send(TRequest request)
        {
            TInternalRequest internalRequest = RequestConvertFunc(request);
            return new Result(serializable.Invoke(() => SendFunc(internalRequest)));
        }
        public Task<Result> SendAsync(TRequest request)
        {
            TInternalRequest internalRequest = RequestConvertFunc(request);
            return serializable.InvokeAsync(()=>SendFunc(internalRequest))
                .ContinueWith(task=>new Result(task.Result));
        }
        public void SendBackground(TRequest request)
        {
            TInternalRequest internalRequest = RequestConvertFunc(request);
            serializable.InvokeBackground(()=>SendFunc(internalRequest));
        }
        #endregion
        #region SendAndReceive
        private bool isAbort = false;
        private Result<TInternalResponse> SendAndReceiveDirectly(TInternalRequest internalRequest, int duration = -1)
        {
            autoResetEvent.Reset();
            isAbort = false;
            return ResultExtends.GetResult(
                ()=>SendFunc(internalRequest),
                ()=>CheckExtends.Check(autoResetEvent.WaitOne(duration), ResultState.Timeout),
                ()=>CheckExtends.CheckNot(isAbort, ResultState.Fail),
                ()=>responseCache);
        }

        public Result<TResponse> SendAndReceive(TRequest request, int duration = -1)
        {
            TInternalRequest internalRequest = RequestConvertFunc(request);
            Result<TInternalResponse> result = serializable.Invoke(() => SendAndReceiveDirectly(internalRequest, duration));
            return ResultExtends.GetResult(
                ()=>result.State,
                ()=>ResponseConvertFunc(result.Data));
        }
        public Task<Result<TResponse>> SendAndReceiveAsync(TRequest request, int duration = -1)
        {
            TInternalRequest internalRequest = RequestConvertFunc(request);
            return serializable.InvokeAsync(()=>SendAndReceiveDirectly(internalRequest, duration))
                .ContinueWith(task=>{
                    return ResultExtends.GetResult(
                        ()=>task.Result.State,
                        ()=>ResponseConvertFunc(task.Result.Data));
                });
        }
        #endregion
        public void Abort()
        {
            isAbort = true;
            Arrive(default(TInternalResponse));
        }
    }
    public class SerialInteraction<TRequest, TResponse> : SerialInteraction<TRequest, TResponse, TRequest, TResponse>, ISerialInteraction<TRequest, TResponse>
    {
        public SerialInteraction() : base()
        {
            RequestConvertFunc = request=>request;
            ResponseConvertFunc = response=>response;
        }
    }
}
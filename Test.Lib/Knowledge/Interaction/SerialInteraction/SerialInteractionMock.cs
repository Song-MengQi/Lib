using System;
using System.Threading.Tasks;
using Lib;

namespace Test.Lib
{
    public class SerialInteractionMock<TRequest, TResponse, TInternalRequest, TInternalResponse> : MockBase, ISerialInteraction<TRequest, TResponse, TInternalRequest, TInternalResponse>
    {
        public Func<TRequest, TInternalRequest> RequestConvertFunc { get; set; }//自己处理Default，也不管Try
        public Func<TInternalResponse, TResponse> ResponseConvertFunc { get; set; }//自己处理Default，也不管Try

        public Func<TInternalRequest, int> SendFunc { get; set; }
        public void Arrive(TInternalResponse response) { }


        #region 保证只有Send没有Receive才能调，否则将会造成混乱
        public Result Send(TRequest request) { return GetValue<Result>(); }
        public Task<Result> SendAsync(TRequest request) { return GetTaskValue<Result>(); }
        public void SendBackground(TRequest request) { }
        #endregion

        public Result<TResponse> SendAndReceive(TRequest request, int duration = -1) { return GetValue<Result<TResponse>>(); }
        public Task<Result<TResponse>> SendAndReceiveAsync(TRequest request, int duration = -1) { return GetTaskValue<Result<TResponse>>(); }

        public void Abort() { }
    }
}

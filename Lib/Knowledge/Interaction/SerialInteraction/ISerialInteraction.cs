using System;
using System.Threading.Tasks;

namespace Lib
{
    public interface ISerialInteraction<TRequest, TResponse, TInternalRequest, TInternalResponse>
    {
        Func<TRequest, TInternalRequest> RequestConvertFunc { get; set; }//自己处理Default，也不管Try
        Func<TInternalResponse, TResponse> ResponseConvertFunc { get; set; }//自己处理Default，也不管Try

        Func<TInternalRequest, int> SendFunc { get; set; }
        void Arrive(TInternalResponse response);


        #region 保证只有Send没有Receive才能调，否则将会造成混乱
        Result Send(TRequest request);
        Task<Result> SendAsync(TRequest request);
        void SendBackground(TRequest request);
        #endregion

        Result<TResponse> SendAndReceive(TRequest request, int duration = -1);
        Task<Result<TResponse>> SendAndReceiveAsync(TRequest request, int duration = -1);

        void Abort();
    }
    public interface ISerialInteraction<TRequest, TResponse> : ISerialInteraction<TRequest, TResponse, TRequest, TResponse>
    {
    }
}
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Lib.Server
{
    public static class Servers
    {
        public static string GetRequestHeader(string name, string defaultValue = default(string))
        {
            try { return WebOperationContext.Current.IncomingRequest.Headers.Get(name); }
            catch { }
            return defaultValue;
        }
        public static string GetClientIp() { return GetRequestHeader(WebHeaderKeys.XRealIP, "127.0.0.1"); }

        public static void SetResponseHeader(string name, string value)
        {
            try { WebOperationContext.Current.OutgoingResponse.Headers.Set(name, value); }
            catch { }
        }
        public static void SetContentType(string value)
        {
            SetResponseHeader(WebHeaderKeys.ContentType, value);
        }

        public static byte[] GetPostBody() { return OperationContext.Current.RequestContext.RequestMessage.GetBody<byte[]>(); }
        public static string GetPostString() { return StringExtends.BytesToString(GetPostBody()); }
        public static string GetQuery() { return OperationContext.Current.IncomingMessageHeaders.To.Query; }

        public static IT GetCallbackChannel<IT>()
        {
            //return ObjectExtends.DefaultThen(IoC<IT>.Instance, OperationContext.Current.GetCallbackChannel<IT>);
            return ObjectExtends.DefaultThen(IoC<IT>.Instance, ()=>OperationContext.Current.GetCallbackChannel<IT>());
        }
    }
}
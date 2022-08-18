using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Lib.Server
{
    public static class WebServerExtends
    {
        #region HttpHeaderAttribute
        public static readonly Dictionary<string, RequestHttpHeaderAttribute> RequestHttpHeaderAttributeDic = new Dictionary<string, RequestHttpHeaderAttribute>();
        public static readonly Dictionary<string, ResponseHttpHeaderAttribute> ResponseHttpHeaderAttributeDic = new Dictionary<string, ResponseHttpHeaderAttribute>();
        //private static readonly RequestHttpHeaderAttribute RequestHttpHeaderAttributeDefault = new RequestHttpHeaderAttribute();
        private static readonly ResponseHttpHeaderAttribute ResponseHttpHeaderAttributeDefault = new ResponseHttpHeaderAttribute();
        private static string GetHttpHeaderAttributeDicKey(string contractFullName, string operationName)
        {
            return string.Join(".", contractFullName, operationName);
        }
        public static void RegisterHttpHeaderAttribute(Type contractType)
        {
            MethodInfo[] methodInfos = contractType.GetMethods();//可继承
            foreach (MethodInfo methodInfo in methodInfos)
            {
                string key = GetHttpHeaderAttributeDicKey(contractType.FullName, methodInfo.Name);
                RequestHttpHeaderAttribute requestHttpHeaderAttribute;
                if (methodInfo.TryGetCustomAttribute(out requestHttpHeaderAttribute))
                {
                    WebServerExtends.RequestHttpHeaderAttributeDic[key] = requestHttpHeaderAttribute;
                }
                ResponseHttpHeaderAttribute responseHttpHeaderAttribute;
                if (methodInfo.TryGetCustomAttribute(out responseHttpHeaderAttribute))
                {
                    WebServerExtends.ResponseHttpHeaderAttributeDic[key] = responseHttpHeaderAttribute;
                }
            }
        }
        public static RequestHttpHeaderAttribute GetRequestHttpHeaderAttribute(string contractFullName, string operationName)
        {
            string key = GetHttpHeaderAttributeDicKey(contractFullName, operationName);

            RequestHttpHeaderAttribute requestHttpHeaderAttribute;
            if (RequestHttpHeaderAttributeDic.TryGetValue(key, out requestHttpHeaderAttribute)) return requestHttpHeaderAttribute;

            requestHttpHeaderAttribute = new RequestHttpHeaderAttribute();
            //string contentType = GetRequestHeader(HttpHeaderKeys.ContentType);
            //if (false == string.IsNullOrEmpty(contentType)) requestHttpHeaderAttribute.ContentType = contentType;
            requestHttpHeaderAttribute.ContentType = GetRequestHeader(HttpHeaderKeys.ContentType, requestHttpHeaderAttribute.ContentType);
            return requestHttpHeaderAttribute;
        }
        public static ResponseHttpHeaderAttribute GetResponseHttpHeaderAttribute(string contractFullName, string operationName)
        {
            string key = GetHttpHeaderAttributeDicKey(contractFullName, operationName);
            ResponseHttpHeaderAttribute responseHttpHeaderAttribute;
            return ResponseHttpHeaderAttributeDic.TryGetValue(key, out responseHttpHeaderAttribute)
                ? responseHttpHeaderAttribute
                : ResponseHttpHeaderAttributeDefault;//没有按照默认
        }
        #endregion
        public static string GetRequestHeader(string name, string defaultValue = default(string))
        {
            try { return WebOperationContext.Current.IncomingRequest.Headers.Get(name); }
            catch { return defaultValue; }
        }
        public static string GetClientIp()
        {
            return GetRequestHeader(HttpHeaderKeys.XRealIP, Values.LoopbackAddress);
        }

        public static void SetResponseHeader(string name, string value)
        {
            try { WebOperationContext.Current.OutgoingResponse.Headers.Set(name, value); }
            catch { }
        }
        public static void SetContentType(string value)
        {
            SetResponseHeader(HttpHeaderKeys.ContentType, value);
        }

        #region Version1
        //底层也是GetReaderAtBodyContents去读取，只不过还用了XmlObjectSerializer
        //public static byte[] GetPostBody() { return OperationContext.Current.RequestContext.RequestMessage.GetBody<byte[]>(); }
        //public static T GetPostBody<T>() { return OperationContext.Current.RequestContext.RequestMessage.GetBody<T>(); }//不要它，因为不想用XmlObjectSerializer
        #endregion
        public static byte[] GetPostBytes() { return OperationContext.Current.RequestContext.RequestMessage.GetBytes(); }
        public static string GetPostString() { return StringExtends.BytesToString(GetPostBytes()); }
        public static string GetQuery() { return OperationContext.Current.IncomingMessageHeaders.To.Query; }
    }
}
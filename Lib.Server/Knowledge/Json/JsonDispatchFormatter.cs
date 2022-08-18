using Lib.Json;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;

namespace Lib.Server
{
    public class JsonDispatchFormatter : IDispatchMessageFormatter
    {
        private const string UriTemplateMatchResults = "UriTemplateMatchResults";
        private bool IsGet
        {
            get
            {
                if (default(WebGetAttribute) != operationDescription.Behaviors.Find<WebGetAttribute>()) return true;
                WebInvokeAttribute webInvokeAttribute = operationDescription.Behaviors.Find<WebInvokeAttribute>();
                return default(WebInvokeAttribute) != webInvokeAttribute && "GET" == webInvokeAttribute.Method;
            }
        }
        //private string UriTemplateString
        //{
        //    get
        //    {
        //        string[] keys = operationDescription.Messages[0].Body.Parts.Select(messagePartDescription=>messagePartDescription.Name).ToArray();
        //        return StringExtends.ToQueryString(operationDescription.Name, keys, keys);
        //    }
        //}
        private readonly OperationDescription operationDescription;
        public JsonDispatchFormatter(OperationDescription operationDescription)
        {
            this.operationDescription = operationDescription;
        }
        private void DeserializeRequestGet(Message message, object[] parameters)
        {
            if (parameters.Length < 1) return;
            try
            {
                UriTemplateMatch uriTemplateMatch = message.Properties[UriTemplateMatchResults] as UriTemplateMatch;
                if (default(UriTemplateMatch) == uriTemplateMatch) return;

                NameValueCollection nameValueCollection = uriTemplateMatch.BoundVariables;
                operationDescription.Messages[0].Body.Parts.Foreach((part, i)=>{
                    parameters[i] = JsonExtends.Convert(nameValueCollection[part.Name], part.Type);
                });
            }
            catch { }
        }
        private void DeserializeRequestPost(Message message, object[] parameters)
        {
            //参数可能来自Url也可能来自Body，统一一下都来自Body
            if (parameters.Length != 1) return;//Post只认一个参数
            try
            {
                byte[] bytes = message.GetBytes();
                Type type = operationDescription.Messages[0].Body.Parts[0].Type;
                //【Data】请求参数是Stream或MemoryStream
                if (typeof(Stream).IsAssignableFrom(type) || typeof(MemoryStream).IsAssignableFrom(type))
                    parameters[0] = new MemoryStream(bytes);
                //【Data】请求参数是byte[]且RequestHttpHeaderAttribute.ContentType是ApplicationOctetStream
                else if (typeof(byte[])==type &&
                    ContentTypeValues.ApplicationOctetStream == WebServerExtends.GetRequestHttpHeaderAttribute(operationDescription.DeclaringContract.ContractType.FullName, operationDescription.Name).ContentType)
                    parameters[0] = bytes;
                else parameters[0] = JsonExtends.Deserialize(Encodings.UTF8.GetString(bytes), operationDescription.Messages[0].Body.Parts[0].Type);
            }
            catch { }
        }
        public void DeserializeRequest(Message message, object[] parameters)
        {
            if (IsGet) DeserializeRequestGet(message, parameters);
            else DeserializeRequestPost(message, parameters);
        }
        public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
        {
            //不管返回值是不是void，parameters都是空数组
            byte[] bytes;
            ResponseHttpHeaderAttribute responseHttpHeaderAttribute = WebServerExtends.GetResponseHttpHeaderAttribute(operationDescription.DeclaringContract.ContractType.FullName, operationDescription.Name);//不能为null
            //【Data】响应参数是Stream
            if (result is Stream) bytes = (result as Stream).ToBytes();
            //【Data】响应参数是byte[]且ResponseHttpHeaderAttribute.ContentType是ApplicationOctetStream
            else if (result is byte[] && ContentTypeValues.ApplicationOctetStream == responseHttpHeaderAttribute.ContentType) bytes = (result as byte[]);
            else bytes = Encodings.UTF8.GetBytes(JsonExtends.Serialize(result));//即使是null，也要写出来"null"

            Message message = Message.CreateMessage(messageVersion, operationDescription.Messages[1].Action, new RawBodyWriter(bytes));
            message.Properties.Add(WebBodyFormatMessageProperty.Name, new WebBodyFormatMessageProperty(WebContentFormat.Raw));

            HttpResponseMessageProperty httpResponseMessageProperty = new HttpResponseMessageProperty();
            if (false==string.IsNullOrEmpty(responseHttpHeaderAttribute.ContentType)) httpResponseMessageProperty.Headers[HttpResponseHeader.ContentType] = responseHttpHeaderAttribute.ContentType;
            if (false==string.IsNullOrEmpty(responseHttpHeaderAttribute.CacheControl)) httpResponseMessageProperty.Headers[HttpResponseHeader.CacheControl] = responseHttpHeaderAttribute.CacheControl;
            if (false==string.IsNullOrEmpty(responseHttpHeaderAttribute.AccessControlAllowOrigin)) httpResponseMessageProperty.Headers.Set(HttpHeaderKeys.AccessControlAllowOrigin, responseHttpHeaderAttribute.AccessControlAllowOrigin);
            message.Properties.Add(HttpResponseMessageProperty.Name, httpResponseMessageProperty);
            return message;
        }
    }
}
using System;
using System.Collections.Specialized;
using System.Net;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using Lib.Json;

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
                    parameters[i] = Jsons.Deserialize(nameValueCollection[part.Name], part.Type);
                });
            }
            catch { }
        }
        private void DeserializeRequestPost(Message message, object[] parameters)
        {
            if (parameters.Length != 1) return;
            try
            {
                XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents();
                bodyReader.ReadStartElement("Binary");
                string json = Encoding.UTF8.GetString(bodyReader.ReadContentAsBase64());
                bodyReader.Close();
                parameters[0] = Jsons.Deserialize(json, operationDescription.Messages[0].Body.Parts[0].Type);
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
            Message replyMessage = Message.CreateMessage(messageVersion, operationDescription.Messages[1].Action, new RawBodyWriter(Encoding.UTF8.GetBytes(Jsons.Serialize(result))));
            replyMessage.Properties.Add(WebBodyFormatMessageProperty.Name, new WebBodyFormatMessageProperty(WebContentFormat.Raw));

            HttpResponseMessageProperty httpResponseMessageProperty = new HttpResponseMessageProperty();
            httpResponseMessageProperty.Headers[HttpResponseHeader.ContentType] = ContentTypeValues.ApplicationJson;
            replyMessage.Properties.Add(HttpResponseMessageProperty.Name, httpResponseMessageProperty);
            return replyMessage;
        }
    }
}
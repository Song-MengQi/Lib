using Lib.Json;
using System.Net;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;

namespace Lib.Server
{
    public class JsonDispatchFormatter : IDispatchMessageFormatter
    {
        private readonly OperationDescription operationDescription;
        public JsonDispatchFormatter(OperationDescription operationDescription)
        {
            this.operationDescription = operationDescription;
        }
        public void DeserializeRequest(Message message, object[] parameters)
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
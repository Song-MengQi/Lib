using System.ServiceModel.Channels;
using System.Xml;

namespace Lib.Server
{
    public static class MessageExtend
    {
        public static byte[] GetBytes(this Message message)
        {
            XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents();
            bodyReader.ReadStartElement("Binary");
            byte[] bytes = bodyReader.ReadContentAsBase64();
            bodyReader.Close();
            return bytes;
        }
    }
}
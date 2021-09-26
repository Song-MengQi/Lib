using System.ServiceModel.Channels;

namespace Lib.Server
{
    public class RawWebContentTypeMapper : WebContentTypeMapper
    {
        public override WebContentFormat GetMessageFormatForContentType(string contentType) { return WebContentFormat.Raw; }
    }
}
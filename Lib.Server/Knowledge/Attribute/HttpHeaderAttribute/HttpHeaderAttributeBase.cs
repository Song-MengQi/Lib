using System;

namespace Lib.Server
{
    public abstract class HttpHeaderAttributeBase : Attribute
    {
        public string ContentType { get; set; }
        public HttpHeaderAttributeBase() : base()
        {
            ContentType = ContentTypeValues.ApplicationJson;
        }
    }
}
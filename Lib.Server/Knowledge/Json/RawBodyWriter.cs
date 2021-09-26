﻿using System.ServiceModel.Channels;
using System.Xml;

namespace Lib.Server
{
    public class RawBodyWriter : BodyWriter
    {
        private readonly byte[] content;
        public RawBodyWriter(byte[] content)
            : base(true)
        {
            this.content = content;
        }
        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            writer.WriteStartElement("Binary");
            writer.WriteBase64(content, 0, content.Length);
            writer.WriteEndElement();
        }
    }
}
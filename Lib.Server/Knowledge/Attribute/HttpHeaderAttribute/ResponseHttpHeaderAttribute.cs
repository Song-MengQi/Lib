using System;

namespace Lib.Server
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ResponseHttpHeaderAttribute : HttpHeaderAttributeBase
    {
        public string CacheControl { get; set; }
        public string AccessControlAllowOrigin { get; set; }
        //public ResponseHttpHeaderAttribute() : base()
        //{
        //    CacheControl = CacheControlValues.NoStore;
        //}
    }
}
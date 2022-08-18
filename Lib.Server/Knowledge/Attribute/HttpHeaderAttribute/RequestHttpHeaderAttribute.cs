using System;

namespace Lib.Server
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class RequestHttpHeaderAttribute : HttpHeaderAttributeBase
    {
    }
}
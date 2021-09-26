using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Lib.Server
{
    public class JsonBehavior : WebHttpBehavior
    {
        protected override IDispatchMessageFormatter GetRequestDispatchFormatter(OperationDescription operationDescription, ServiceEndpoint _) 
        {
            return new JsonDispatchFormatter(operationDescription);
        }

        protected override IDispatchMessageFormatter GetReplyDispatchFormatter(OperationDescription operationDescription, ServiceEndpoint _)
        {
            return new JsonDispatchFormatter(operationDescription);
        }
    }
}

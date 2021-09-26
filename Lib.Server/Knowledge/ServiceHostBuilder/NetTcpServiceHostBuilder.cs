using System;
using System.ServiceModel;

namespace Lib.Server
{
    public class NetTcpServiceHostBuilder : ServiceHostBuilderBase<NetTcpServiceHostBuilder>
    {
        public override ServiceHost BuildServiceHost(Type serviceType, Type contractType)
        {
            ServiceHost serviceHost = base.BuildServiceHost(serviceType, contractType);
            serviceHost.AddServiceEndpoint(
                contractType,
                Bindings.NetTcpBinding,
                Config.GetServerNetTcpAddress(contractType)
            );
            return serviceHost;
        }
    }
}
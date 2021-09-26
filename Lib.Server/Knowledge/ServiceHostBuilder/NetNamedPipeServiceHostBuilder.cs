using System;
using System.ServiceModel;

namespace Lib.Server
{
    public class NetNamedPipeServiceHostBuilder : ServiceHostBuilderBase<NetNamedPipeServiceHostBuilder>
    {
        public override ServiceHost BuildServiceHost(Type serviceType, Type contractType)
        {
            ServiceHost serviceHost = base.BuildServiceHost(serviceType, contractType);
            serviceHost.AddServiceEndpoint(
                contractType,
                Bindings.NetNamedPipeBinding,
                Config.GetNetNamedPipeAddress(contractType)
            );
            return serviceHost;
        }
    }
}
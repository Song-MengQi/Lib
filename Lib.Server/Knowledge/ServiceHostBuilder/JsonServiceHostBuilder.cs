using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Lib.Server
{
    public class JsonServiceHostBuilder : ServiceHostBuilderBase<JsonServiceHostBuilder>
    {
        private readonly JsonBehavior jsonBehavior = new JsonBehavior();
        public override ServiceHost BuildServiceHost(Type serviceType, Type contractType)
        {
            ServiceHost serviceHost = base.BuildServiceHost(serviceType, contractType);

            ServiceEndpoint serviceEndpoint = new ServiceEndpoint(
                ContractDescription.GetContract(contractType, serviceType),
                Bindings.JsonBinding,
                new EndpointAddress(Config.GetServerJsonAddress(contractType))
            );
            serviceEndpoint.EndpointBehaviors.Add(jsonBehavior);

            //serviceHost.AddServiceEndpoint(serviceEndpoint);
            //等同于
            serviceHost.Description.Endpoints.Add(serviceEndpoint);

            return serviceHost;
        }
    }
}
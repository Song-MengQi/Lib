using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Lib.Server
{
    public class WebHttpServiceHostBuilder : ServiceHostBuilderBase<WebHttpServiceHostBuilder>
    {
        private readonly JsonBehavior jsonBehavior = new JsonBehavior();
        public override ServiceHost BuildServiceHost(Type serviceType, Type contractType)
        {
            ServiceHost serviceHost = base.BuildServiceHost(serviceType, contractType);

            ServiceEndpoint serviceEndpoint = new ServiceEndpoint(
                ContractDescription.GetContract(contractType, serviceType),
                Bindings.WebHttpBinding,
                new EndpointAddress(Config.GetServerWebHttpAddress(contractType))
            );
            serviceEndpoint.EndpointBehaviors.Add(jsonBehavior);

            //serviceHost.AddServiceEndpoint(serviceEndpoint);
            //等同于
            serviceHost.Description.Endpoints.Add(serviceEndpoint);
            WebServerExtends.RegisterHttpHeaderAttribute(contractType);
            return serviceHost;
        }
    }
}
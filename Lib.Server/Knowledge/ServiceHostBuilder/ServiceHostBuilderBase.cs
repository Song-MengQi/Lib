using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Lib.Server
{
    public abstract class ServiceHostBuilderBase<T> : SingletonBase<T, IServiceHostBuilder>, IServiceHostBuilder
        where T : ServiceHostBuilderBase<T>, IServiceHostBuilder, new()
    {
        private readonly ServiceThrottlingBehavior serviceThrottlingBehavior = new ServiceThrottlingBehavior {
            //MaxConcurrentCalls = Environment.ProcessorCount * 160,//默认处理器数*16
            //MaxConcurrentSessions = Environment.ProcessorCount * 1000,//默认为处理器数*100
            ////MaxConcurrentInstances = MaxConcurrentCalls+MaxConcurrentSessions//默认为MaxConcurrentCalls+MaxConcurrentSessions
        };
        protected Config Config { get { return Config.Instance; } }
        public virtual ServiceHost BuildServiceHost(Type serviceType, Type contractType)
        {
            ServiceHost serviceHost = new ServiceHost(serviceType);

            ServiceBehaviorAttribute serviceBehaviorAttribute = serviceHost.Description.Behaviors.Find<ServiceBehaviorAttribute>();
            serviceBehaviorAttribute.UseSynchronizationContext = false;
            serviceBehaviorAttribute.ConcurrencyMode = ConcurrencyMode.Multiple;
            serviceBehaviorAttribute.InstanceContextMode = InstanceContextMode.Single;

            //ServiceDebugBehavior serviceDebugBehavior = serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>();
            //serviceDebugBehavior.HttpHelpPageEnabled = false;
            //serviceDebugBehavior.HttpsHelpPageEnabled = false;
            //干脆直接删掉
            serviceHost.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));

            //默认没有ServiceMetadataBehavior
            //serviceHost.Description.Behaviors.Remove(typeof(ServiceMetadataBehavior));

            serviceHost.Description.Behaviors.Remove(typeof(ServiceAuthorizationBehavior));

            serviceHost.Description.Behaviors.Remove(typeof(ServiceAuthenticationBehavior));

            serviceHost.Description.Name = serviceType.FullName;
            serviceHost.Description.Behaviors.Add(serviceThrottlingBehavior);
            return serviceHost;
        }
    }
}
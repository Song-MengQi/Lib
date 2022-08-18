using System;
using System.Linq;

namespace Lib.Server
{
    public static class IServerExtend
    {
        private static Type GetDefaultContractType(Type serviceType)
        {
            string contractName = "I" + serviceType.Name;
            return serviceType.GetInterfaces().Single(contractType => contractType.Name == contractName && contractType.Namespace == serviceType.Namespace);
        }

        public static void Register<TService>(this IServer server, BindingType bindingType)
        {
            Type serviceType = typeof(TService);
            server.ServiceItemList.Add(new ServiceItem {
                ServiceType = serviceType,
                ContractType = GetDefaultContractType(serviceType),
                BindingType = bindingType
            });
        }
        public static void Register<TService, ITService>(this IServer server, BindingType bindingType)
            where TService : ITService, new()
        {
            server.ServiceItemList.Add(new ServiceItem {
                ServiceType = typeof(TService),
                ContractType = typeof(ITService),
                BindingType = bindingType
            });
            IoC<ITService>.SetInstance<TService>();
        }

        public static void Register<TService>(this IServer server)
        {
            server.Register<TService>(ServerExtends.GetDefaultServiceType(typeof(TService)));
        }
        public static void Register<TService, ITService>(this IServer server)
            where TService : ITService, new()
        {
            server.Register<TService, ITService>(ServerExtends.GetDefaultServiceType(typeof(TService)));
        }
    }
}
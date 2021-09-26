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
        public static void Register<TService>(this IServer server)
        {
            Type serviceType = typeof(TService);
            server.ServiceTypeDic.Add(serviceType, GetDefaultContractType(serviceType));
        }
        public static void Register<TService, ITService>(this IServer server)
            where TService : ITService, new()
            where ITService : class
        {
            server.ServiceTypeDic.Add(typeof(TService), typeof(ITService));
            IoC<ITService>.SetInstance<TService>();
        }
    }
}
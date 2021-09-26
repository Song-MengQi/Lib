using System;
using System.ServiceModel;

namespace Lib.Server
{
    public interface IServiceHostBuilder
    {
        ServiceHost BuildServiceHost(Type serviceType, Type contractType);
    }
}
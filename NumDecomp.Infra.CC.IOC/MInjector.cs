using Microsoft.Extensions.DependencyInjection;
using NumDecomp.Domain.Services.Services;
using NumDecomp.Domain.Core.Interfaces.Services;

namespace NumDecomp.Infra.CC.IOC
{
    public static class MInjector
    {
        public static ServiceProvider GetProvider(IServiceCollection servicesCollection)
        {
            servicesCollection.AddTransient<IServiceDecomposition, ServiceDecomposition>();
            return servicesCollection.BuildServiceProvider();
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IServiceDecomposition, ServiceDecomposition>();
        }
    }
}

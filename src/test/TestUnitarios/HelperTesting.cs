using System;
using Application.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestUnitarios.Mocks.MockingInfraestructure.MoqWeatherForecast.MoqQueries.QueryAll;

namespace TestUnitarios
{
    internal static class HelperTesting
    {
        public static IServiceProvider CreateServiceProvider(Action<IServiceCollection> addServices)
        {
            var host = new HostBuilder();

            host.ConfigureServices(services =>
            {
                services.AddBusinessServices();
            });

            if (addServices is not null)
            {
                host.ConfigureServices(addServices);
            }

            return host.Build().Services;
        }
    }
}

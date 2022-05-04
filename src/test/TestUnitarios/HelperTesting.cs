using Application.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestUnitarios.Mocks.MockRepositoryDatabase;

namespace TestUnitarios
{
    internal static class HelperTesting
    {
        public static IHost CreateDependencyInjection()
        {
            var host = new HostBuilder();

            host.ConfigureServices(services =>
            {
                services.AddNegocio();
                services.AddMockServices();
            });

            return host.Build();
        }

        public static IServiceCollection AddMockServices(this IServiceCollection services)
        {
            services.AddTransient(x => new WeatherForecastRepositoryMock().MockingWeatherForecastRepository.Object);

            return services;
        }
    }
}

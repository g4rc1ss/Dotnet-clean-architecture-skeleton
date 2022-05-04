using Application.Interfaces.Data;
using Infraestructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Data;

public static class AccessDataExtensions
{
    public static IServiceCollection AddDatabaseConfig(this IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

        return services;
    }
}

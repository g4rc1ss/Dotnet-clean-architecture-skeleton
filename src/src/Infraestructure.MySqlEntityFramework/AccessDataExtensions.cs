using Application.Interfaces.Data;
using Infraestructure.MySqlEntityFramework.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.MySqlEntityFramework;

public static class AccessDataExtensions
{
    public static IServiceCollection AddDatabaseConfig(this IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

        return services;
    }
}

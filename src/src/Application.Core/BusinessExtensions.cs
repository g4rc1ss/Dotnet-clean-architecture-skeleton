using Application.Core.WeatherForecast;
using Application.Interfaces.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Core;

public static class BusinessExtensions
{
    public static IServiceCollection AddNegocio(this IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastNegocio, WeatherForecastNegocio>();

        return services;
    }
}

using Application.Core.WeatherForecast;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Core;

public static class BusinessExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(BusinessExtensions));

        return services;
    }
}

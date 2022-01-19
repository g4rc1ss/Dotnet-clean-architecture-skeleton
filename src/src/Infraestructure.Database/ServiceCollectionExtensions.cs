using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Database;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabaseConfig(this IServiceCollection services)
    {

        return services;
    }
}

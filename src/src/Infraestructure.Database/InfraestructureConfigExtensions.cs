using Infraestructure.MySqlEntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.DatabaseConfig;

public static class InfraestructureConfigExtensions
{
    public static IServiceCollection AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMysqlEntityFrameworkConfig(configuration);


        return services;
    }
}

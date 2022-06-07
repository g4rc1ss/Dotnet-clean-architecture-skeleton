using Application.Interfaces.Infraestructure.Command.WeatherForecastCommandContracts;
using Application.Interfaces.Infraestructure.Query.WeatherForecastQueryContracts;
using Infraestructure.MySqlEntityFramework.Contexts;
using Infraestructure.MySqlEntityFramework.Repositories.Command.WeatherForecastCommand;
using Infraestructure.MySqlEntityFramework.Repositories.Query.WeatherForecastQueries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.MySqlEntityFramework;

public static class AccessDataExtensions
{
    public static IServiceCollection AddMysqlEntityFrameworkConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMySqlDbContext<CleanArchitectureSkeletonContext>(configuration);

        services.AddRepositoryServices();
        return services;
    }

    private static IServiceCollection AddMySqlDbContext<TContext>(this IServiceCollection services, IConfiguration configuration) where TContext : DbContext
    {
        void dbContextOptions(DbContextOptionsBuilder db)
        {
            var mySqlVersion = MySqlServerVersion.LatestSupportedServerVersion;
            db.UseMySql(configuration.GetConnectionString(typeof(TContext).Name), mySqlVersion);
        }

        services.AddDbContextPool<TContext>(dbContextOptions);
        services.AddPooledDbContextFactory<TContext>(dbContextOptions);

        return services;
    }

    private static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastQueryAllContract, WeatherForecastQueryAll>();
        services.AddScoped<IWeatherForecastCommandCreateContract, WeatherForecastCommandCreate>();

        return services;
    }
}

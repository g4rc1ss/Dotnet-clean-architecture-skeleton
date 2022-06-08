using Application.Core;
using Infraestructure.DatabaseConfig;
using Infraestructure.MySqlEntityFramework;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public static class WebApiServicesExtension
    {
        public static IServiceCollection InicializarConfiguracionApp(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(WebApiServicesExtension), typeof(BusinessExtensions), typeof(AccessDataExtensions));
            services.AddOptions();
            services.AddRedisCache();
            services.ConfigureDataProtectionProvider();


            services.AddBusinessServices();
            services.AddDatabaseConfig(configuration);

            return services;
        }

        public static IServiceCollection AddRedisCache(this IServiceCollection services)
        {
            //services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = "localhost:6379,password=password123";
            //    options.InstanceName = "localhost";
            //});
            services.AddDistributedMemoryCache();
            return services;
        }

        public static IServiceCollection ConfigureDataProtectionProvider(this IServiceCollection services)
        {
            services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(@".\temp"))
                //.AddDataProtectionEntityFramework(configuration)
                .SetApplicationName("Aplicacion.WebApi");
            return services;
        }
    }
}

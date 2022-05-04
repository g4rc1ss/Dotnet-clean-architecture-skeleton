using Application.Core;
using Domain.Utilities.LoggingMediatr;
using Infraestructure.Data;
using MediatR;
using Microsoft.AspNetCore.DataProtection;

namespace WebApi.Extensions
{
    public static class WebApiServicesExtension
    {
        internal static IServiceCollection InicializarConfiguracionApp(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(WebApiServicesExtension), typeof(BusinessExtensions), typeof(AccessDataExtensions));
            services.AddMediatR(typeof(WebApiServicesExtension), typeof(LoggingRequest));
            services.AddOptions();
            services.AddRedisCache();
            services.ConfigureDataProtectionProvider();


            services.AddNegocio();
            services.AddDatabaseConfig();

            return services;
        }

        internal static IServiceCollection AddRedisCache(this IServiceCollection services)
        {
            //services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = "localhost:6379,password=password123";
            //    options.InstanceName = "localhost";
            //});
            services.AddDistributedMemoryCache();
            return services;
        }

        internal static IServiceCollection ConfigureDataProtectionProvider(this IServiceCollection services)
        {
            services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(@".\temp"))
                //.AddDataProtectionEntityFramework(configuration)
                .SetApplicationName("Aplicacion.WebApi");
            return services;
        }
    }
}

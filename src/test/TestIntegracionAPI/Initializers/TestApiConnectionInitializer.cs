using System;
using System.Net.Http;
using Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TestIntegracionAPI.Initializers
{
    public class TestApiConnectionInitializer
    {
        public HttpClient ApiClient { get; set; }
        public IServiceProvider ServiceProvider { get; set; }
        public IConfiguration Configuration { get; set; }

        public TestApiConnectionInitializer()
        {
            var builder = WebApplication.CreateBuilder();

            //builder.Host.AddLoggerConfiguration();

            //builder.Services.AddCors(option =>
            //{
            //    option.AddPolicy("open", builder => builder.AllowAnyOrigin().AllowAnyHeader());
            //});

            //builder.Services.InicializarConfiguracionApp(builder.Configuration);
            //builder.Services.AddProblemDetails();

            //builder.Services.AddControllers()
            //    .AddApplicationPart(typeof(WebApiServicesExtension).Assembly);

            //var app = builder.Build();

            //app.UseProblemDetails();

            //app.UseCors("open");

            //app.MapControllers();

            //return app.RunAsync("http://localhost:5000");





            //builder.ConfigureAppConfiguration((hostBuilder, config) =>
            //{
            //    config.SetBasePath(Directory.GetCurrentDirectory());
            //    config.AddJsonFile("appsettings.test.json", false);
            //});
            //builder.UseEnvironment("Development");
        }
    }
}

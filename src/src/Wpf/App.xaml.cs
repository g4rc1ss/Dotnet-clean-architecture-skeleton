using System;
using System.Threading.Tasks;
using System.Windows;
using Api;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wpf.Extensions;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            RunWebApiAsync();
            RunWpfApplication();
        }

        private void RunWpfApplication()
        {
            var builder = Host.CreateDefaultBuilder();
            builder.ConfigureServices((hostContext, services) =>
            {
                services.AddHttpClient("clienteLocalhost", (serviceProvider, httpClient) =>
                {
                    httpClient.BaseAddress = new Uri("http://localhost:5000/");
                });

                services.AddTransient<MainWindow>();
            });
            var app = builder.Build();

            var window = app.Services.GetRequiredService<MainWindow>();
            window.Show();
        }

        private Task RunWebApiAsync()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Host.AddLoggerConfiguration();

            builder.Services.AddCors(option =>
            {
                option.AddPolicy("open", builder => builder.AllowAnyOrigin().AllowAnyHeader());
            });

            builder.Services.InicializarConfiguracionApp(builder.Configuration);
            builder.Services.AddProblemDetails();

            builder.Services.AddControllers()
                .AddApplicationPart(typeof(WebApiServicesExtension).Assembly);

            var app = builder.Build();
            //app.Urls.Add("http://localhost:5001");

            app.UseProblemDetails();

            app.UseCors("open");

            app.MapControllers();

            return app.RunAsync("http://localhost:5000");
        }
    }
}

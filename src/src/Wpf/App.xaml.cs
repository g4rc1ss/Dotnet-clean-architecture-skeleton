using Api.Extensions;
using Wpf.Extensions;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Hellang.Middleware.ProblemDetails;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;

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

            builder.Services.AddControllers();

            var app = builder.Build();
            //app.Urls.Add("http://localhost:5001");

            app.UseCors("open");

            app.UseProblemDetails();

            app.MapControllers();

            return app.RunAsync("http://localhost:5000");
        }
    }
}

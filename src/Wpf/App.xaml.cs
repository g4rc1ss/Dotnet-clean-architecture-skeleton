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
            builder.ConfigureServices(services =>
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

        private async Task RunWebApiAsync()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Host.AddLoggerConfiguration();

            builder.Services.AddCors(o => o.AddPolicy("localhostPolicyAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            builder.Services.InicializarConfiguracionApp(builder.Configuration);
            builder.Services.AddProblemDetails();

            builder.Services.AddControllers();
            
            var app = builder.Build();
            app.Urls.Add("http://localhost:5000");
            app.Urls.Add("http://localhost:5001");

            app.UseProblemDetails();
            app.UseCors("localhostPolicyAll");
            
            await app.RunAsync();
        }
    }
}

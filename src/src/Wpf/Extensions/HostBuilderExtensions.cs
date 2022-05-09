using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Wpf.Extensions
{
    public static class HostBuilderExtensions
    {

        internal static IHostBuilder AddLoggerConfiguration(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseSerilog((hostBuilderContext, loggerConfig) =>
            {
                loggerConfig.WriteTo.Async(config =>
                {
                    config.File(@".\logs\log-.txt",
                        rollingInterval: RollingInterval.Hour,
                        rollOnFileSizeLimit: true,
                        restrictedToMinimumLevel: LogEventLevel.Debug);

                    if (hostBuilderContext.HostingEnvironment.IsDevelopment())
                    {
                        config.Console(restrictedToMinimumLevel: LogEventLevel.Debug);
                    }
                });
            });
            return hostBuilder;
        }
    }
}

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
                    config.File("./logs", LogEventLevel.Debug);

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

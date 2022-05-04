using Serilog;
using Serilog.Events;

namespace WebApi.Extensions
{
    public static class HostBuilderExtensions
    {

        internal static IHostBuilder AddLoggerConfiguration(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseSerilog((hostBuilderContext, loggerConfig) =>
            {
                loggerConfig.WriteTo.Async(config =>
                {
                    //config.MSSqlServer(
                    //    connectionString: connectionString,
                    //    new MSSqlServerSinkOptions
                    //    {
                    //        SchemaName = "dbo",
                    //        TableName = "Logs",
                    //        AutoCreateSqlTable = true,
                    //    },
                    //    restrictedToMinimumLevel: LogEventLevel.Warning);

                    config.Console(restrictedToMinimumLevel: LogEventLevel.Information);
                });
            });
            return hostBuilder;
        }
    }
}

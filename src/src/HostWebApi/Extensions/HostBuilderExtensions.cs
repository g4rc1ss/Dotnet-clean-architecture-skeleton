using Serilog;
using Serilog.Events;
using Serilog.Sinks.Graylog;
using Serilog.Sinks.Graylog.Core.Transport;

namespace HostWebApi.Extensions
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
                    var grayLogConfig = new GraylogSinkOptions
                    {
                        HostnameOrAddress = "localhost",
                        Port = 12201,

                        TransportType = TransportType.Udp,
                        MinimumLogEventLevel = LogEventLevel.Debug,
                    };
                    config.Graylog(grayLogConfig);

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

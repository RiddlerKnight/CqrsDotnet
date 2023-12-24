using CqrsDotnet.Infrastructure.ConfigSchema;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.OpenTelemetry;

namespace CqrsDotnet.Infrastructure.Helpers;

public static class SerilogAdditionalOtelConfig
{
    public static LoggerConfiguration AddAdditionalOtelConfig(this LoggerConfiguration loggerConfiguration, 
        IConfiguration config)
    {
        // Not use right now, keep for example for another sink
        // var otelConfig = config.GetSection("Serilog:WriteTo").GetChildren();
        // var singleOrDefault = otelConfig.SingleOrDefault(c => 
        //     c.GetSection("Name").Value == "OpenTelemetry");
        // if (singleOrDefault is not null)
        // {
        //     singleOrDefault["Args:ServiceName"] = "test-app";
        // }

        var otelConfig = new SerilogSinkOtelConfig();
        config.Bind("Exporters:Otel", otelConfig);
        if (otelConfig.Enabled)
        {
            loggerConfiguration.WriteTo.OpenTelemetry(options =>
            {
                options.Endpoint = otelConfig.EndPoint;
                options.Protocol = otelConfig.Protocol;
                options.IncludedData = IncludedData.TraceIdField | IncludedData.SpanIdField;
            });
        }

        return loggerConfiguration;
    }
}
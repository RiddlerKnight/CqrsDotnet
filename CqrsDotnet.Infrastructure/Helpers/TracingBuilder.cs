using System.Reflection;
using CqrsDotnet.Infrastructure.ConfigSchema;
using Microsoft.Extensions.Configuration;
using OpenTelemetry;
using OpenTelemetry.Exporter;
using OpenTelemetry.Trace;

namespace CqrsDotnet.Infrastructure.Helpers;

public static class TracingBuilder
{
    public static OpenTelemetryBuilder AddTracing(this OpenTelemetryBuilder builder,
        IConfiguration configuration)
    {
        var configOption = new SerilogSinkOtelConfig();
        configuration.Bind("Exporters:Otel", configOption);

        if (!configOption.Enabled)
        {
            return builder;
        }

        builder.WithTracing(providerBuilder =>
        {
            var appName = Assembly.GetEntryAssembly()?.FullName?.Split(',')[0];
            providerBuilder.AddSource(appName);
            providerBuilder.AddAspNetCoreInstrumentation(options =>
            {
                options.RecordException = true;
            });
            providerBuilder.AddOtlpExporter(options =>
            {
                options.Protocol =  Enum.Parse<OtlpExportProtocol>(configOption.Protocol.ToString());
                options.Endpoint = new Uri(configOption.EndPoint);
            });
        });
        
        return builder;
    }
}
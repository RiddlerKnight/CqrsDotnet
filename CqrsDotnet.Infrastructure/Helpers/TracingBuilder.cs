using System.Reflection;
using CqrsDotnet.Infrastructure.ConfigSchema;
using Microsoft.Extensions.Configuration;
using OpenTelemetry;
using OpenTelemetry.Trace;

namespace CqrsDotnet.Infrastructure.Helpers;

public static class TracingBuilder
{
    public static OpenTelemetryBuilder AddTracing(this OpenTelemetryBuilder builder,
        IConfiguration configuration)
    {
        var configOption = new OtelConfig();
        configuration.Bind("Exporter:Tracing", configOption);
        
        builder.WithTracing(providerBuilder =>
        {
            var appName = Assembly.GetEntryAssembly()?.FullName?.Split(',')[0];
            providerBuilder.AddSource(appName);
            providerBuilder.AddAspNetCoreInstrumentation(options =>
            {
                options.EnableGrpcAspNetCoreSupport = true;
                options.RecordException = true;
            });
            providerBuilder.AddOtlpExporter(options =>
            {
                options.Protocol = configOption.Protocol;
                options.Endpoint = configOption.EndPoint;
            });
        });
        
        return builder;
    }
}
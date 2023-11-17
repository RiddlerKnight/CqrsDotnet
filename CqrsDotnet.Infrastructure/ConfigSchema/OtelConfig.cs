using System.ComponentModel;
using OpenTelemetry.Exporter;

namespace CqrsDotnet.Infrastructure.ConfigSchema;

public class OtelConfig
{
    [DefaultValue("http://localhost:4317")]
    public Uri EndPoint { get; set; }
    [DefaultValue(OtlpExportProtocol.Grpc)]
    public OtlpExportProtocol Protocol { get; set; }
}

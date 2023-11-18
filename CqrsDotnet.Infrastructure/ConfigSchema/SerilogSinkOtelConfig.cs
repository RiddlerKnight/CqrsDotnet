using System.ComponentModel;
using Serilog.Sinks.OpenTelemetry;

namespace CqrsDotnet.Infrastructure.ConfigSchema;

public class SerilogSinkOtelConfig
{
    [DefaultValue(false)]
    public bool Enabled { get; set; }
    [DefaultValue("http://localhost:4317")]
    public string EndPoint { get; set; }
    [DefaultValue(OtlpProtocol.Grpc)]
    public OtlpProtocol Protocol { get; set; }
}

namespace CqrsDotnet.Infrastructure.ConfigSchema;

public class DbSetting
{
    public int CommandTimeout { get; set; }
    public bool SensitiveLogging { get; set; }
    public bool DetailError { get; set; }
    public bool Pooling { get; set; }
    public bool NoResetOnClose { get; set; }
    public string EndPoint { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
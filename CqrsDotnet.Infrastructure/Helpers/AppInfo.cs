using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace CqrsDotnet.Infrastructure.Helpers;

public class AppInfo
{
    public static void MakeLog(IConfiguration configuration, IWebHostEnvironment env)
    {
        Serilog.Log.Information("----------------------------------------------------------");
        Serilog.Log.Information("     ApplicationName: {AppName}", env.ApplicationName);
        Serilog.Log.Information("     Environment: {EnvName}", env.EnvironmentName);
        Serilog.Log.Information("     Version: {Semver}", Assembly.GetEntryAssembly()?
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
            .InformationalVersion);
        Serilog.Log.Information("----------------------------------------------------------");
    }
}
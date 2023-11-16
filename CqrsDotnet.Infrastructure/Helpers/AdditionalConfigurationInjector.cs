using Microsoft.Extensions.Configuration;

namespace CqrsDotnet.Infrastructure.Helpers;

public static class AdditionalConfigurationInjector
{
    /// <summary>
    /// Inject setting in folder "configs" and "secrets" located in current runtime application.
    /// respect by ordering <br/>
    ///  - configs <br/>
    ///  - secrets <br/>
    /// </summary>
    public static IConfigurationBuilder InjectConfigsAndSecret(this IConfigurationBuilder builder)
    {
        builder.InjectConfigs();
        builder.InjectSecrets();
        return builder;
    }

    /// <summary>
    /// Inject setting in folder "configs" located in current runtime application.
    /// </summary>
    public static IConfigurationBuilder InjectConfigs(this IConfigurationBuilder builder)
    {
        string configDirectory = Path.Combine(AppContext.BaseDirectory, "configs");
        if (Directory.Exists(configDirectory))
        {
            foreach (var configFile in Directory.EnumerateFiles(configDirectory, "*.json?"))
            {
                var relativePath = Path.GetRelativePath(AppContext.BaseDirectory, configFile);
                builder.AddJsonFile(source =>
                {
                    source.Path = relativePath;
                    source.Optional = false;
                    source.ReloadOnChange = true;
                });
                // Use Console log instead, cuz serilog may not init in this section.
                Console.WriteLine($"Found additional configuration file: {configFile}" );
            }
        }

        return builder;
    }
    
    /// <summary>
    /// Inject setting in folder "secrets" located in current runtime application.
    /// </summary>
    public static IConfigurationBuilder InjectSecrets(this IConfigurationBuilder  builder)
    {
        string secretDirectory = Path.Combine(AppContext.BaseDirectory, "secrets");
        if (Directory.Exists(secretDirectory))
        {
            foreach (var secretFile in Directory.EnumerateFiles(secretDirectory, "*.json?"))
            {
                var relativePath = Path.GetRelativePath(AppContext.BaseDirectory, secretFile);
                builder.AddJsonFile(source =>
                {
                    source.Path = relativePath;
                    source.Optional = false;
                    source.ReloadOnChange = true;
                });
                // Use Console log instead, cuz serilog may not init in this section.
                Console.WriteLine($"Found additional configuration file: {secretFile}");
            }
        }
        
        return builder;
    }
}
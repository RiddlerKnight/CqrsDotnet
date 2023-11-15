using CqrsDotnet.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CqrsDotnet.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceRegistration(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Inject some services here.
        /*
        services.AddDbContext<CoreDbContext>(builder =>
        {
            var conBuilder = new NpgsqlConnectionStringBuilder();
            var configValues = new DbSetting();
            configuration.Bind("DbSetting", configValues);
            
            conBuilder.Pooling = configValues.Pooling;
            conBuilder.NoResetOnClose = configValues.NoResetOnClose;
            
            builder
                .UseNpgsql(conBuilder.ToString(),
                    dbOption =>
                    {
                        dbOption.EnableRetryOnFailure();
                        dbOption.CommandTimeout(configValues.CommandTimeout);
                    });
            builder.EnableDetailedErrors(configValues.DetailError);
            builder.EnableSensitiveDataLogging(configValues.SensitiveLogging);
        });
        */
        services.AddDbContext<CoreDbContext>(builder =>
        {
            builder.UseInMemoryDatabase("db");
        });
        return services;
    }
}
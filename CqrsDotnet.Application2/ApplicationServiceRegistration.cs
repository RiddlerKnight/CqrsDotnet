using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsDotnet.Application2;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplication2Service(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Inject some services here.
        services.AddMediatR(serviceConfiguration =>
        {
            serviceConfiguration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}


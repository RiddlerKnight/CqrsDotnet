using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsDotnet.Infrastructure;

public static class BaseServicesRegistration
{
    public static IServiceCollection AddBaseServicesRegistration(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Inject some services here.
        return services;
    }
}
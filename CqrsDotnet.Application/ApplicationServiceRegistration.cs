using System.Reflection;
using CqrsDotnet.Application.GrpcControllers;
using CqrsDotnet.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsDotnet.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Inject some services here.
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddBaseServicesRegistration(configuration);
        
        services.AddGrpc();
        services.AddGrpcReflection();
        services.AddGrpcSwagger();

        return services;
    }

    public static void MapGrpcControllerFromApplicationService(this WebApplication app)
    {
        app.MapGrpcService<LocationGrpcController>();
        app.MapGrpcReflectionService();
    }
}


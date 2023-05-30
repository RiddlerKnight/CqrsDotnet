using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Serilog;
using System.Reflection;
using CqrsDotnet.Application;
using CqrsDotnet.Infrastructure.Helpers;
using Microsoft.AspNetCore.HttpOverrides;

static void SetupLogger(IConfiguration config)
{
    try
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(config)
            .CreateLogger();

        Log.Information("Log Created");
    }
    catch (Exception e)
    {
        Log.Debug("Log Error! : {ExStr}", e.ToString());
    }
}

#region InitConfiguration(Startup)

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("logsettings.json", false);
builder.Configuration.AddJsonFile($"logsettings.{builder.Environment.EnvironmentName}.json", true);
builder.Configuration.AddJsonFile($"appsetting.kube.json", true);

// Add services to the container.

builder.Services.AddControllers()
    .PartManager.ApplicationParts.Add(new AssemblyPart(Assembly.GetExecutingAssembly()));

builder.Services.AddApplicationService(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
});

builder.Services.AddSwaggerGen();
builder.Host.UseSerilog();
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.All;
});

#endregion

#region Build And Run Api Server

var app = builder.Build();
SetupLogger(app.Configuration);
AppInfo.MakeLog(app.Configuration, app.Environment);

app.UseForwardedHeaders();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.MapGrpcControllerFromApplicationService();

app.Run();

#endregion
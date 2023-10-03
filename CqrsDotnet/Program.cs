using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Serilog;
using System.Reflection;
using CqrsDotnet.Application;
using CqrsDotnet.Application2;
using CqrsDotnet.Infrastructure.Helpers;
using Microsoft.AspNetCore.HttpOverrides;

static void SetupLogger(IConfiguration config)
{
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(config)
        .CreateLogger();

    Log.Information("Log Created");
}

#region InitConfiguration(Startup)

var builder = WebApplication.CreateBuilder(args);
// ReSharper disable once StringLiteralTypo
builder.Configuration.AddJsonFile("logsettings.json", false);
// ReSharper disable once StringLiteralTypo
builder.Configuration.AddJsonFile($"logsettings.{builder.Environment.EnvironmentName}.json", true);
// ReSharper disable once StringLiteralTypo
builder.Configuration.AddJsonFile($"config/appsettings.kube.json", true, true);

// Add services to the container.

builder.Services.AddControllers()
    .PartManager.ApplicationParts.Add(new AssemblyPart(Assembly.GetExecutingAssembly()));

builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddApplication2Service(builder.Configuration);
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

builder.Services.Configure<WebSocketOptions>(options =>
{
    options.KeepAliveInterval = TimeSpan.FromSeconds(60);
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
app.UseWebSockets();

app.Run();

#endregion
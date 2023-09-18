using Personal.Photography.Gallery.Api;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

try
{
    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{environment}.json", optional: true)
        .Build();

    var builderSecrets = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($"appsettings.{environment}.json", optional: true, true)
        .AddEnvironmentVariables();

    var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .CreateLogger();

    logger.Information("Starting the Log!");

    builder.Host.UseSerilog(logger);

    if (environment == "Development")
    {
        builderSecrets.AddUserSecrets<Startup>();
    }
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}

builder.UseStartup<Startup>();
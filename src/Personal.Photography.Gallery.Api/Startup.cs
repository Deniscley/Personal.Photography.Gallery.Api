using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Personal.Photography.Gallery.Api.Configuration;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace Personal.Photography.Gallery.Api
{
    public class Startup : IStartup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddFluentValidationConfiguration();

            services.AddAutoMapperConfiguration();

            services.AddDatabaseConfiguration(Configuration);

            services.AddDependencyInjectionConfiguration();

            services.AddEndpointsApiExplorer();

            services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Startup>());

            services.AddSwaggerConfiguration();

            services.AddHealthChecks()
                .AddSqlServer(Configuration.GetConnectionString("DefaultConnection"), 
                    name: "SQL Server Check", tags: new string[] { "db", "data" });

            services.AddHealthChecksUI()
                .AddInMemoryStorage();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            app.UseExceptionHandler("/error");

            if(environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerConfiguration();

            app.UseDatabaseConfiguration();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.UseHealthChecks("/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(options =>
            {
                options.UIPath = "/dashboard";
            });
        }
    }

    public interface IStartup
    {
        IConfiguration Configuration { get; }
        void Configure(WebApplication app, IWebHostEnvironment environment);
        void ConfigureServices(IServiceCollection services);

    }

    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder WebAppBuilder) where TStartup : IStartup
        {
            var startup = Activator.CreateInstance(typeof(TStartup), WebAppBuilder.Configuration) as IStartup;
            if (startup == null) throw new ArgumentException("Classe Startup.cs inválida!");

            startup.ConfigureServices(WebAppBuilder.Services);

            var app = WebAppBuilder.Build();
            startup.Configure(app, app.Environment);

            app.Run();

            return WebAppBuilder;
        }
    }
}

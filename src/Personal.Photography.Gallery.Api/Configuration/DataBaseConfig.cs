using Microsoft.EntityFrameworkCore;
using Personal.Photography.Gallery.Data.Context;

namespace Personal.Photography.Gallery.Api.Configuration
{
    public static class DataBaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => 
                options.UseInMemoryDatabase(databaseName: "gallery"));
        }

        public static void UseDatabaseConfiguration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<DataContext>();
            
            //TODO: Configurar para fazer migração apenas quando não for banco em meḿoria
            // if (context == null || context.Database.IsRelational()) return;
            
            // context.Database.Migrate();
            // context.Database.EnsureCreated();
        }
    }
}

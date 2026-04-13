using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Venue.Infrastructure;
using Venue.Infrastructure.DbContext;
using Venue.Infrastructure.Seeder;

namespace Venue.UI
{
    public static class AppBuilder
    {
        public static async Task<IServiceProvider> BuilderAsync(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDB(configuration);
            services.AddUserConfigration();

            services.AddScopes(configuration);

            var serviceProvider = services.BuildServiceProvider();

            await serviceProvider.SeedDatabaseAsync();

            return serviceProvider;
        }

        #region Scopes
        private static IServiceCollection AddScopes(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureScopes(configuration);

            #region UI Forms

            #endregion

            return services;
        }
        #endregion

        #region Db
        private static IServiceCollection ConfigureDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("Default"),
                    x => x.UseNetTopologySuite()
                );
            });

            return services;
        }

        public static async Task SeedDatabaseAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var seeder = scope.ServiceProvider.GetRequiredService<DataBaseSeeder>();

            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();

            await seeder.SeedAsync();
        }
        #endregion
    }
}

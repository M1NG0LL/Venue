using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Venue.Application;
using Venue.Domain.Interfaces;
using Venue.Infrastructure.DbContext;
using Venue.Infrastructure.Repositories;
using Venue.Infrastructure.Seeder;
using Venue.Infrastructure.Seeder.Users;

namespace Venue.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructureScopes(this IServiceCollection services, IConfiguration configuration)
        {
            #region Singleton Services
            services.AddSingleton<IPagination, Pagination>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            var connectionString = configuration.GetConnectionString("Default")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' was not found.");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            #region Scoped Services
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            #endregion

            #region Database Seeders
            services.AddScoped<DataBaseUsersSeeder>();
            services.AddScoped<DataBaseSeeder>();
            #endregion

            return services.AddApplication();
        }
    }
}

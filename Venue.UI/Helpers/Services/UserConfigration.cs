using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Venue.Domain.Common;
using Venue.Infrastructure.DbContext;
using Venue.Infrastructure.Factories;

namespace Venue.UI
{
    public static class UserConfigration
    {
        public static IServiceCollection AddUserConfigration(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = true;
            })
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IUserClaimsPrincipalFactory<User>, AppClaimsPrincipalFactory>();

            return services;
        }
    }
}

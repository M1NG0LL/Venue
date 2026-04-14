using Microsoft.Extensions.DependencyInjection;
using Venue.Application.Services.Account;
using Venue.Application.Services.Venue;

namespace Venue.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserPasswordService, UserPasswordService>();
            services.AddScoped<IVenueService, VenueService>();

            return services;
        }
    }
}

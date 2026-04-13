using Microsoft.Extensions.DependencyInjection;
using Venue.Application.Services.User;

namespace Venue.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}

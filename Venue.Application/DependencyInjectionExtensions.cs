using Microsoft.Extensions.DependencyInjection;

namespace Venue.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}

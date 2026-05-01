using Microsoft.Extensions.DependencyInjection;
using Venue.Application.Mapper.Admin;
using Venue.Application.Mapper.Common;
using Venue.Application.Mapper.Review;
using Venue.Application.Mapper.Venue;
using Venue.Application.Services.Account;
using Venue.Application.Services.Admin;
using Venue.Application.Services.Review;
using Venue.Application.Services.Venue;

namespace Venue.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(new Action<AutoMapper.IMapperConfigurationExpression>(cfg =>
            {
                cfg.AddProfile<AdminProfile>();
                cfg.AddProfile<CommonProfile>();
                cfg.AddProfile<VenueProfile>();
                cfg.AddProfile<ReviewProfile>();
            }));

                services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserPasswordService, UserPasswordService>();
            services.AddScoped<IVenueService, VenueService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IReviewService, ReviewService>();

            return services;
        }
    }
}

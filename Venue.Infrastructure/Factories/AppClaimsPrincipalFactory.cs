using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Venue.Domain.Common;

namespace Venue.Infrastructure.Factories
{
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, IdentityRole<Guid>>
    {
        public AppClaimsPrincipalFactory(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            var email = user.Email ?? string.Empty;

            identity.AddClaim(new Claim(ClaimTypes.Email, email));

            var role = (await UserManager.GetRolesAsync(user)).FirstOrDefault();

            if (role != null)
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            
            return identity;
        }
    }
}

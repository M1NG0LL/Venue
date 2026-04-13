using Microsoft.AspNetCore.Http;
using Venue.Domain.Common;
using Venue.Domain.Enums;
using Venue.Domain.Interfaces;

namespace Venue.Infrastructure.Repositories
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private string? _userId =>
            _httpContextAccessor.HttpContext?
            .User?
            .FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?
            .Value;

        Guid? ICurrentUserService.UserId => string.IsNullOrEmpty(_userId) ? null : Guid.Parse(_userId);

        private string? Role =>
            _httpContextAccessor.HttpContext?
            .User?
            .FindFirst(System.Security.Claims.ClaimTypes.Role)?
            .Value;

        UserRole ICurrentUserService.Role => string.IsNullOrEmpty(Role) ? UserRole.User : Enum.Parse<UserRole>(Role);

        private string? _email =>
            _httpContextAccessor.HttpContext?
            .User?
            .FindFirst(System.Security.Claims.ClaimTypes.Email)?
            .Value;

        public CurrentUser? GetCurrentUser()
        {
            if (_userId == null)
                return null;

            return new CurrentUser()
            {
                Id = Guid.Parse(_userId),
                Email = _email,
                UserRole = string.IsNullOrEmpty(Role) ? UserRole.User : Enum.Parse<UserRole>(Role)
            };
        }
    }
}

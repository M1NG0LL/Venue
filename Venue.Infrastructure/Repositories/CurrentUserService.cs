using Microsoft.AspNetCore.Http;
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
    }
}

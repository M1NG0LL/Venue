using Venue.Domain.Common;
using Venue.Domain.Enums;

namespace Venue.Domain.Interfaces
{
    public interface ICurrentUserService
    {
        Guid? UserId { get; }
        UserRole Role { get; }

        CurrentUser? GetCurrentUser();
    }
}

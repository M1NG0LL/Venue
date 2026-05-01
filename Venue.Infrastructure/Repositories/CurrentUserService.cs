using Microsoft.AspNetCore.Http;
using Venue.Domain.Common;
using Venue.Domain.Enums;
using Venue.Domain.Interfaces;

namespace Venue.Infrastructure.Repositories
{
    public class CurrentUserService : ICurrentUserService
    {
        private CurrentUser? _currentUser;

        public Guid? UserId => _currentUser?.Id;

        public UserRole Role => _currentUser?.UserRole ?? UserRole.User;

        public CurrentUser? GetCurrentUser()
        {
            return _currentUser;
        }

        public void SetCurrentUser(CurrentUser user)
        {
            _currentUser = user;
        }

        public void Logout()
        {
            _currentUser = null;
        }
    }
}

using Venue.Domain.Enums;

namespace Venue.Domain.Common
{
    public class CurrentUser
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public UserRole UserRole { get; set; } = UserRole.User;
    }
}

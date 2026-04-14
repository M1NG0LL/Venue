using Venue.Application.Dtos.Common;
using Venue.Domain.Enums;

namespace Venue.Application.Dto.User
{
    public class UserDto : BaseDto
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required UserRole UserRole { get; set; }
    }
}

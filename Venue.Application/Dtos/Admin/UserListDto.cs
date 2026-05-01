using Venue.Application.Dtos.Common;
using Venue.Domain.Enums;

namespace Venue.Application.Dtos.Admin
{
    public class AdminUserListDto
    {
        public List<AdminUserDto> Users { get; set; } = new List<AdminUserDto>();
    }

    public class AdminUserDto : BaseDto
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    }

    public class AdminSearchDto : BaseSearchDto
    {
        
    }
}

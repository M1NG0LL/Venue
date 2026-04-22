using Venue.Application.Dtos.Common;

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
    }

    public class AdminSearchDto : BaseSearchDto
    {
        
    }
}

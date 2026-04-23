using Venue.Application.Common;
using Venue.Application.Dtos.Admin;

namespace Venue.Application.Services.Admin
{
    public interface IAdminService
    {
        Task<PaginatedResponseBase<AdminUserListDto>> GetUsersAsync(AdminSearchDto dto, CancellationToken cancellationToken = default);
        Task<ResponseBase> DeleteUserAsync(AdminDeleteUserDto deleteUserDto, CancellationToken cancellationToken = default);
    }
}

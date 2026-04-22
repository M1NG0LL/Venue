using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Venue.Application.Common;
using Venue.Application.Dtos.Admin;
using Venue.Domain.Common;
using Venue.Domain.Interfaces;

namespace Venue.Application.Services.Admin
{
    public interface IAdminService
    {
        Task<PaginatedResponseBase<AdminUserListDto>> GetUsersAsync(AdminSearchDto dto, CancellationToken cancellationToken = default);
        Task<ResponseBase> DeleteUserAsync(AdminDeleteUserDto deleteUserDto, CancellationToken cancellationToken = default);
    }

    public class AdminService : IAdminService
    {
        private readonly UserManager<Domain.Common.User> _userManager;
        private readonly IMapper _mapper;
        private readonly IPagination _pagination;
        private readonly Guid _adminUserId;

        public AdminService(UserManager<User> userManager, IMapper mapper, IPagination pagination, ICurrentUserService currentUserService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _pagination = pagination;
            _adminUserId = currentUserService.UserId ?? throw new ArgumentNullException(nameof(currentUserService.UserId));
        }

        public async Task<PaginatedResponseBase<AdminUserListDto>> GetUsersAsync(AdminSearchDto dto, CancellationToken cancellationToken = default)
        {
            var usersQuery = _userManager.Users.Where(x => x.Id != _adminUserId);

            if (dto.SortByType == SortByType.Ascending)
                usersQuery = usersQuery.OrderBy(x => x.CreatedAt);
            else
                usersQuery = usersQuery.OrderByDescending(x => x.CreatedAt);

            var pagedUsers = await _pagination.PagedResultAsync(usersQuery, dto.PageNumber, dto.PageSize, cancellationToken);

            return PaginatedResponseBase<AdminUserListDto>.Success(
               pageNumber: dto.PageNumber,
               pageSize: dto.PageSize,
               data: new AdminUserListDto()
               {
                   Users = _mapper.Map<List<AdminUserDto>>(pagedUsers.Data)
               },
               totalCount: pagedUsers.TotalRecords,
               message: "Users retrieved successfully."
           );
        }

        public async Task<ResponseBase> DeleteUserAsync(AdminDeleteUserDto deleteUserDto, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == deleteUserDto.UserId, cancellationToken);
            if (user == null)
                return ResponseBase.Failure("User not found.");

            var result = await _userManager.DeleteAsync(user);
            if (result == null || !result.Succeeded)
                return ResponseBase.Failure("Failed to delete user.", result?.Errors.Select(e => e.Description).ToList());

            return ResponseBase.Success("User deleted successfully.");
        }
    }
}

using Venue.Application.Common;
using Venue.Application.Dto.User;
using Venue.Domain.Enums;

namespace Venue.Application.Services.Account
{
    public interface IUserService
    {
        Task<ResponseBase> RegisterAsync(RegisterDto dto, UserRole userRole = UserRole.User);
        Task<ResponseBase> LoginAsync(LoginDto dto);
        Task<ResponseBase<UserDto>> GetCurrentUser();
        Task<ResponseBase> LogoutAsync();
    }
}

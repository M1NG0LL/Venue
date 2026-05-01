using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Venue.Application.Common;
using Venue.Application.Dto.User;
using Venue.Domain.Common;
using Venue.Domain.Enums;
using Venue.Domain.Interfaces;

namespace Venue.Application.Services.Account
{
    public class UserService : IUserService
    {
        private readonly UserManager<Domain.Common.User> _userManager;
        private readonly ICurrentUserService _currentUserService;

        public UserService(UserManager<User> userManager, ICurrentUserService currentUserService)
        {
            _userManager = userManager;
            _currentUserService = currentUserService;
        }

        public async Task<ResponseBase> RegisterAsync(RegisterDto dto, UserRole userRole = UserRole.User)
        {
            var user = new Domain.Common.User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                return ResponseBase.Failure("User registration failed", result.Errors.Select(e => e.Description).ToList());
            
            var roleResult = await _userManager.AddToRoleAsync(user, userRole.ToString());

            if (!roleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);

                return ResponseBase.Failure("Role assignment failed", roleResult.Errors.Select(e => e.Description).ToList());
            }

            return ResponseBase.Success("User registered successfully");
        }

        public async Task<ResponseBase> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.UserNameOrEmail)
                    ?? await _userManager.FindByEmailAsync(dto.UserNameOrEmail);

            if (user == null)
                return ResponseBase.Failure("Invalid credentials");

            var valid = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!valid)
                return ResponseBase.Failure("Wrong password");

            var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            if (role == null)
                return ResponseBase.Failure("User has no assigned role");

            _currentUserService.SetCurrentUser(new CurrentUser()
            {
                Id = user.Id,
                Email = user.Email,
                UserRole = Enum.Parse<UserRole>(role!)
            });

            return ResponseBase.Success("Login successful");
        }

        public async Task<ResponseBase<UserDto>> GetCurrentUser()
        {
            var userId = _currentUserService.UserId;
            if (!userId.HasValue)
                return ResponseBase<UserDto>.Failure("No user is currently logged in");

            var user = await _userManager.FindByIdAsync(userId.ToString()!);

            if (user == null)
                return ResponseBase<UserDto>.Failure("User not found");

            return ResponseBase<UserDto>.Success(new UserDto()
            {
                Id = userId.Value,
                UserName = user.UserName!,
                Email = user.Email!,
                UserRole = _currentUserService.Role,
            });
        }

        public async Task<ResponseBase> LogoutAsync()
        {
            if (_currentUserService.UserId == null)
                return ResponseBase.Failure("No user is currently logged in");

            _currentUserService.Logout();

            return ResponseBase.Success("Logged out successfully");
        }
    }
}

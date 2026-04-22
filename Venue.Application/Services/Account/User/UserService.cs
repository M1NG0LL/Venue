using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Venue.Application.Common;
using Venue.Application.Dto.User;
using Venue.Domain.Enums;
using Venue.Domain.Interfaces;

namespace Venue.Application.Services.Account
{
    public class UserService : IUserService
    {
        private readonly Logger<UserService> logger;
        private readonly UserManager<Domain.Common.User> _userManager;
        private readonly SignInManager<Domain.Common.User> _signInManager;
        private readonly ICurrentUserService _currentUserService;

        public UserService(Logger<UserService> logger, UserManager<Domain.Common.User> userManager, SignInManager<Domain.Common.User> signInManager, ICurrentUserService currentUserService)
        {
            this.logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
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

            var result = await _signInManager.PasswordSignInAsync(
                user.UserName,
                dto.Password,
                isPersistent: true,
                lockoutOnFailure: true
            );

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                    return ResponseBase.Failure("Account is locked");

                if (result.IsNotAllowed)
                    return ResponseBase.Failure("Login not allowed");

                return ResponseBase.Failure("Invalid credentials");
            }

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

            await _signInManager.SignOutAsync();

            return ResponseBase.Success("Logged out successfully");
        }
    }
}

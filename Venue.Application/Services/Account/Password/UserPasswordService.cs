using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Venue.Application.Common;
using Venue.Application.Dtos.User;
using Venue.Domain.Common;
using Venue.Domain.Interfaces;

namespace Venue.Application.Services.Account
{
    public class UserPasswordService : IUserPasswordService
    {
        private readonly Logger<UserPasswordService> logger;
        private readonly UserManager<Domain.Common.User> _userManager;
        private readonly SignInManager<Domain.Common.User> _signInManager;
        private readonly ICurrentUserService _currentUserService;

        public UserPasswordService(Logger<UserPasswordService> logger, UserManager<Domain.Common.User> userManager, SignInManager<Domain.Common.User> signInManager, ICurrentUserService currentUserService)
        {
            this.logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _currentUserService = currentUserService;
        }

        public async Task<ResponseBase> ChangePasswordAsync(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            if (userId == null) 
                return ResponseBase.Failure("User not authenticated");

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
            if (user == null)
                return ResponseBase.Failure("User not found");

            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (!result.Succeeded)
                return ResponseBase.Failure("Password change failed");

            return ResponseBase.Success("Password changed successfully");
        }
    }
}

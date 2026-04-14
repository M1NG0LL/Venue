using Venue.Application.Common;
using Venue.Application.Dtos.User;

namespace Venue.Application.Services.Account
{
    public interface IUserPasswordService
    {
        Task<ResponseBase> ChangePasswordAsync(ChangePasswordRequest request, CancellationToken cancellationToken);
    }
}

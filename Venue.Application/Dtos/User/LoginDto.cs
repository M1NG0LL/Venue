namespace Venue.Application.Dto.User
{
    public class LoginDto
    {
        public required string UserNameOrEmail { get; set; }
        public required string Password { get; set; }
    }
}

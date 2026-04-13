using Microsoft.AspNetCore.Identity;

namespace Venue.Domain.Common
{
    public class User : IdentityUser<Guid>
    {
        public Guid? CreatedBy { get; set; } = null;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? UpdatedBy { get; set; } = null;
        public DateTime? UpdatedAt { get; set; } = null;
    }
}

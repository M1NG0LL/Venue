using System.ComponentModel.DataAnnotations.Schema;

namespace Venue.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(CreatedBy))]
        public Guid? CreatedById { get; set; } = null;
        public User? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(UpdatedBy))]
        public Guid? UpdatedById { get; set; } = null;
        public User? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;
    }
}

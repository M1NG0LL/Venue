using System.ComponentModel.DataAnnotations.Schema;
using Venue.Domain.Common;

namespace Venue.Domain.Entities
{
    public class Review : BaseEntity
    {
        [ForeignKey(nameof(Venue))]
        public required Guid VenueId { get; set; }
        public VenueEntity? Venue { get; set; }
        public required int Rate { get; set; } = 0;
        public string? Comment { get; set; } = null;
    }
}

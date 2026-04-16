using NetTopologySuite.Geometries;
using Venue.Domain.Common;

namespace Venue.Domain.Entities
{
    public class VenueEntity : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? ImagePath { get; set; } = null;
        public required VenueContactInfo ContactInfo { get; set; }
        public required VenueConfiguration Info { get; set; }

        public List<Review>? Reviews { get; set; }
    }

    public class VenueContactInfo
    {
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required Point Location { get; set; }
        public string? Address { get; set; }
    }

    public class VenueConfiguration
    {
        public required List<DayOfWeek> AvailableDays { get; set; }
        public required int SeatingCapacity { get; set; }
        public required decimal PricePerEvent { get; set; }
    }
}

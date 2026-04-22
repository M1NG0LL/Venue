using Venue.Application.Dtos.Common;
using Venue.Application.Dtos.Review;

namespace Venue.Application.Dtos.Venue
{
    public class VenueDto : BaseDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? ImagePath { get; set; }

        public required VenueContactInfoDto ContactInfo { get; set; }
        public required VenueConfigurationDto Info { get; set; }

        public List<ReviewDto> Reviews { get; set; } = new();

        public required int TotalRating { get; set; }
        public required double Rating { get; set; }
    }

    public class VenueContactInfoDto
    {
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required LocationDto Location { get; set; }
        public string? Address { get; set; }
    }

    public class VenueConfigurationDto
    {
        public required List<DayOfWeek> AvailableDays { get; set; } = new();
        public required int SeatingCapacity { get; set; }
        public required decimal PricePerEvent { get; set; }
    }
}

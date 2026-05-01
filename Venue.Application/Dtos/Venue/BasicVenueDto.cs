using Venue.Application.Dtos.Common;

namespace Venue.Application.Dtos.Venue
{
    public class BasicVenueDto : BaseDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? ImagePath { get; set; }

        public required int TotalRating { get; set; } = 0;
        public required double Rating { get; set; } = 0;
    }

    public class BasicOwnerVenueDto : BaseDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string Address { get; set; } = string.Empty;

        public required int SeatingCapacity { get; set; }
        public required decimal PricePerEvent { get; set; }
    }

    public class VenueSearchDto : BaseSearchDto
    {
        
    }
}

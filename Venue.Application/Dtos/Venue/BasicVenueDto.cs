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

    public class VenueSearchDto : BaseSearchDto
    {
        
    }
}

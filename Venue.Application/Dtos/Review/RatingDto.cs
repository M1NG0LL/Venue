using Venue.Application.Dtos.Common;

namespace Venue.Application.Dtos.Review
{
    public class ReviewDto : BaseDto
    {
        public Guid VenueId { get; set; }
        public string VenueName { get; set; } = "N/A";

        public int Rate { get; set; } = 0;
        public string? Comment { get; set; } = null;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class ReviewSearchDto : BaseSearchDto
    {

    }
}

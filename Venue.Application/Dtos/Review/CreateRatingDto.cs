namespace Venue.Application.Dtos.Review
{
    public class CreateReviewDto
    {
        public required Guid VenueId { get; set; }
        public required int Rate { get; set; }
        public string? Comment { get; set; } 
    }
}

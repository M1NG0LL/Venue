namespace Venue.Application.Dtos.Venue
{
    public class CreateVenueDto 
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? ImagePath { get; set; }

        public required VenueContactInfoDto ContactInfo { get; set; }
        public required VenueConfigurationDto Info { get; set; }
    }
}

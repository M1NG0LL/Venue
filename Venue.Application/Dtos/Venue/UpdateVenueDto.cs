using Venue.Application.Dtos.Common;

namespace Venue.Application.Dtos.Venue
{
    public class UpdateVenueDto : CreateVenueDto, BaseUpdateDto
    {
        public required Guid Id { get; set; }
    }
}

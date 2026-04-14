using Venue.Application.Common;
using Venue.Application.Dtos.Venue;

namespace Venue.Application.Services.Venue
{
    public interface IVenueService
    {
        Task<ResponseBase> CreateAsync(CreateVenueDto dto, CancellationToken cancellationToken = default);
        Task<ResponseBase> UpdateAsync(UpdateVenueDto dto, CancellationToken cancellationToken = default);
        Task<ResponseBase> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<ResponseBase<VenueDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<PaginatedResponseBase<List<BasicVenueDto>>> SearchAsync(VenueSearchDto dto, CancellationToken cancellationToken = default);

        Task<PaginatedResponseBase<List<BasicVenueDto>>> GetFeaturedVenuesAsync(VenueSearchDto dto, CancellationToken cancellationToken = default);
    }
}

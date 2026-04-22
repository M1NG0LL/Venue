using Venue.Application.Common;
using Venue.Application.Dtos.Review;

namespace Venue.Application.Services.Review
{
    public interface IReviewService
    {
        Task<ResponseBase> CreateAsync(ReviewDto dto, CancellationToken cancellationToken = default);

        Task<PaginatedResponseBase<List<ReviewDto>>> GetAsync(ReviewSearchDto dto, CancellationToken cancellationToken = default);

        Task<PaginatedResponseBase<List<ReviewDto>>> GetReviewsFromVenueIdAsync(ReviewSearchDto dto, Guid venueId, CancellationToken cancellationToken = default);
    }
}

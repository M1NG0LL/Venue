using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Venue.Application.Common;
using Venue.Application.Dtos.Review;
using Venue.Application.Dtos.Venue;
using Venue.Domain.Interfaces;

namespace Venue.Application.Services.Review
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Domain.Entities.Review> _repository;
        private readonly IRepository<Domain.Entities.VenueEntity> _venueRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        private readonly IPagination _pagination;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IRepository<Domain.Entities.Review> repository, IRepository<Domain.Entities.VenueEntity> venueRepository, ICurrentUserService currentUserService, IMapper mapper, IPagination pagination, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _venueRepository = venueRepository;
            _currentUserService = currentUserService;
            _mapper = mapper;
            _pagination = pagination;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseBase> CreateAsync(ReviewDto dto, CancellationToken cancellationToken = default)
        {
            #region Validation
            if (dto == null) 
                throw new ArgumentNullException(nameof(dto));

            if (dto.Rate < 1 || dto.Rate > 5)
                return ResponseBase.Failure("Rate must be between 1 and 5");
            #endregion

            var entity = _mapper.Map<Domain.Entities.Review>(dto);

            await _repository.AddAsync(entity, cancellationToken);

            if (!await _unitOfWork.SaveChangesAsync(cancellationToken))
                return ResponseBase.Failure("Failed to create review");

            return ResponseBase.Success("Review created successfully");
        }

        public async Task<PaginatedResponseBase<List<ReviewDto>>> GetAsync(ReviewSearchDto dto, CancellationToken cancellationToken = default)
        {
            var userId = _currentUserService.UserId ?? throw new InvalidOperationException("User ID is not available"); ;

            var query = _repository.Get(x => x.CreatedById == userId, isNoTracking:true);

            if (!string.IsNullOrEmpty(dto.SearchText))
                query = query.Where(x => x.Comment != null && x.Comment.Contains(dto.SearchText));
            
            if (dto.SortByType == SortByType.Ascending)
                query = query.OrderBy(x => x.CreatedAt);
            else if (dto.SortByType == SortByType.Descending)
                query = query.OrderByDescending(x => x.CreatedAt);

            var paginatedResult = await _pagination.PagedResultAsync(query.Include(x => x.Venue), dto.PageNumber, dto.PageSize, cancellationToken);

            return PaginatedResponseBase<List<ReviewDto>>.Success(
                pageNumber: dto.PageNumber,
                pageSize: dto.PageSize,
                data: _mapper.Map<List<ReviewDto>>(paginatedResult.Data),
                totalCount: paginatedResult.TotalRecords,
                message: "Reviews retrieved successfully."
            );
        }

        public async Task<PaginatedResponseBase<List<ReviewDto>>> GetReviewsFromVenueIdAsync(ReviewSearchDto dto, Guid venueId, CancellationToken cancellationToken = default)
        {
            var query = _repository.Get(x => x.VenueId == venueId, isNoTracking: true);

            if (!string.IsNullOrEmpty(dto.SearchText))
                query = query.Where(x => x.Comment != null && x.Comment.Contains(dto.SearchText));

            if (dto.SortByType == SortByType.Ascending)
                query = query.OrderBy(x => x.CreatedAt);
            else if (dto.SortByType == SortByType.Descending)
                query = query.OrderByDescending(x => x.CreatedAt);

            var paginatedResult = await _pagination.PagedResultAsync(query.Include(x => x.Venue), dto.PageNumber, dto.PageSize, cancellationToken);

            return PaginatedResponseBase<List<ReviewDto>>.Success(
                pageNumber: dto.PageNumber,
                pageSize: dto.PageSize,
                data: _mapper.Map<List<ReviewDto>>(paginatedResult.Data),
                totalCount: paginatedResult.TotalRecords,
                message: "Reviews retrieved successfully."
            );
        }
    }
}

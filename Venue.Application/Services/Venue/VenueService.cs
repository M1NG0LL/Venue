using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Venue.Application.Common;
using Venue.Application.Dtos.Common;
using Venue.Application.Dtos.Venue;
using Venue.Domain.Entities;
using Venue.Domain.Interfaces;

namespace Venue.Application.Services.Venue
{
    public class VenueService : IVenueService
    {
        private readonly IRepository<VenueEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPagination _pagination;
        private readonly Guid _userId;

        public VenueService(IRepository<VenueEntity> repository, IUnitOfWork unitOfWork, IMapper mapper, IPagination pagination, Guid userId)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _pagination = pagination;
            _userId = userId;
        }

        #region Create, Update & Delete
        public async Task<ResponseBase> CreateAsync(CreateVenueDto dto, CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<VenueEntity>(dto);

            await _repository.AddAsync(entity, cancellationToken);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken))
                return ResponseBase.Success("Venue created successfully.");
            else
                return ResponseBase.Failure("Failed to create venue.");
        }

        public async Task<ResponseBase> UpdateAsync(UpdateVenueDto dto, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.GetByIdAsync(dto.Id, cancellationToken);

            if (entity == null)
                return ResponseBase.Failure("Venue not found.");

            _mapper.Map(dto, entity);

            if (await _unitOfWork.SaveChangesAsync())
                return ResponseBase.Success("Venue updated successfully.");
            else
                return ResponseBase.Failure("Failed to update venue.");
        }

        public async Task<ResponseBase> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.GetByIdAsync(id, cancellationToken);

            if (entity == null)
                return ResponseBase.Failure("Venue not found.");

            await _repository.DeleteAsync(id, cancellationToken);

            if (await _unitOfWork.SaveChangesAsync())
                return ResponseBase.Success("Venue deleted successfully.");
            else
                return ResponseBase.Failure("Failed to delete venue.");
        }
        #endregion

        #region Get
        public async Task<ResponseBase<VenueDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.Get(x => x.Id == id)
                .AsNoTracking()
                .Include(x => x.Reviews)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
                return ResponseBase<VenueDto>.Failure("Venue not found.");

            var dto = MappingVenueDto(entity);  

            return ResponseBase<VenueDto>.Success(dto);
        }

        public async Task<PaginatedResponseBase<List<BasicVenueDto>>> GetFeaturedVenuesAsync(VenueSearchDto dto, CancellationToken cancellationToken = default)
        {
            var venueQuery = _repository.GetQuery()
                    .AsNoTracking()
                    .Include(v => v.Reviews)
                    .Select(v => new
                    {
                        Venue = v,
                        AvgRating = v.Reviews.Count > 0 ? v.Reviews.Average(r => r.Rate) : 0
                    });

            if (dto.SortByType == SortByType.Ascending)
                venueQuery = venueQuery.OrderBy(v => v.AvgRating);
            else if (dto.SortByType == SortByType.Descending)
                venueQuery = venueQuery.OrderByDescending(v => v.AvgRating);

            var venues = venueQuery.Select(x => x.Venue);

            var pagedVenues = await _pagination.PagedResultAsync(venues, dto.PageNumber, dto.PageSize, cancellationToken);
            var basicVenueDtos = MappingBasicVenueDto(pagedVenues.Data);

            return PaginatedResponseBase<List<BasicVenueDto>>.Success(
                pageNumber: dto.PageNumber,
                pageSize: dto.PageSize,
                data: basicVenueDtos,
                totalCount: pagedVenues.TotalRecords,
                message: "Featured venues retrieved successfully."
            );
        }

        public async Task<PaginatedResponseBase<List<BasicVenueDto>>> SearchAsync(VenueSearchDto dto, CancellationToken cancellationToken = default)
        {
            var venueQuery = _repository.Get(x => 
                (string.IsNullOrEmpty(dto.SearchText) || 
                    x.Name.Contains(dto.SearchText) || 
                    x.Description.Contains(dto.SearchText)
                )       
                , isNoTracking: true
            ).Include(x => x.Reviews)
            .Select(v => new
            {
                Venue = v,
                AvgRating = v.Reviews.Count > 0 ? v.Reviews.Average(r => r.Rate) : 0
            });

            if (dto.SortByType == SortByType.Ascending)
                venueQuery = venueQuery.OrderBy(v => v.AvgRating);
            else if (dto.SortByType == SortByType.Descending)
                venueQuery = venueQuery.OrderByDescending(v => v.AvgRating);

            var venues = venueQuery.Select(x => x.Venue);

            var pagedVenues = await _pagination.PagedResultAsync(venues, dto.PageNumber, dto.PageSize, cancellationToken);
            var basicVenueDtos = MappingBasicVenueDto(pagedVenues.Data);

            return PaginatedResponseBase<List<BasicVenueDto>>.Success(
                pageNumber: dto.PageNumber,
                pageSize: dto.PageSize,
                data: basicVenueDtos,
                totalCount: pagedVenues.TotalRecords,
                message: "Featured venues retrieved successfully."
            );
        }

        #region Private Methods
        private List<BasicVenueDto> MappingBasicVenueDto(List<VenueEntity> venues)
        {
            return venues.Select(v => new BasicVenueDto
            {
                Id = v.Id,
                Name = v.Name,
                Description = v.Description,
                ImagePath = v.ImagePath,

                Rating = v.Reviews != null && v.Reviews.Count > 0 ? v.Reviews.Average(r => r.Rate) : 0,
                TotalRating = v.Reviews != null ? v.Reviews.Count : 0
            }).ToList();
        }

        private VenueDto MappingVenueDto(VenueEntity venue)
        {
            return new VenueDto
            {
                Id = venue.Id,
                Name = venue.Name,
                Description = venue.Description,
                ImagePath = venue.ImagePath,

                ContactInfo = new VenueContactInfoDto
                {
                    Address = venue.ContactInfo.Address,
                    Phone = venue.ContactInfo.Phone,
                    Email = venue.ContactInfo.Email,
                    Location = _mapper.Map<LocationDto>(venue.ContactInfo.Location),
                },

                Info = new VenueConfigurationDto
                {
                    AvailableDays = venue.Info.AvailableDays,
                    PricePerEvent = venue.Info.PricePerEvent,
                    SeatingCapacity = venue.Info.SeatingCapacity,
                },

                Rating = venue.Reviews != null && venue.Reviews.Count > 0 ? venue.Reviews.Average(r => r.Rate) : 0,
                TotalRating = venue.Reviews != null ? venue.Reviews.Count : 0
            };
        }
        #endregion
        #endregion
    }
}

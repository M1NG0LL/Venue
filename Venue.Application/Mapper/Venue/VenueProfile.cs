using AutoMapper;
using Venue.Application.Dtos.Venue;
using Venue.Domain.Entities;

namespace Venue.Application.Mapper.Venue
{
    internal class VenueProfile : Profile
    {
        public VenueProfile()
        {
            CreateMap<CreateVenueDto, VenueEntity>()
                .ReverseMap();

            CreateMap<UpdateVenueDto, VenueEntity>()
                .ReverseMap();

            CreateMap<VenueContactInfoDto, VenueContactInfo>()
                .ReverseMap();

            CreateMap<VenueConfigurationDto, VenueConfiguration>()
                .ReverseMap();
        }
    }
}

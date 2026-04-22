using AutoMapper;
using NetTopologySuite.Geometries;
using Venue.Application.Dtos.Common;

namespace Venue.Application.Mapper.Common
{
    internal class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<Point, LocationDto>()
                .ForMember(dest => dest.X, opt => opt.MapFrom(src => src.X))
                .ForMember(dest => dest.Y, opt => opt.MapFrom(src => src.Y));
        }
    }
}

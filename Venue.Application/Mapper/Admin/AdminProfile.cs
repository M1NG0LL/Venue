using AutoMapper;
using Venue.Application.Dtos.Admin;

namespace Venue.Application.Mapper.Admin
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<Domain.Common.User, AdminUserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();
        }
    }
}

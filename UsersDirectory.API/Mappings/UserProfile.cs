using AutoMapper;
using UsersDirectory.API.Dto;
using UsersDirectory.API.Entities;

namespace UsersDirectory.API.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));
        }
    }
}

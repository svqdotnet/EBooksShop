using AutoMapper;
using LoginAPI.Dtos;
using LoginAPI.Models;
 
namespace LoginAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
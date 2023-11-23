using AutoMapper;
using Entities;
using Entities.Dtos;

namespace CrudApi.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateUserDTO, User>();
            CreateMap<UpdateUserDto, User>().ReverseMap();
        }
    }
}

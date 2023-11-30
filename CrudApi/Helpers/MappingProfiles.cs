using AutoMapper;
using Entities;
using Entities.BusEvents;
using Entities.Dtos;

namespace CrudApi.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateUserDTO, User>();
            CreateMap<UpdateUserDto, User>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<User, PersonCreated>().ReverseMap();
            CreateMap<PersonUpdated, User>().ReverseMap();
        }
    }
}

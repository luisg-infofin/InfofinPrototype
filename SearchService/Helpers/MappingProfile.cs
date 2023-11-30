using AutoMapper;
using Entities.BusEvents;
using SearchService.Models;

namespace SearchService.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonCreated, Item>().ReverseMap();            
            CreateMap<PersonUpdated, Item>().ReverseMap();
        }
    }
}
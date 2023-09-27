using AutoMapper;
using Base.Proyecto.Common.Dto.Person;
using Base.Proyecto.Infraestructure.Models;

namespace Base.Proyecto.Common.Utils
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // ==== Person
            CreateMap<Person, AddPersonDto>().ReverseMap();
        }
    }
}
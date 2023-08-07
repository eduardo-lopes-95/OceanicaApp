using AutoMapper;
using oceanica_app.Dtos;
using oceanica_app.Models;

namespace oceanica_app.Profiles;

public class DepartamentProfile : Profile
{
    public DepartamentProfile()
    {
        CreateMap<CreateDepartamentDto, Departament>().ReverseMap();
        CreateMap<UpdateDepartamentDto, Departament>().ReverseMap();
        CreateMap<ReadDepartamentDto, Departament>().ReverseMap()
            .ForMember(dto => dto.Crew,
            opt => opt.MapFrom(departament => departament.Crew));
    }
}

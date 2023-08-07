using AutoMapper;
using oceanica_app.Dtos;
using oceanica_app.Models;

namespace oceanica_app.Profiles;

public class VesselProfile : Profile
{
    public VesselProfile()
    {
        CreateMap<CreateVesselDto, Vessel>().ReverseMap();
        CreateMap<UpdateVesselDto, Vessel>().ReverseMap();
        CreateMap<ReadVesselDto, Vessel>().ReverseMap()
            .ForMember(dto => dto.Departaments,
            opt => opt.MapFrom(vessel => vessel.Departaments));
    }
}

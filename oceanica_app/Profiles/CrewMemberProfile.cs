using AutoMapper;
using oceanica_app.Dtos;
using oceanica_app.Models;

namespace oceanica_app.Profiles;

public class CrewMemberProfile : Profile
{
    public CrewMemberProfile()
    {
        CreateMap<CreateCrewMemberDto, CrewMember>().ReverseMap();
        CreateMap<UpdateCrewMemberDto, CrewMember>().ReverseMap();
        CreateMap<ReadCrewMemberDto, CrewMember>().ReverseMap();
    }
}

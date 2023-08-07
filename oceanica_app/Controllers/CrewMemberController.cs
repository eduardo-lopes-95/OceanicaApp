using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using oceanica_app.Dtos;
using oceanica_app.Models;
using oceanica_app.Repository.Abstract;

namespace oceanica_app.Controllers;
[Route("[controller]")]
[ApiController]
public class CrewMemberController : ControllerBase
{
    public IMapper Mapper;
    public IRepository<CrewMember> CrewMemberRepository;

    public CrewMemberController(IMapper mapper, IRepository<CrewMember> crewMemberRepository)
    {
        Mapper = mapper;
        CrewMemberRepository = crewMemberRepository;
    }

    [HttpGet]
    public IActionResult GetCrewMembers([FromQuery] int page = 0, [FromQuery] int qtde = 10)
    {
        var crewMembers = CrewMemberRepository.GetAll(page, qtde);
        if (!crewMembers.Any())
            return NotFound();
        return Ok(Mapper.Map<ICollection<ReadCrewMemberDto>>(crewMembers));
    }

    [HttpGet("id")]
    public IActionResult GetCrewMembersById(int id)
    {
        var crewMember = CrewMemberRepository.GetById(id);
        if (crewMember is null)
            return NotFound();
        return Ok(Mapper.Map<ReadCrewMemberDto>(crewMember));
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateCrewMemberDto dto)
    {
        var crewMember = Mapper.Map<CrewMember>(dto);
        var crewMemberInserted = CrewMemberRepository.Insert(crewMember);
        return CreatedAtAction(nameof(GetCrewMembersById), new { crewMemberInserted.Id }, dto);
    }

    [HttpPut]
    public IActionResult Put([FromBody] UpdateCrewMemberDto dto)
    {
        var crewMember = Mapper.Map<CrewMember>(dto);
        var crewMemberInserted = CrewMemberRepository.Update(crewMember);
        return Ok(Mapper.Map<ReadCrewMemberDto>(crewMemberInserted));
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        CrewMemberRepository.DeleteById(id);
        return NoContent();
    }
}

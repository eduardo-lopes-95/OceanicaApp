using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using oceanica_app.Dtos;
using oceanica_app.Models;
using oceanica_app.Repository.Abstract;

namespace oceanica_app.Controllers;
[Route("[controller]")]
[ApiController]
public class DepartamentController : ControllerBase
{
    public IMapper Mapper;
    public IRepository<Departament> DepartamentRepository;

    public DepartamentController(IRepository<Departament> departamentRepository, IMapper mapper)
    {
        DepartamentRepository = departamentRepository;
        Mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetDepartaments([FromQuery] int page = 0, [FromQuery] int qtde = 10)
    {
        var departaments = DepartamentRepository.GetAll(page, qtde);
        if (!departaments.Any())
            return NotFound();
        return Ok(Mapper.Map<ICollection<ReadDepartamentDto>>(departaments));
    }

    [HttpGet("id")]
    public IActionResult GetDepartamentsById(int id)
    {
        var departament = DepartamentRepository.GetById(id);
        if (departament is null)
            return NotFound();
        return Ok(Mapper.Map<ReadDepartamentDto>(departament));
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateDepartamentDto dto)
    {
        var departament = Mapper.Map<Departament>(dto);
        var departamentInserted = DepartamentRepository.Insert(departament);
        return CreatedAtAction(nameof(GetDepartamentsById), new { departamentInserted.Id }, dto);
    }

    [HttpPut]
    public IActionResult Put([FromBody] UpdateDepartamentDto dto)
    {
        var departament = Mapper.Map<Departament>(dto);
        var departamentInserted = DepartamentRepository.Update(departament);
        return Ok(Mapper.Map<ReadDepartamentDto>(departamentInserted));
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        DepartamentRepository.DeleteById(id);
        return NoContent();
    }
}

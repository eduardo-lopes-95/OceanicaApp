namespace oceanica_app.Dtos;

public class ReadDepartamentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<ReadCrewMemberDto> Crew { get; set; }
}

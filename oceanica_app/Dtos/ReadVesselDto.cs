namespace oceanica_app.Dtos;

public class ReadVesselDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public DateTime BuildAt { get; set; }
    public virtual ICollection<ReadDepartamentDto> Departaments { get; set; }
    public string? PhotoFileName { get; set; }
}

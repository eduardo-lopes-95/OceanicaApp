namespace oceanica_app.Models;

public class Vessel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public DateTime BuildAt { get; set; }
    public virtual ICollection<Departament> Departaments { get; set; }
    public string? PhotoFileName { get; set; }
}

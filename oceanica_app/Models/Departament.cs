namespace oceanica_app.Models;

public class Departament
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int VesselId { get; set; }
    public virtual Vessel Vessel { get; set; }
    public virtual ICollection<CrewMember> Crew { get; set; }
}

using Microsoft.EntityFrameworkCore;
using oceanica_app.Models;

namespace oceanica_app.Data;

public class OceanicaContext : DbContext
{
    public OceanicaContext(DbContextOptions options) : base(options)
    {
        base.Database.Migrate();
        base.Database.EnsureCreated();
    }

    public DbSet<Vessel> Vessels { get; set; }
    public DbSet<Departament> Departaments { get; set; }
    public DbSet<CrewMember> Crews { get; set; }
}

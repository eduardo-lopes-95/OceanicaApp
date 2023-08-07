using oceanica_app.Data;
using oceanica_app.Models;
using oceanica_app.Repository.Abstract;

namespace oceanica_app.Repository;

public class CrewMemberRepository : IRepository<CrewMember>
{
    public OceanicaContext Context;

    public CrewMemberRepository(OceanicaContext context)
    {
        Context = context;
    }

    public ICollection<CrewMember> GetAll(int skip, int take)
    {
        return Context.Crews.Skip(skip).Take(take).ToList();
    }

    public CrewMember GetById(int id)
    {
        return Context.Crews.Find(id);
    }

    public CrewMember Insert(CrewMember entity)
    {
        Context.Crews.Add(entity);
        Context.SaveChanges();
        return entity;
    }

    public CrewMember Update(CrewMember entity)
    {
        var entityFound = Context.Crews.Find(entity.Id);
        if (entityFound == null)
            return null;

        Context.Entry(entityFound).CurrentValues.SetValues(entity);

        Context.SaveChangesAsync();
        return entityFound;
    }

    public void DeleteById(int id)
    {
        var entity = GetById(id);
        Context.Crews.Remove(entity);
    }
}

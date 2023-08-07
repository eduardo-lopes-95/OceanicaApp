namespace oceanica_app.Repository.Abstract;

public interface IRepository<T>
{
    ICollection<T> GetAll(int skip, int take);
    T GetById(int id);
    T Update(T entity);
    T Insert(T entity);
    void DeleteById(int id);
}

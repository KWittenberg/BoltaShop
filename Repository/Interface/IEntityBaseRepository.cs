namespace BoltaShop.Repository.Interface;

public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
{
    Task<IEnumerable<T>> Get();
    Task<IEnumerable<T>> Get(params Expression<Func<T, object>>[] includeProperties);
    Task<T> GetById(int id);
    Task<T> GetById(int id, params Expression<Func<T, object>>[] includeProperties);
    Task Insert(T entity);
    Task Update(int id, T entity);
    Task Delete(int id);
}
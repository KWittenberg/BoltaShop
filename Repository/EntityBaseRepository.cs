namespace BoltaShop.Repository;

public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
{
    private readonly ApplicationDbContext db;
    public EntityBaseRepository(ApplicationDbContext db)
    {
        this.db = db;
    }


    public async Task<IEnumerable<T>> Get() => await this.db.Set<T>().ToListAsync();

    public async Task<IEnumerable<T>> Get(params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = this.db.Set<T>();
        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        return await query.ToListAsync();

    }


    public async Task<T> GetById(int id) => await this.db.Set<T>().FirstOrDefaultAsync(n => n.Id == id);

    public async Task<T> GetById(int id, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = this.db.Set<T>();
        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        return await query.FirstOrDefaultAsync(n => n.Id == id);
    }


    public async Task Insert(T entity)
    {
        await this.db.Set<T>().AddAsync(entity);
        await this.db.SaveChangesAsync();
    }

    public async Task Update(int id, T entity)
    {
        EntityEntry entityEntry = this.db.Entry<T>(entity);
        entityEntry.State = EntityState.Modified;

        await this.db.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await this.db.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
        EntityEntry entityEntry = this.db.Entry<T>(entity);
        entityEntry.State = EntityState.Deleted;

        await this.db.SaveChangesAsync();
    }
}
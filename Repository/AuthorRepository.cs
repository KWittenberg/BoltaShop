namespace BoltaShop.Repository;

public class AuthorRepository : EntityBaseRepository<Author>, IAuthorRepository
{
    public AuthorRepository(ApplicationDbContext db) : base(db)
    {
    }
}
using BoltaShop.Data;
using BoltaShop.Models.Dbo;
using BoltaShop.Repository.Interface;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;

namespace BoltaShop.Repository
{
    public class AuthorRepository : EntityBaseRepository<Author>, IAuthorRepository
    {
        
        public AuthorRepository(ApplicationDbContext db) : base(db)
        {
            
        }
        
    }
}

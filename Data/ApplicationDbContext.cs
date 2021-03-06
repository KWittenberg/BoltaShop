namespace BoltaShop.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthorBook>().HasKey(ab => new { ab.AuthorId, ab.BookId });
        modelBuilder.Entity<AuthorBook>().HasOne(b => b.Book).WithMany(ab => ab.AuthorsBooks).HasForeignKey(b => b.BookId);
        modelBuilder.Entity<AuthorBook>().HasOne(b => b.Author).WithMany(ab => ab.AuthorsBooks).HasForeignKey(b => b.AuthorId);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<AuthorBook> AuthorsBooks { get; set; }


    //Orders related tables
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
}
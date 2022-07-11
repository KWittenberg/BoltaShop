namespace BoltaShop.Data.Cart;

public class ShoppingCart
{
    public ApplicationDbContext db { get; set; }

    public string ShoppingCartId { get; set; }
    public List<ShoppingCartItem> ShoppingCartItems { get; set; }

    public ShoppingCart(ApplicationDbContext db)
    {
        this.db = db;
    }

    public static ShoppingCart GetShoppingCart(IServiceProvider services)
    {
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        var context = services.GetService<ApplicationDbContext>();

        string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
        session.SetString("CartId", cartId);

        return new ShoppingCart(context) { ShoppingCartId = cartId };
    }

    public void AddItemToCart(Book book)
    {
        var shoppingCartItem = this.db.ShoppingCartItems.FirstOrDefault(n => n.Book.Id == book.Id && n.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem == null)
        {
            shoppingCartItem = new ShoppingCartItem()
            {
                ShoppingCartId = ShoppingCartId,
                Book = book,
                Amount = 1
            };

            this.db.ShoppingCartItems.Add(shoppingCartItem);
        }
        else
        {
            shoppingCartItem.Amount++;
        }
        this.db.SaveChanges();
    }

    public void RemoveItemFromCart(Book book)
    {
        var shoppingCartItem = this.db.ShoppingCartItems.FirstOrDefault(n => n.Book.Id == book.Id && n.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem != null)
        {
            if (shoppingCartItem.Amount > 1)
            {
                shoppingCartItem.Amount--;
            }
            else
            {
                this.db.ShoppingCartItems.Remove(shoppingCartItem);
            }
        }
        this.db.SaveChanges();
    }

    public List<ShoppingCartItem> GetShoppingCartItems()
    {
        return ShoppingCartItems ?? (ShoppingCartItems = this.db.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Book).ToList());
    }

    public double GetShoppingCartTotal() => this.db.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Book.Cijena * n.Amount).Sum();

    public async Task ClearShoppingCartAsync()
    {
        var items = await this.db.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
        this.db.ShoppingCartItems.RemoveRange(items);
        await this.db.SaveChangesAsync();
    }
}
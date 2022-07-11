namespace BoltaShop.Models.Dbo;

public class ShoppingCartItem
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("BookId")]
    public Book Book { get; set; }
    public int BookId { get; set; }

    public int Amount { get; set; }
    
    public string ShoppingCartId { get; set; }
}
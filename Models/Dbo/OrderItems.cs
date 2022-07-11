namespace BoltaShop.Models.Dbo;

public class OrderItem
{
    [Key]
    public int Id { get; set; }

    public int Amount { get; set; }
    public double Cijena { get; set; }

    [ForeignKey("BookId")]
    public Book Book { get; set; }
    public int BookId { get; set; }
    
    [ForeignKey("OrderId")]
    public Order Order { get; set; }
    public int OrderId { get; set; }
}
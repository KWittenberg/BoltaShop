namespace BoltaShop.Models.Base;

public abstract class EntityBase
{
    public int Id { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public bool Valid { get; set; }
}
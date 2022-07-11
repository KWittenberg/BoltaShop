namespace BoltaShop.Models.Dbo;

public class ApplicationUser : IdentityUser
{
    public string Ime { get; set; }
    public string Prezime { get; set; }
}

namespace BoltaShop.Models.Dbo;

public class Author : IEntityBase
{
    public int Id { get; set; }
    public string? Slika { get; set; }

    [Required(ErrorMessage = "Ime je obavezno !")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Ime - min 3 and max 50 chars !")]
    public string Ime { get; set; }

    [Required(ErrorMessage = "Prezime je obavezno !")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Prezime - min 3 and max 50 chars !")]
    public string Prezime { get; set; }

    [ValidateNever]
    public string? Opis { get; set; }

    //Relationships
    [ValidateNever]
    public List<AuthorBook> AuthorsBooks { get; set; }
}

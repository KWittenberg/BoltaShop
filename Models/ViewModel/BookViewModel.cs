namespace BoltaShop.Models.ViewModel;

public class BookViewModel : Book
{
    // Relationships to AuthorIds
    public List<int> AuthorIds { get; set; }
}
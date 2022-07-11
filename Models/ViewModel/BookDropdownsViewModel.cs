namespace BoltaShop.Models.ViewModel;

public class BookDropdownsViewModel
{
    public BookDropdownsViewModel()
    {
        Authors = new List<Author>();
    }
    
    public List<Author> Authors { get; set; }
}
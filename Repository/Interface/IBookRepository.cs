namespace BoltaShop.Repository.Interface;

public interface IBookRepository : IEntityBaseRepository<Book>
{
    Task<Book> GetBookById(int id);
    Task<BookDropdownsViewModel> GetBookDropdownsValues();
    Task AddNewBook(BookViewModel data);
    Task UpdateBook(BookViewModel data);
}
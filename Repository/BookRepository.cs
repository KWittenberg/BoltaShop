namespace BoltaShop.Repository;

public class BookRepository : EntityBaseRepository<Book>, IBookRepository
{
    private readonly ApplicationDbContext db;
    public BookRepository(ApplicationDbContext db) : base(db)
    {
        this.db = db;
    }

    /// <summary>
    /// AddNewBook
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public async Task AddNewBook(BookViewModel data)
    {
        var newBook = new Book()
        {
            Naziv = data.Naziv,
            OpisKratki = data.OpisKratki,
            Opis = data.Opis,
            Slika = data.Slika,

            Dostupno = data.Dostupno,
            Cijena = data.Cijena,
            Snizenje = data.Snizenje,
            CijenaSnizenje = data.CijenaSnizenje,
            StartDate = data.StartDate,
            EndDate = data.EndDate,

            GodinaIzdanja = data.GodinaIzdanja,
            Nakladnik = data.Nakladnik,
            Isbn = data.Isbn,
            BookCategory = data.BookCategory,
            BookBinding = data.BookBinding,
            BrojStranica = data.BrojStranica,

            Sirina = data.Sirina,
            Visina = data.Visina,
            Debljina = data.Debljina,
            Tezina = data.Tezina
        };
        await this.db.Books.AddAsync(newBook);
        await this.db.SaveChangesAsync();

        //Add Book Authors
        foreach (var authorId in data.AuthorIds)
        {
            var newAuthorBook = new AuthorBook()
            {
                BookId = newBook.Id,
                AuthorId = authorId
            };
            await this.db.AuthorsBooks.AddAsync(newAuthorBook);
        }
        await this.db.SaveChangesAsync();
    }

    /// <summary>
    /// GetBookById
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Book> GetBookById(int id)
    {
        var bookDetails = await this.db.Books.Include(am => am.AuthorsBooks).ThenInclude(a => a.Author).FirstOrDefaultAsync(n => n.Id == id);

        return bookDetails;
    }


    /// <summary>
    /// GetBookDropdownsValues
    /// </summary>
    /// <returns></returns>
    public async Task<BookDropdownsViewModel> GetBookDropdownsValues()
    {
        var response = new BookDropdownsViewModel()
        {
            Authors = await this.db.Authors.OrderBy(n => n.Prezime).ToListAsync()
        };

        return response;
    }


    /// <summary>
    /// UpdateBook
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public async Task UpdateBook(BookViewModel data)
    {
        var dbBook = await this.db.Books.FirstOrDefaultAsync(n => n.Id == data.Id);

        if (dbBook != null)
        {
            dbBook.Naziv = data.Naziv;
            dbBook.OpisKratki = data.OpisKratki;
            dbBook.Opis = data.Opis;
            dbBook.Slika = data.Slika;

            dbBook.Dostupno = data.Dostupno;
            dbBook.Cijena = data.Cijena;
            dbBook.Snizenje = data.Snizenje;
            dbBook.CijenaSnizenje = data.CijenaSnizenje;
            dbBook.StartDate = data.StartDate;
            dbBook.EndDate = data.EndDate;

            dbBook.GodinaIzdanja = data.GodinaIzdanja;
            dbBook.Nakladnik = data.Nakladnik;
            dbBook.Isbn = data.Isbn;
            dbBook.BookCategory = data.BookCategory;
            dbBook.BookBinding = data.BookBinding;
            dbBook.BrojStranica = data.BrojStranica;

            dbBook.Sirina = data.Sirina;
            dbBook.Visina = data.Visina;
            dbBook.Debljina = data.Debljina;
            dbBook.Tezina = data.Tezina;

            await this.db.SaveChangesAsync();
        }

        //Remove existing authors
        var existingAuthorsDb = this.db.AuthorsBooks.Where(n => n.BookId == data.Id).ToList();
        this.db.AuthorsBooks.RemoveRange(existingAuthorsDb);
        await this.db.SaveChangesAsync();

        //Add Book Authors
        foreach (var authorId in data.AuthorIds)
        {
            var newAuthorBook = new AuthorBook()
            {
                BookId = data.Id,
                AuthorId = authorId
            };
            await this.db.AuthorsBooks.AddAsync(newAuthorBook);
        }
        await this.db.SaveChangesAsync();
    }
}
namespace BoltaShop.Controllers;

public class BookController : Controller
{
    private readonly IBookRepository repository;

    public BookController(IBookRepository repository)
    {
        this.repository = repository;
    }


    /// <summary>
    /// Get: Books
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var books = await this.repository.Get();
        return View(books);
    }

    /// <summary>
    /// Get: Filter
    /// </summary>
    /// <param name="searchString"></param>
    /// <returns></returns>
    [AllowAnonymous]
    public async Task<IActionResult> Filter(string searchString)
    {
        var books = await this.repository.Get();

        if (!string.IsNullOrEmpty(searchString))
        {
            var filteredResult = books.Where(n => n.Naziv.ToLower().Contains(searchString.ToLower()) || n.Opis.ToLower().Contains(searchString.ToLower())).ToList();
            //var filteredResult = books.Where(n => string.Equals(n.Naziv, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Opis, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

            return View("Index", filteredResult);
        }

        return View("Index", books);
    }


    /// <summary>
    /// GET: Books/Details/1
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        var bookDetail = await this.repository.GetBookById(id);
        return View(bookDetail);
    }

    /// <summary>
    /// GET: Books/QuickView/1
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [AllowAnonymous]
    public async Task<IActionResult> QuickView(int id)
    {
        var bookDetail = await this.repository.GetBookById(id);
        return View(bookDetail);
    }



    /// <summary>
    /// GET: Books/Create
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Create()
    {
        var bookDropdownsData = await this.repository.GetBookDropdownsValues();

        ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "Prezime");

        return View();
    }
    //POST
    [HttpPost]
    public async Task<IActionResult> Create(BookViewModel book)
    {
        if (!ModelState.IsValid)
        {
            var bookDropdownsData = await this.repository.GetBookDropdownsValues();

            ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "Prezime");

            return View(book);
        }

        await this.repository.AddNewBook(book);
        return RedirectToAction(nameof(Index));
    }


    /// <summary>
    /// GET: Book/Edit/1
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> Edit(int id)
    {
        var bookDetails = await this.repository.GetBookById(id);
        if (bookDetails == null) return View("NotFound");

        var response = new BookViewModel()
        {
            Id = bookDetails.Id,
            Naziv = bookDetails.Naziv,
            OpisKratki = bookDetails.OpisKratki,
            Opis = bookDetails.Opis,
            Slika = bookDetails.Slika,
            Dostupno = bookDetails.Dostupno,
            Cijena = bookDetails.Cijena,
            Snizenje = bookDetails.Snizenje,
            CijenaSnizenje = bookDetails.CijenaSnizenje,
            StartDate = bookDetails.StartDate,
            EndDate = bookDetails.EndDate,
            GodinaIzdanja = bookDetails.GodinaIzdanja,
            Nakladnik = bookDetails.Nakladnik,
            Isbn = bookDetails.Isbn,
            BookCategory = bookDetails.BookCategory,
            BookBinding = bookDetails.BookBinding,
            BrojStranica = bookDetails.BrojStranica,
            Sirina = bookDetails.Sirina,
            Visina = bookDetails.Visina,
            Debljina = bookDetails.Debljina,
            Tezina = bookDetails.Tezina,
            AuthorIds = bookDetails.AuthorsBooks.Select(n => n.AuthorId).ToList()
        };

        var bookDropdownsData = await this.repository.GetBookDropdownsValues();

        ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "Prezime");

        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, BookViewModel book)
    {
        if (id != book.Id) return View("NotFound");

        if (!ModelState.IsValid)
        {
            var bookDropdownsData = await this.repository.GetBookDropdownsValues();

            ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "Prezime");

            return View(book);
        }

        await this.repository.UpdateBook(book);
        return RedirectToAction(nameof(Index));
    }


}
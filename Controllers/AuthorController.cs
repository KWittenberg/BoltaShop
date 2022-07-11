namespace BoltaShop.Controllers;

public class AuthorController : Controller
{
    private readonly IAuthorRepository repository;

    public AuthorController(IAuthorRepository repository)
    {
        this.repository = repository;
    }

    /// <summary>
    /// Get: Authors
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var authors = await this.repository.Get();
        return View(authors);
    }

    /// <summary>
    /// Get: Author/Details
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        var details = await this.repository.GetById(id);

        if (details == null)
        {
            return View("NotFound");
        }
        return View(details);
    }


    /// <summary>
    /// Get: Author/Create
    /// </summary>
    /// <returns></returns>
    public IActionResult Create()
    {
        return View();
    }
    // Post
    [HttpPost]
    public async Task<IActionResult> Create([Bind("Id, Slika, Ime, Prezime, Opis")] Author author)
    {
        if (!ModelState.IsValid) return View(author);
        await repository.Insert(author);
        TempData["success"] = "Author created successfully";
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Get: Author/Edit
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> Edit(int id)
    {
        var details = await repository.GetById(id);
        if (details == null) return View("NotFound");
        return View(details);
    }
    // Post
    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id, Slika, Ime, Prezime, Opis")] Author author)
    {
        if (!ModelState.IsValid) return View(author);
        await repository.Update(id, author);
        TempData["success"] = "Author updated successfully";
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Author/Delete
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> Delete(int id)
    {
        var details = await repository.GetById(id);
        if (details == null) return View("NotFound");
        return View(details);
    }
    // Post
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var details = await repository.GetById(id);
        if (details == null) return View("NotFound");
        await repository.Delete(id);
        TempData["success"] = "Author deleted successfully";
        return RedirectToAction(nameof(Index));
    }
}

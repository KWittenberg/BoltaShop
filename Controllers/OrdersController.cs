namespace BoltaShop.Controllers;

//[Authorize]
public class OrdersController : Controller
{
    private readonly IBookRepository _bookRepository;
    private readonly ShoppingCart _shoppingCart;
    private readonly IOrdersRepository _ordersRepository;

    public OrdersController(IBookRepository bookRepository, ShoppingCart shoppingCart, IOrdersRepository ordersRepository)
    {
        _bookRepository = bookRepository;
        _shoppingCart = shoppingCart;
        _ordersRepository = ordersRepository;
    }


    /// <summary>
    /// Index
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Index()
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        string userRole = User.FindFirstValue(ClaimTypes.Role);
        var orders = await _ordersRepository.GetOrdersByUserIdAndRole(userId, userRole);
        return View(orders);
    }

    /// <summary>
    /// ShoppingCart
    /// </summary>
    /// <returns></returns>
    public IActionResult ShoppingCart()
    {
        var items = _shoppingCart.GetShoppingCartItems();
        _shoppingCart.ShoppingCartItems = items;

        var response = new ShoppingCartViewModel()
        {
            ShoppingCart = _shoppingCart,
            ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
        };

        return View(response);
    }

    /// <summary>
    /// AddItemToShoppingCart
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> AddItemToShoppingCart(int id)
    {
        var item = await _bookRepository.GetBookById(id);

        if (item != null)
        {
            _shoppingCart.AddItemToCart(item);
        }
        return RedirectToAction(nameof(ShoppingCart));
    }

    /// <summary>
    /// RemoveItemFromShoppingCart
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
    {
        var item = await _bookRepository.GetBookById(id);

        if (item != null)
        {
            _shoppingCart.RemoveItemFromCart(item);
        }
        return RedirectToAction(nameof(ShoppingCart));
    }

    /// <summary>
    /// CompleteOrder
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> CompleteOrder()
    {
        var items = _shoppingCart.GetShoppingCartItems();
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

        await _ordersRepository.StoreOrder(items, userId, userEmailAddress);
        await _shoppingCart.ClearShoppingCartAsync();

        return View("OrderCompleted");
    }
}
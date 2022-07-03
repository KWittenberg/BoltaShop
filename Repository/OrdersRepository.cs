using BoltaShop.Data;
using BoltaShop.Models.Dbo;
using BoltaShop.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BoltaShop.Repository
{
    public class OrdersRepository: IOrdersRepository
    {
        private readonly ApplicationDbContext _db;
        
        public OrdersRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Order>> GetOrdersByUserIdAndRole(string userId, string userRole)
        {
            var orders = await _db.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Book).Include(n => n.User).ToListAsync();

            if (userRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }

            return orders;
        }

        public async Task StoreOrder(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    BookId = item.Book.Id,
                    OrderId = order.Id,
                    Cijena = item.Book.Cijena
                };
                await _db.OrderItems.AddAsync(orderItem);
            }
            await _db.SaveChangesAsync();
        }
    }
}

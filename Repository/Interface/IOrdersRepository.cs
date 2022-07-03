using BoltaShop.Models.Dbo;

namespace BoltaShop.Repository.Interface
{
    public interface IOrdersRepository
    {
        Task StoreOrder(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAndRole(string userId, string userRole);
    }
}

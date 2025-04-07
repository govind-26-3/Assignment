
using ECommerceApplication.Domain;

namespace ECommerceApplication.Application.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItem>> GetOrderItemsAsync(int orderId, string userId);
        //Task<OrderItem> GetOrderItemByIdAsync(int orderId);
        Task<OrderItem> GetOrderItemByIdAsync(int orderItemId);
        Task<OrderItem> AddOrderItemAsync(OrderItem orderItem);
        Task<OrderItem> UpdateOrderItemAsync(int orderItemId, OrderItem orderItem);
        Task<bool> DeleteOrderItemAsync(int orderItemId);
    }
}

using ECommerceApplication.Application.Interfaces;
using ECommerceApplication.Domain;
using ECommerceApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Infrastructure.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        readonly EcommerceDbContext _context;

        public OrderItemRepository(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemsAsync(int orderId,string userId)
        {
            return await _context.OrderItems
                .Include(oi => oi.Product) 
                .Where(oi => oi.OrderId == orderId && oi.Order.UserId == userId)
                .ToListAsync();
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int orderItemId)
        {
            return await _context.OrderItems
                .Include(oi => oi.Product)
                .FirstOrDefaultAsync(oi => oi.OrderItemId == orderItemId);
        }
        //public async Task<OrderItem> GetOrderItemByIdAsync(int orderId)
        //{
        //    return await _context.OrderItems
        //        .Include(oi => oi.Product)
        //        .FirstOrDefaultAsync(oi => oi.OrderId == orderId);
        //}

        public async Task<OrderItem> AddOrderItemAsync(OrderItem orderItem)
        {
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
            return orderItem;
        }

        public async Task<OrderItem> UpdateOrderItemAsync(int orderItemId, OrderItem orderItem)
        {
            var existingOrderItem = await GetOrderItemByIdAsync(orderItemId);
            if (existingOrderItem == null)
            {
                throw new ArgumentException("Order item not found");
            }

            existingOrderItem.Quantity = orderItem.Quantity; 
            _context.OrderItems.Update(existingOrderItem);
            await _context.SaveChangesAsync();
            return existingOrderItem;
        }

        public async Task<bool> DeleteOrderItemAsync(int orderItemId)
        {
            var orderItem = await GetOrderItemByIdAsync(orderItemId);
            if (orderItem == null)
            {
                return false; 
            }

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
            return true; 
        }
    }
}


using ECommerceApplication.Application.Interfaces;
using ECommerceApplication.Domain;
using ECommerceApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Infrastructure.Repository
{


    public class OrderRepository : IOrderRepository
    {
        readonly EcommerceDbContext _context;

        public OrderRepository(EcommerceDbContext context)
        {
            _context = context;
        }


        public async Task<Orders> AddOrderAsync(Orders order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }


        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return false;
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<Orders> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }


        public async Task<IEnumerable<Orders>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }


        public async Task<Orders> UpdateOrderAsync(int id, Orders order)
        {          
            var existingOrder = await GetOrderByIdAsync(id);

            if (existingOrder is null)
            {
                throw new ArgumentException("Order not found");
            }

            existingOrder.OrderDate = order.OrderDate;
            existingOrder.Status = order.Status;
            existingOrder.TotalAmount = order.TotalAmount;

            _context.Orders.Update(existingOrder);

            await _context.SaveChangesAsync();

            return existingOrder;
        }
    }
}

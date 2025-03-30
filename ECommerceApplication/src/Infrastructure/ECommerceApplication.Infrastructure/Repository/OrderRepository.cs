
using ECommerceApplication.Application.Interfaces;
using ECommerceApplication.Domain;
using ECommerceApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Infrastructure.Repository
{


    public class OrderRepository : IOrderRepository
    {
        readonly EcommerceDbContext _context;
        readonly IOrderItemRepository _orderItemRepository;

        public OrderRepository(EcommerceDbContext context, IOrderItemRepository orderItemRepository)
        {
            _context = context;
            _orderItemRepository = orderItemRepository;
        }


        public async Task<Orders> AddOrderAsync(Orders order, int productId)
        {
            int quantity = 1;
            if (quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be less than 0.");
            }


            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new ArgumentException("Product not found.");
            }


            if (quantity > product.Stock)
            {
                throw new InvalidOperationException("Insufficient stock available for the requested product.");
            }

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            var orderItem = new OrderItem
            {
                OrderId = order.OrderId,
                ProductId = productId,
                Quantity = quantity
            };
            await _orderItemRepository.AddOrderItemAsync(orderItem);

            product.Stock -= quantity;

            _context.Products.Update(product);
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
            return await _context.Orders.Include(u => u.User).ToListAsync();
        }


        public async Task<Orders> UpdateOrderAsync(int id, Orders order)
        {
            var existingOrder = await GetOrderByIdAsync(id);

            if (existingOrder is null)
            {
                throw new ArgumentException("Order not found");
            }

            //existingOrder.OrderDate = order.OrderDate;
            existingOrder.Status = order.Status;
            existingOrder.TotalAmount = order.TotalAmount;

            _context.Orders.Update(existingOrder);

            await _context.SaveChangesAsync();

            return existingOrder;
        }
    }
}

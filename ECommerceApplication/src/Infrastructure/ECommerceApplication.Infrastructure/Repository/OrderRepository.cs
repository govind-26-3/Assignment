
using ECommerceApplication.Application.Exceptions;
using ECommerceApplication.Application.Interfaces;
using ECommerceApplication.Domain;
using ECommerceApplication.Domain.Constants;
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



        public async Task<Orders> CreateOrderByCartAsync(int cartItemId)
        {


            var cartItem = await _context.CartItems.FirstOrDefaultAsync(x => x.CartItemId == cartItemId);


            var resultOrder = await AddOrderAsync(cartItem.UserId, cartItem.Quantity, cartItem.ProductId);
            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
            return resultOrder;

        }
        public async Task<Orders> AddOrderAsync(string userid, int quantity, int productId)
        {



            if (quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be less than 0.");
            }
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new NotFoundException("Product not found.");
            }
            var orders = new Orders
            {
                UserId = userid,
                TotalAmount = quantity * (decimal)product.Price,
                OrderDate = DateTime.Now,
                Status = OrderStatus.Pending

            };

            if (quantity > product.Stock)
            {
                throw new InvalidOperationException("Insufficient stock available for the requested product.");
            }

            await _context.Orders.AddAsync(orders);
            //await _context.SaveChangesAsync();

            var lastOrder = await _context.Orders
            .OrderByDescending(o => o.OrderId)
            .FirstOrDefaultAsync();


            var orderItem = new OrderItem
            {
                OrderId = lastOrder.OrderId,
                ProductId = productId,
                Quantity = quantity,

            };

            await _orderItemRepository.AddOrderItemAsync(orderItem);

            product.Stock -= quantity;

            _context.Products.Update(product);



            await _context.SaveChangesAsync();

            return orders;
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


            existingOrder.Status = order.Status;
            existingOrder.TotalAmount = order.TotalAmount;

            _context.Orders.Update(existingOrder);

            await _context.SaveChangesAsync();

            return existingOrder;
        }

        public async Task<IEnumerable<Orders>> GetOrdersByUserIdAsync(string id)
        {
            var deliveredOrders = await _context.Orders
            .Where(o => o.UserId == id && o.Status == OrderStatus.Pending)
            .ToListAsync();

            if (deliveredOrders == null || !deliveredOrders.Any())
            {
                throw new NotFoundException("No delivered orders found for this user.");
            }

            return deliveredOrders;
        }
    }
}

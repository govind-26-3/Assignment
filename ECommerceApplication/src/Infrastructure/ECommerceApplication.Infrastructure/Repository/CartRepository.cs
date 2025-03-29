
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApplication.Application.Interfaces;
using ECommerceApplication.Domain;
using ECommerceApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Infrastructure.Repository
{

    public class CartRepository : ICartRepository
    {
        readonly EcommerceDbContext _context;

        public CartRepository(EcommerceDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<CartItem>> GetCartItemsAsync(int userId)
        {
            return await _context.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }


        public async Task<CartItem> GetCartItemByIdAsync(int cartItemId)
        {
            return await _context.CartItems
                .Include(c => c.Product)
                .FirstOrDefaultAsync(c => c.CartItemId == cartItemId);
        }


        public async Task<CartItem> AddCartItemAsync(CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();
            return cartItem;
        }


        public async Task<CartItem> UpdateCartItemAsync(int cartItemId, CartItem cartItem)
        {
            var existingCartItem = await GetCartItemByIdAsync(cartItemId);
            if (existingCartItem == null)
            {
                throw new ArgumentException("Cart item not found");
            }

            existingCartItem.Quantity = cartItem.Quantity;
            _context.CartItems.Update(existingCartItem);
            await _context.SaveChangesAsync();
            return existingCartItem;
        }


        public async Task<bool> DeleteCartItemAsync(int cartItemId)
        {
            var cartItem = await GetCartItemByIdAsync(cartItemId);
            if (cartItem == null)
            {
                return false;
            }

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

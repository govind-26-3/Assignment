
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApplication.Application.Interfaces;
using ECommerceApplication.Domain;
using ECommerceApplication.Identity.Model;
using ECommerceApplication.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Infrastructure.Repository
{

    public class CartRepository : ICartRepository
    {
        readonly EcommerceDbContext _context;
        //readonly UserManager<ApplicationUser> _userManager;
        readonly IProductRepository _productRepository;

        public CartRepository(EcommerceDbContext context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }


        public async Task<IEnumerable<CartItem>> GetCartItemsAsync(string userId)
        {
            return await _context.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId.Equals(userId))
                .ToListAsync();
        }


        public async Task<CartItem> GetCartItemByIdAsync(int cartItemId)
        {

            return await _context.CartItems
                .Include(c => c.Product)
                .FirstOrDefaultAsync(c => c.CartItemId == cartItemId);
        }


        public async Task<CartItem> AddCartItemAsync(string userId, int quantity, int productId)
        {
            var existingCartItem = _context.CartItems.FirstOrDefault(x => x.ProductId == productId && x.UserId == userId);

            if (existingCartItem == null)
            {
                var newcartItem = new CartItem
                {
                    ProductId = productId,
                    UserId = userId,
                    Quantity = quantity
                };
                await _context.CartItems.AddAsync(newcartItem);
                await _context.SaveChangesAsync();
                return newcartItem;
            }
            existingCartItem.Quantity += quantity;

             _context.CartItems.Update(existingCartItem);
            await _context.SaveChangesAsync();
            return existingCartItem;

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

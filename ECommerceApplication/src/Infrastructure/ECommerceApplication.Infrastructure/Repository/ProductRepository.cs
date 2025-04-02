using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Application.Exceptions;
using ECommerceApplication.Application.Interfaces;
using ECommerceApplication.Domain;
using ECommerceApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected readonly EcommerceDbContext _eCommerceDbContext;
        public ProductRepository(EcommerceDbContext eCommerceDbContext)
        {
            _eCommerceDbContext = eCommerceDbContext;
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            await _eCommerceDbContext.Products.AddAsync(product);
            await _eCommerceDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await GetProductByIdAsync(id);
            if (product is not null)
            {
                _eCommerceDbContext.Products.Remove(product);
                return await _eCommerceDbContext.SaveChangesAsync() > 0;

            }
            return false;

        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _eCommerceDbContext.Products.FirstOrDefaultAsync(b => b.ProductId == id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _eCommerceDbContext.Products.Include(c => c.Category).ToListAsync();
        }




        public async Task<Product> UpdateProductAsync(int productId, Product product)
        {

            var existingProduct = await GetProductByIdAsync(productId);


            if (existingProduct == null)
            {
                throw new NotFoundException($"Product with id: {productId} Not Found.");
            }

            existingProduct.PName = product.PName;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;

            await _eCommerceDbContext.SaveChangesAsync();
            return existingProduct;
        }
    }
}

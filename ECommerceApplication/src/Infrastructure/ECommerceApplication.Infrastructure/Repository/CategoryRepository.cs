using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApplication.Application.Interfaces;
using ECommerceApplication.Domain;
using ECommerceApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Infrastructure.Repository
{
    internal class CategoryRepository : ICategoryRepository
    {
        readonly EcommerceDbContext _eCommerceDbContext;

        public CategoryRepository(EcommerceDbContext eCommerceDbContext)
        {
            _eCommerceDbContext = eCommerceDbContext;
        }


        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _eCommerceDbContext.Categories.ToListAsync();
        }


        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _eCommerceDbContext.Categories.FindAsync(id);
        }


        public async Task<Category> AddCategoryAsync(Category category)
        {
            await _eCommerceDbContext.Categories.AddAsync(category);
            await _eCommerceDbContext.SaveChangesAsync();
            return category;
        }


        public async Task<Category> UpdateCategoryAsync(int categoryId, Category category)
        {
            if (categoryId != category.CId)
            {
                throw new ArgumentException("Category ID mismatch");
            }

            _eCommerceDbContext.Entry(category).State = EntityState.Modified;
            await _eCommerceDbContext.SaveChangesAsync();
            return category;
        }


        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _eCommerceDbContext.Categories.FindAsync(id);
            if (category == null)
            {
                return false;
            }
            _eCommerceDbContext.Categories.Remove(category);
            await _eCommerceDbContext.SaveChangesAsync();
            return true;
        }
    }
}
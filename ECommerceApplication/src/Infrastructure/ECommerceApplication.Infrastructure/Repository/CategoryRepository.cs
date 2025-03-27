using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Application.Interfaces;
using ECommerceApplication.Domain;

namespace ECommerceApplication.Infrastructure.Repository
{
    internal class CategoryRepository : ICategoryRepository
    {
        public Task<Category> AddCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateCategoryAsync(int CategoryId, Category category)
        {
            throw new NotImplementedException();
        }
    }
}

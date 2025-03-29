using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Domain;

namespace ECommerceApplication.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryByIdAsync(int id);  
        Task<Category> AddCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(int CategoryId, Category category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}

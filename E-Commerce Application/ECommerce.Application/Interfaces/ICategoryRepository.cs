using ECommerce.Domain;

namespace ECommerce.Infrastructure.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        //Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> AddCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(int CategoryId, Category category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
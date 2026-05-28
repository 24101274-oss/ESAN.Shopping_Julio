using System.Collections.Generic;
using System.Threading.Tasks;
using UESAN.SHOPPING.CORE.core.Entities;

namespace UESAN.SHOPPING.CORE.infrastructure.Repositories
{
    public interface ICategoryRepository
    {
        Task CreateCategory(Category category);
        Task DeleteCategory(int id);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryById(int id);
        Task UpdateCategory(Category category);
    }
}
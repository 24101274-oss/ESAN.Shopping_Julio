using UESAN.SHOPPING.CORE.core.DTOs;

namespace UESAN.SHOPPING.CORE.core.Interfaces
{
    public interface ICategoryService
    {
        Task CreateCategory(CategoryCreateDTO categoryCreateDTO);
        Task DeleteCategory(int id);
        Task<IEnumerable<CategoryListDTO>> GetCategories();
        Task<CategoryDTO> GetCategoryById(int id);
        Task UpdateCategory(CategoryUpdateDTO categoryUpdateDTO);
    }
}
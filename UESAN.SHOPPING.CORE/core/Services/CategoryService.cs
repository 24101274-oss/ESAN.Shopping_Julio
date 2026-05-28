using System;
using System.Collections.Generic;
using System.Text;
using UESAN.SHOPPING.CORE.core.DTOs;
using UESAN.SHOPPING.CORE.core.Entities;
using UESAN.SHOPPING.CORE.core.Interfaces;
using UESAN.SHOPPING.CORE.infrastructure.Repositories;

namespace UESAN.SHOPPING.CORE.core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryListDTO>> GetCategories()
        {
            var Categories = await _categoryRepository.GetCategoriesAsync();
            var CategoriesDTOs = new List<CategoryListDTO>();

            foreach (var category in Categories)
            {
                var categoryDTO = new CategoryListDTO
                {
                    Id = category.Id,
                    Description = category.Description
                };
                CategoriesDTOs.Add(categoryDTO);
            }
            return CategoriesDTOs;
        }
        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category == null) return null;
            var categoryDTO = new CategoryDTO
            {
                Id = category.Id,
                Description = category.Description,
            };
            return categoryDTO;
        }

        public async Task CreateCategory(CategoryCreateDTO categoryCreateDTO)
        {
            var category = new Category
            {
                Description = categoryCreateDTO.Description,
                IsActive = true
            };
            await _categoryRepository.CreateCategory(category);
        }

        public async Task UpdateCategory(CategoryUpdateDTO categoryUpdateDTO)
        {
            var existingCategory = await _categoryRepository.GetCategoryById(categoryUpdateDTO.Id);
            if (existingCategory == null) return; // o lanzar excepción según la lógica de tu app

            existingCategory.Description = categoryUpdateDTO.Description;
            await _categoryRepository.UpdateCategory(existingCategory);
        }
        public async Task DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategory(id);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UESAN.SHOPPING.CORE.core.Entities;

namespace UESAN.SHOPPING.CORE.infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly logisticaBDContext _context;

        public CategoryRepository(logisticaBDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        // InsertCategory: Inserta una nueva categoría en la base de datos.
        public async Task CreateCategory(Category category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));

            if (category.IsActive == null)
                category.IsActive = true;

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        // UpdateCategory: Actualiza una categoría existente.
        public async Task UpdateCategory(Category category)
        {
            var existingCategory = await _context.Categories.Where(c => c.Id == category.Id).FirstOrDefaultAsync();
            if (existingCategory != null)
            {
                existingCategory.Description = category.Description;
                // existingCategory.IsActive = category.IsActive; // activar si quieres permitir actualizar IsActive
                await _context.SaveChangesAsync();
            }
        }

        // DeleteCategory: Marca una categoría como inactiva.
        public async Task DeleteCategory(int id)
        {
            var existingcategory = await _context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (existingcategory != null)
            {
                existingcategory.IsActive = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}

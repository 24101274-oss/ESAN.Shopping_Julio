using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UESAN.SHOPPING.CORE.core.Entities;

namespace UESAN.SHOPPING.CORE.infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly logisticaBDContext _context;

        public ProductRepository(logisticaBDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task InsertProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            if (product.IsActive == null)
                product.IsActive = true;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            var existing = await _context.Products.Where(p => p.Id == product.Id).FirstOrDefaultAsync();
            if (existing != null)
            {
                existing.Description = product.Description;
                existing.ImageUrl = product.ImageUrl;
                existing.Stock = product.Stock;
                existing.Price = product.Price;
                existing.Discount = product.Discount;
                existing.CategoryId = product.CategoryId;
                // existing.IsActive = product.IsActive; // descomentar si quieres permitir actualizar IsActive
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProduct(int id)
        {
            var existing = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (existing != null)
            {
                existing.IsActive = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}
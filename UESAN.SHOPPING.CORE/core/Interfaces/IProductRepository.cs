using System.Collections.Generic;
using System.Threading.Tasks;
using UESAN.SHOPPING.CORE.core.Entities;

namespace UESAN.SHOPPING.CORE.infrastructure.Repositories
{
    public interface IProductRepository
    {
        Task InsertProduct(Product product);
        Task DeleteProduct(int id);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductById(int id);
        Task UpdateProduct(Product product);
    }
}
using Microsoft.AspNetCore.Mvc;
using UESAN.SHOPPING.CORE.infrastructure.Repositories;
using UESAN.SHOPPING.CORE.core.Entities;

namespace ESAN.Shopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null) return BadRequest();

            await _productRepository.InsertProduct(product);

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (product == null) return BadRequest();
            if (id != product.Id) return BadRequest("El id de la ruta no coincide con el id del body.");

            var existing = await _productRepository.GetProductById(id);
            if (existing == null) return NotFound();

            await _productRepository.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existing = await _productRepository.GetProductById(id);
            if (existing == null) return NotFound();

            await _productRepository.DeleteProduct(id);
            return NoContent();
        }
    }
}
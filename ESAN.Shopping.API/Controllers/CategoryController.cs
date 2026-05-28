using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.SHOPPING.CORE.core.DTOs;
using UESAN.SHOPPING.CORE.core.Interfaces;

namespace ESAN.Shopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDTO categoryCreateDTO)
        {
            if (categoryCreateDTO == null) return BadRequest();

            await _categoryService.CreateCategory(categoryCreateDTO);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id,[FromBody] CategoryUpdateDTO categoryUpdateDTO)
        {
            if (categoryUpdateDTO == null) return BadRequest();
            if (id != categoryUpdateDTO.Id) return BadRequest("El id de la ruta no coincide con el id del body.");

            var existing = await _categoryService.GetCategoryById(id);
            if (existing == null) return NotFound();

            await _categoryService.UpdateCategory(categoryUpdateDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id, [FromBody] CategoryDeleteDTO categoryUpdateDTO)
        {
            var existing = await _categoryService.GetCategoryById(id);
            if (existing == null) return NotFound();

            await _categoryService.DeleteCategory(id);
            return NoContent();
        }
    }
}

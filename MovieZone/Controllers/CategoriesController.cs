using Microsoft.AspNetCore.Mvc;
using MovieZone.API.Dtos.CategoriesDtos;
using MovieZone.API.Exeptions;
using MovieZone.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Controllers
{
    [Route("api/categories")]
    public class CategoriesController : AppBaseController
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = await _categoriesService.GetCategories();

            return categories;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CreateOrUpdateCategoryDto categoryDto)
        {
            var category = await _categoriesService.AddCategory(categoryDto);

            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoriesService.DeleteCategory(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CreateOrUpdateCategoryDto categoryDto)
        {
            await _categoriesService.UpdateCategory(id, categoryDto);
            return Ok(categoryDto);
        }

        [HttpGet("{id}")]
        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var category = await _categoriesService.GetCategoryById(id);
            return category;
        }
    }
}

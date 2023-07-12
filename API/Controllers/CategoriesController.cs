using Business.Abstract;
using Entities.DTOs;
using Entities.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAllAsnyc")]
        public async Task<IActionResult> GetAllAsnyc()
        {
            var result = await _categoryService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpGet("GetCategoryByIdAsync/{categoryId}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int categoryId)
        {
            var result = await _categoryService.GetCategoryByIdAsync(categoryId);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }

        [HttpPost("AddCategoryAsync")]
        public async Task<IActionResult> AddCategoryAsync(CreateCategoryDto model)
        {
            var result = await _categoryService.AddCategoryAsync(model);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpPut("UpdateCategoryAsync")]
        public async Task<IActionResult> UpdateCategoryAsync(UpdateCategoryDto model)
        {
            var result = await _categoryService.UpdateCategoryAsync(model);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteCategoryAsync/{categoryId}")]
        public async Task<IActionResult> DeleteCategoryAsync(int categoryId)
        {
            var result = await _categoryService.DeleteCategoryAsync(categoryId);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
    }
}

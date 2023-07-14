using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("GetAllAsnyc")]
        public async Task<IActionResult> GetAllAsnyc()
        {
            var result = await _postService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpGet("GetCategoryByIdAsync/{postId}")]
        public async Task<IActionResult> GetPostByIdAsync(int postId)
        {
            var result = await _postService.GetPostByIdAsync(postId);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
    }
}

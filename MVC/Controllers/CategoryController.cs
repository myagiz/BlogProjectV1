using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var getAllCategoriesAsync = await _categoryService.GetAllAsync();
            ViewBag.ListCategory = getAllCategoriesAsync.Data;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory(int id)
        {
            var result = await _categoryService.GetCategoryByIdAsync(id);
            if (result.Success)
            {
                return Json(new AllModel
                {
                    Category = result.Data
                });
            }
            TempData["Error"] = result.Message;
            return RedirectToAction("Index");
        }

    }
}

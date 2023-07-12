using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;

        private readonly ICategoryService _categoryService;

        public HomeController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {

            var getCategoryList =await _categoryService.GetAllAsync();
            List<SelectListItem> getDropdownList = (from a in getCategoryList.Data
                                                    select new SelectListItem
                                                    {
                                                        Text = a.Name,
                                                        Value = a.Id.ToString()
                                                    }
                                                 ).ToList();
            ViewBag.Categories = getDropdownList;

            var getAllPostAsync = await _postService.GetAllAsync();
            var getAllCategoriesAsync = await _categoryService.GetAllAsync();
            ViewBag.ListPost = getAllPostAsync.Data;
            ViewBag.ListCategory = getAllCategoriesAsync.Data;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetPost(int id)
        {
            var result = await _postService.GetPostByIdAsync(id);
            if (result.Success)
            {
                return Json(new AllModel
                {
                    Post = result.Data
                });
            }
            TempData["Error"] = result.Message;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddMethod(AllModel model)
        {
            if (model.ContentType == "Blog")
            {
                var entity = new CreatePostDto
                {
                    Name = model.CreatePost.Name,
                    CategoryId = model.CreatePost.CategoryId,
                    Description = model.CreatePost.Description,
                };

                var result = await _postService.AddPostAsync(entity);
                if (result.Success)
                {
                    return Redirect("/Home/Index");
                }
                TempData["Error"] = result.Message;
                return RedirectToAction("Index");

            }
            else if (model.ContentType == "Category")
            {
                var entity = new CreateCategoryDto
                {
                    Name = model.CreateCategory.Name
                };

                var result = await _categoryService.AddCategoryAsync(entity);
                if (result.Success)
                {
                    return Redirect("/Category/Index");
                }
                TempData["Error"] = result.Message;
                return Redirect("/Category/Index");
            }
            TempData["Error"] = Messages.GeneralError;
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> UpdateMethod(AllModel model)
        {
            if (model.ContentType == "Blog")
            {
                var entity = new UpdatePostDto
                {
                    Id = model.UpdatePost.Id,
                    Name = model.UpdatePost.Name,
                    CategoryId = model.UpdatePost.CategoryId,
                    Description = model.UpdatePost.Description,
                };

                var result = await _postService.UpdatePostAsync(entity);
                if (result.Success)
                {
                    return Redirect("/Home/Index");
                }
                TempData["Error"] = result.Message;
                return Redirect("/Home/Index");

            }
            else if (model.ContentType == "Category")
            {
                var entity = new UpdateCategoryDto
                {
                    Id = model.UpdateCategory.Id,
                    Name = model.UpdateCategory.Name
                };

                var result = await _categoryService.UpdateCategoryAsync(entity);
                if (result.Success)
                {
                    return Redirect("/Category/Index");
                }
                TempData["Error"] = result.Message;
                return Redirect("/Category/Index");
            }
            TempData["Error"] = Messages.GeneralError;
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> DeleteMethod(int? postId, int? categoryId)
        {
            if (postId != null)
            {
                var checkData = await _postService.GetPostByIdAsync((int)postId);
                if (checkData.Success)
                {
                    var result = await _postService.DeletePostAsync((int)postId);
                    if (result.Success)
                    {
                        return Redirect("/Home/Index");
                    }
                    TempData["Error"] = result.Message;
                    return Redirect("/Home/Index");
                }

                TempData["Error"] = checkData.Message;
                return RedirectToAction("Index");
            }
            else if (categoryId != null)
            {
                var checkData = await _categoryService.GetCategoryByIdAsync((int)categoryId);
                if (checkData.Success)
                {
                    var result = await _categoryService.DeleteCategoryAsync((int)categoryId);
                    if (result.Success)
                    {
                        return Redirect("/Category/Index");
                    }
                    TempData["Error"] = result.Message;
                    return Redirect("/Category/Index");
                }

                TempData["Error"] = checkData.Message;
                return RedirectToAction("Index");
            }
            TempData["Error"] = Messages.GeneralError;
            return RedirectToAction("Index");

        }

    }
}

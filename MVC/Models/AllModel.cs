using Entities.DTOs;
using Entities.Entity;
using System.Collections.Generic;

namespace MVC.Models
{
    public class AllModel
    {
        public CreateCategoryDto CreateCategory { get; set; }
        public CreatePostDto CreatePost { get; set; }
        public UpdateCategoryDto UpdateCategory { get; set; }
        public UpdatePostDto UpdatePost { get; set; }
        public List<Category> ListCategories { get; set; }
        public List<GetPostDto> ListPosts { get; set; }
        public Category Category { get; set; }
        public GetPostDto Post { get; set; }
        public string ContentType { get; set; }


    }
}

using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPostDal
    {
        Task<List<GetPostDto>> GetAllAsync();
        Task<GetPostDto> GetPostByIdAsync(int postId);
        Task AddPostAsync(CreatePostDto model);
        Task UpdatePostAsync(UpdatePostDto model);
        Task DeletePostAsync(int id);
    }
}

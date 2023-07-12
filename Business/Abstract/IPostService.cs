using Core.Utilities.Results.Abstract;
using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPostService
    {
        Task<IDataResult<List<GetPostDto>>> GetAllAsync();
        Task<IDataResult<GetPostDto>> GetPostByIdAsync(int postId);
        Task<IResult> AddPostAsync(CreatePostDto model);
        Task<IResult> UpdatePostAsync(UpdatePostDto model);
        Task<IResult> DeletePostAsync(int id);
    }
}

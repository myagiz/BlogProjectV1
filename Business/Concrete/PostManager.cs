using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.ErrorResults;
using Core.Utilities.Results.Concrete.SuccessResults;
using DataAccess.Abstract;
using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PostManager : IPostService
    {
        private readonly IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public async Task<IResult> AddPostAsync(CreatePostDto model)
        {
            await _postDal.AddPostAsync(model);
            return new SuccessResult(Messages.AddMethodSuccessfully);
        }

        public async Task<IResult> DeletePostAsync(int id)
        {
            await _postDal.DeletePostAsync(id);
            return new SuccessResult(Messages.DeleteMethodSuccessfully);
        }

        public async Task<IDataResult<List<GetPostDto>>> GetAllAsync()
        {

            var result = await _postDal.GetAllAsync();
            return new SuccessDataResult<List<GetPostDto>>(result);
        }

        public async Task<IDataResult<GetPostDto>> GetPostByIdAsync(int postId)
        {
            var result = await _postDal.GetPostByIdAsync(postId);
            if (result == null)
            {
                return new ErrorDataResult<GetPostDto>(Messages.NotFoundId);
            }
            return new SuccessDataResult<GetPostDto>(result);
        }

        public async Task<IResult> UpdatePostAsync(UpdatePostDto model)
        {
            await _postDal.UpdatePostAsync(model);
            return new SuccessResult(Messages.UpdateMethodSuccessfully);
        }
    }
}

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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<IResult> AddCategoryAsync(CreateCategoryDto model)
        {
            await _categoryDal.AddCategoryAsync(model);
            return new SuccessResult(Messages.AddMethodSuccessfully);
        }

        public async Task<IResult> DeleteCategoryAsync(int id)
        {
            await _categoryDal.DeleteCategoryAsync(id);
            return new SuccessResult(Messages.DeleteMethodSuccessfully);

        }

        public async Task<IDataResult<List<Category>>> GetAllAsync()
        {
            var result = await _categoryDal.GetAllAsync();
            return new SuccessDataResult<List<Category>>(result);
        }

        public async Task<IDataResult<Category>> GetCategoryByIdAsync(int categoryId)
        {
            var result = await _categoryDal.GetCategoryByIdAsync(categoryId);
            if (result == null)
            {
                return new ErrorDataResult<Category>(Messages.NotFoundId);
            }
            return new SuccessDataResult<Category>(result);
        }

        public async Task<IResult> UpdateCategoryAsync(UpdateCategoryDto model)
        {
            await _categoryDal.UpdateCategoryAsync(model);
            return new SuccessResult(Messages.UpdateMethodSuccessfully);

        }
    }
}

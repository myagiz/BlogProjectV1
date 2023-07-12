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
    public interface ICategoryService
    {
        Task<IDataResult<List<Category>>> GetAllAsync();
        Task<IDataResult<Category>> GetCategoryByIdAsync(int categoryId);
        Task<IResult> AddCategoryAsync(CreateCategoryDto model);
        Task<IResult> UpdateCategoryAsync(UpdateCategoryDto model);
        Task<IResult> DeleteCategoryAsync(int id);
    }
}

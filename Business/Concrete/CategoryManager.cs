using Business.Abstract;
using DataAccess.Abstract;
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

        public async Task<List<Category>> GetAllAsync()
        {
            var result = await _categoryDal.GetAllAsync();
            return result;
        }

        public Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            var result = _categoryDal.GetCategoryByIdAsync(categoryId);
            if (result == null)
            {
                return null;
            }
            return result;
        }
    }
}

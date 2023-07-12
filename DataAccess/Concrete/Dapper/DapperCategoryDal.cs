using Dapper;
using DataAccess.Abstract;
using DataAccess.Contexts;
using DataAccess.Queries;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dapper
{
    public class DapperCategoryDal : ICategoryDal
    {
        private readonly BlogProjectDapperContext _context;

        public DapperCategoryDal(BlogProjectDapperContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var categories = await connection.QueryAsync<Category>(DapperQueries.GetAllCategoriesQuery);
                return categories.ToList();
            }
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            using (var connection = _context.CreateConnection())
            {
                var category = await connection.QueryAsync<Category>(DapperQueries.GetCategoryByIdQuery, new { id = categoryId });
                if (category != null)
                {
                    return category.FirstOrDefault();
                }

                return null;
            }
        }
    }
}

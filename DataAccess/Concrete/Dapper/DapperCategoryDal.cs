﻿using Dapper;
using DataAccess.Abstract;
using DataAccess.Contexts;
using DataAccess.Queries;
using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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

        public async Task AddCategoryAsync(CreateCategoryDto model)
        {

            var parameters = new DynamicParameters();
            parameters.Add("Name", model.Name, DbType.String);
            parameters.Add("CreateDate", DateTime.Now, DbType.DateTime);
            parameters.Add("IsActive", true, DbType.Boolean);
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(DapperQueries.AddCategoryQuery, parameters);
                var created = new Category
                {
                    Id = id,
                    Name = model.Name,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("IsActive", false, DbType.Boolean);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(DapperQueries.DeleteCategoryQuery, parameters);
            }
        }

        public async Task<List<Category>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var categories = await connection.QueryAsync<Category>(DapperQueries.GetAllCategoriesQuery, new { IsActive = true });
                return categories.ToList();
            }
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            using (var connection = _context.CreateConnection())
            {
                var category = await connection.QueryAsync<Category>(DapperQueries.GetCategoryByIdQuery, new { Id = categoryId, IsActive = true });
                if (category != null)
                {
                    return category.FirstOrDefault();
                }

                return null;
            }
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", model.Id, DbType.Int32);
            parameters.Add("Name", model.Name, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(DapperQueries.UpdateCategoryQuery, parameters);
            }
        }
    }
}

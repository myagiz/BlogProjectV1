using Dapper;
using DataAccess.Abstract;
using DataAccess.Contexts;
using DataAccess.Queries;
using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dapper
{
    public class DapperPostDal : IPostDal
    {
        private readonly BlogProjectDapperContext _context;

        public DapperPostDal(BlogProjectDapperContext context)
        {
            _context = context;
        }
        public async Task AddPostAsync(CreatePostDto model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Name", model.Name, DbType.String);
            parameters.Add("CategoryId", model.CategoryId, DbType.Int32);
            parameters.Add("Description", model.Description, DbType.String);
            parameters.Add("CreateDate", DateTime.Now, DbType.DateTime);
            parameters.Add("IsActive", true, DbType.Boolean);
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(DapperQueries.AddPostQuery, parameters);
                var created = new Category
                {
                    Id = id,
                    Name = model.Name,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
            }
        }

        public async Task DeletePostAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("IsActive", false, DbType.Boolean);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(DapperQueries.DeletePostQuery, parameters);
            }
        }

        public async Task<List<GetPostDto>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<GetPostDto>(DapperQueries.GetAllPostsQuery, new { IsActive = true });
                return data.ToList();
            }
        }

        public async Task<GetPostDto> GetPostByIdAsync(int postId)
        {
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<GetPostDto>(DapperQueries.GetPostByIdQuery, new { Id = postId, IsActive = true });
                if (data != null)
                {
                    return data.FirstOrDefault();
                }

                return null;
            }
        }

        public async Task UpdatePostAsync(UpdatePostDto model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", model.Id, DbType.Int32);
            parameters.Add("CategoryId", model.CategoryId, DbType.Int32);
            parameters.Add("Name", model.Name, DbType.String);
            parameters.Add("Description", model.Description, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(DapperQueries.UpdatePostQuery, parameters);
            }
        }
    }
}

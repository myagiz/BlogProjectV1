using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Queries
{
    public class DapperQueries
    {

        //Category
        public static string GetAllCategoriesQuery = "SELECT * FROM Categories WHERE IsActive=@IsActive";

        public static string GetCategoryByIdQuery = "SELECT * FROM Categories WHERE Id = @Id and IsActive=@IsActive";

        public static string AddCategoryQuery = "INSERT INTO Categories (Name, CreateDate, IsActive) VALUES (@Name, @CreateDate, @IsActive)" + "SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string UpdateCategoryQuery = "UPDATE Categories SET Name = @Name WHERE Id = @Id";

        public static string DeleteCategoryQuery = "UPDATE Categories SET IsActive = @IsActive WHERE Id = @Id";


        //Post
        public static string GetAllPostsQuery = "SELECT p.*,c.Name CategoryName FROM Posts p left join Categories c on p.CategoryId=c.Id WHERE p.IsActive=@IsActive";

        public static string GetPostByIdQuery = "SELECT p.*,c.Name CategoryName FROM Posts p left join Categories c on p.CategoryId=c.Id WHERE p.Id = @Id and p.IsActive=@IsActive";

        public static string AddPostQuery = "INSERT INTO Posts (Name, CategoryId,Description, CreateDate, IsActive) VALUES (@Name,@CategoryId,@Description, @CreateDate, @IsActive)" + "SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string UpdatePostQuery = "UPDATE Posts SET Name = @Name, CategoryId=@CategoryId,Description=@Description WHERE Id = @Id";

        public static string DeletePostQuery = "UPDATE Posts SET IsActive = @IsActive WHERE Id = @Id";



    }
}

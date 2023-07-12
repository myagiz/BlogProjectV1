using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Queries
{
    public class DapperQueries
    {
        public static string GetAllCategoriesQuery = "SELECT * FROM Categories";

        public static string GetCategoryByIdQuery = "SELECT * FROM Categories WHERE Id = @Id";
    }
}

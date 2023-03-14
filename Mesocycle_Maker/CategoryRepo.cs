using Dapper;
using System.Data;

namespace Mesocycle_Maker
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly IDbConnection _connection;
        public CategoryRepo(IDbConnection connection)
        { 
            _connection = connection;
        }

        public void DeleteCategory(int categoryID)
        {
            _connection.Execute("DELETE FROM category WHERE CategoryID = (@categID);",
               new { categID = categoryID });
        }

        public IEnumerable<CategoryRepo> GetAllCategories()
        {
            return _connection.Query<CategoryRepo>("SELECT * FROM category;");
        }

        public void InsertCategory(string newCategoryName)
        {
            _connection.Execute("INSERT INTO category CategoryName VALUES (@categoryName);",
                new { categoryName = newCategoryName });
        }

        public void UpdateCategory(string categoryName, int categoryID)
        {
            _connection.Execute("UPDATE category SET CategoryName = (@categName) WHERE CategoryID = (@catID);",
               new { categName = categoryName, catID = categoryID });
        }
    }
}

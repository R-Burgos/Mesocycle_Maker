using Mesocycle_Maker.Models;

namespace Mesocycle_Maker
{
    public interface ICategoryRepo
    {
        public IEnumerable<CategoryRepo> GetAllCategories();
        public void DeleteCategory(int categoryID);
        public void InsertCategory(string newCategoryName);
        public void UpdateCategory(string categoryName, int categoryID);
    }
}

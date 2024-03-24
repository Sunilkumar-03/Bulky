using BulkyProject.Models;

namespace BulkyProject.Services
{
    public interface ICategory
    {
        List<Categories> GetCategories();
        void InsertCategory(Categories category);
        Categories GetCategory(int? id);
        bool DeleteCategory(int id);
        bool UpdateCategory(Categories category);
    }
}

using BulkyProject.Data;
using BulkyProject.Models;

namespace BulkyProject.Services
{
    public class Category : ICategory
    {
        private readonly ApplicationDbContext _context;
        public Category(ApplicationDbContext context)
        {
                _context = context;
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                Categories category = _context.Categories.Find(id);
                if(category == null) { return false; }
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Categories> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Categories GetCategory(int? id)
        {
            return _context.Categories.Find(id);
        }

        public void InsertCategory(Categories category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public bool UpdateCategory(Categories category)
        {
            try
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

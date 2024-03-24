using BulkyProject.Models;
using BulkyProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace BulkyProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _category;
        public CategoryController(ICategory category)
        {
            _category = category;
        }
        public IActionResult Index()
        {
            List<Categories> categories = _category.GetCategories();
            return View();
        }
        public IActionResult DisplayCategories()
        {
            List<Categories> categories = _category.GetCategories();
            return View(categories);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Categories categories)
        {
            if(categories.Name == categories.CategoryOrder.ToString())
            {
                ModelState.AddModelError("", "Name and order should be different");
            }
            if(ModelState.IsValid)
            {
                _category.InsertCategory(categories);
                TempData["Success"] = "Category Created Successfully.!";
                return RedirectToAction("DisplayCategories");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            Categories categories = _category.GetCategory(id);
            if (id == null || id == 0)
                return NotFound();
            if (categories != null)
                return View(categories);
            else
                return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Categories categories)
        {
            if (ModelState.IsValid)
            {
                if (_category.UpdateCategory(categories))
                {
                    TempData["Success"] = "Category Updated Successfully.!";
                    return RedirectToAction("DisplayCategories");
                }
                else
                    return NotFound();

            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            Categories categories = _category.GetCategory(id);
            if (id == null || id == 0)
                return NotFound();
            if (categories != null)
                return View(categories);
            else
                return NotFound();
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteCategory(int id)
        {

            if (_category.DeleteCategory(id))
            {
                TempData["Success"] = "Category Deleted Successfully.!";
                return RedirectToAction("DisplayCategories");
            }
            else
            {
                return NotFound();
            }
        }
    }
}

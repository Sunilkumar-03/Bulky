using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Bulky.DataAccess.Repositories.IRepository;
using Bulky.DataAccess;

namespace BulkyProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitWork _unitWork;
        public CategoryController(IUnitWork work)
        {
            _unitWork = work;
        }
        public IActionResult Index()
        {
            IEnumerable<Categories> categories = _unitWork.category.GetAll();
            return View();
        }
        public IActionResult DisplayCategories()
        {
            IEnumerable<Categories> categories = _unitWork.category.GetAll();
            return View(categories);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Categories categories)
        {
            if (categories.Name == categories.CategoryOrder.ToString())
            {
                ModelState.AddModelError("", "Name and order should be different");
            }
            if (ModelState.IsValid)
            {
                _unitWork.category.Add(categories);
                _unitWork.Save();
                TempData["Success"] = "Category Created Successfully.!";
                return RedirectToAction("DisplayCategories");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            Categories categories = _unitWork.category.Get(u => u.CategoryId == id);
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
                _unitWork.category.Update(categories);
                _unitWork.Save();
                TempData["Success"] = "Category Updated Successfully.!";
                return RedirectToAction("DisplayCategories");

            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            Categories categories = _unitWork.category.Get(u => u.CategoryId == id);
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
            Categories categories = _unitWork.category.Get(u => u.CategoryId == id);
            if (categories != null)
            {
                _unitWork.category.Remove(categories);
                _unitWork.Save();
                TempData["Success"] = "Category Deleted Successfully.!";
                return RedirectToAction("DisplayCategories");
            }
            else
                return NotFound();

        }
    }
}

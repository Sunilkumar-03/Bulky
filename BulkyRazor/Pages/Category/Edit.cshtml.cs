using BulkyRazor.Data;
using BulkyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRazor.Pages.Category
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CategoryModel Category { get; set; }

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int id)
        {
            if (id != null || id != 0)
            {
                Category = _context.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                _context.Categories.Update(Category);
                _context.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

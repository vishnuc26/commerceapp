using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razarpagescrud.Data;
using Razarpagescrud.Models;

namespace Razarpagescrud.Pages.categories
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;

        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _db.categories.Add(Category);
            _db.SaveChanges();
            TempData["success"] = "Created successfully";
            return RedirectToPage("Index");
        }
    }
}
